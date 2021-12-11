using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets._Game.Scripts;

public class GameManager : MonoBehaviour
{
    public Text scoreText, scoreTextBG;
    public GameObject restartMessage, endSection;
    int currentScore = 100;
    private float scoreCooldownReduce = 0.0f;
    private int scoreReduceTime = 2;

    static GameManager myslf;
    public bool gameOver = false;
    int enemyCount;

    public AudioClip[] AudioDeathClips;
    public AudioSource AudioDeathJingle;

    public GameObject hintText1;
    public GameObject hintText2;
    public TextMesh hintText3;
    public HintHelper hintHelper;

    public static int GetScore()
    {
        return myslf.currentScore;
    }

    void Awake()
    {
        myslf = this;

    }
    // Use this for initialization
    void Start()
    {
        var loadedObjects = GetDontDestroyOnLoadObjects();
        foreach (var loadedObj in loadedObjects)
        {
            var sceneLoader = loadedObj.GetComponent<SceneLoader>();
            if (sceneLoader != null)
            {
                var numberOfReloads = sceneLoader.GetNrOfReloads();
                Debug.Log("number of reloads: " + numberOfReloads);
                if (numberOfReloads > 2)
                {
                    hintText1.SetActive(false);
                    hintText2.SetActive(false);
                }
                hintText3.text = hintHelper.GetText(numberOfReloads);
            }
        }
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            ScoreTimer();
        }
    }

    public static GameObject[] GetDontDestroyOnLoadObjects()
    {
        GameObject temp = null;
        try
        {
            temp = new GameObject();
            DontDestroyOnLoad(temp);
            Scene dontDestroyOnLoad = temp.scene;
            DestroyImmediate(temp);
            temp = null;

            return dontDestroyOnLoad.GetRootGameObjects();
        }
        finally
        {
            if (temp != null)
            {
                DestroyImmediate(temp);
            }
        }
    }

    private static void ScoreTimer()
    {
        myslf.scoreCooldownReduce -= Time.deltaTime;
        if (myslf.scoreCooldownReduce <= 0)
        {
            myslf.scoreCooldownReduce = 1f;
            myslf.currentScore -= myslf.scoreReduceTime;

            myslf.scoreText.text = myslf.currentScore.ToString();
            myslf.scoreTextBG.text = myslf.currentScore.ToString();
        }
    }

    public static void AddScore(int pointsAdded)
    {
        myslf.currentScore += pointsAdded;
        myslf.scoreText.text = myslf.currentScore.ToString();
        myslf.scoreTextBG.text = myslf.currentScore.ToString();
        myslf.scoreText.transform.localScale = Vector3.one * 2.5f;
        iTween.Stop(myslf.scoreText.gameObject);
        iTween.ScaleTo(myslf.scoreText.gameObject, iTween.Hash("scale", Vector3.one, "time", 0.25f, "delay", 0.1f, "easetype", iTween.EaseType.spring));
    }
    public static void RegisterPlayerDeath()
    {
        myslf.restartMessage.SetActive(true);
        myslf.restartMessage.transform.localScale = Vector3.one * 2.0f;
        iTween.Stop(myslf.restartMessage.gameObject);
        iTween.ScaleTo(myslf.restartMessage, iTween.Hash("scale", Vector3.one, "time", 0.5f, "delay", 0.1f, "easetype", iTween.EaseType.spring));
        myslf.gameOver = true;
        if (myslf.AudioDeathJingle)
        {
            myslf.AudioDeathJingle.clip = myslf.AudioDeathClips[Random.Range(0, myslf.AudioDeathClips.Length - 1)];
            myslf.AudioDeathJingle.Play();
        }
    }
    public static void SelectWeapon(PlayerWeaponType weaponType)
    {
        //switch (weaponType)
        //{
        //    case PlayerWeaponType.KNIFE:
        //        myslf.knifeSelector.SetActive(true);
        //        myslf.gunSelector.SetActive(false);
        //        break;
        //    case PlayerWeaponType.PISTOL:
        //        myslf.knifeSelector.SetActive(false);
        //        myslf.gunSelector.SetActive(true);
        //        break;
        //}

    }
    public static void AddToEnemyCount()
    {
        myslf.enemyCount++;
    }
    public static void RemoveEnemy()
    {
        myslf.enemyCount--;
    }
}
