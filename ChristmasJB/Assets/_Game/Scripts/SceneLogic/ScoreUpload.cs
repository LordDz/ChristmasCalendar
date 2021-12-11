using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets._Game.Scripts.SceneLogic
{
    public class ScoreUpload : MonoBehaviour
    {
        public GameObject ObjectToDisable;

        [SerializeField]
        Text textScore;

        private void Start()
        {
            Cursor.visible = true;
            int score = 0;

            var loadedObjects = GetDontDestroyOnLoadObjects();
            foreach (var loadedObj in loadedObjects)
            {
                var sceneLoader = loadedObj.GetComponent<SceneLoader>();
                score = sceneLoader.Score;
            }
            textScore.text = score.ToString() + " cash picked up";
            Debug.Log("Score to upload: " + score);
        }

        public void UploadScore()
        {

        }

        private GameObject[] GetDontDestroyOnLoadObjects()
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
    }
}