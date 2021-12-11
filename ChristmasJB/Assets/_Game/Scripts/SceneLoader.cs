using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Game.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField]
        private int numberOfReloads = 0;

        public int Score = 0;

        public int GetNrOfReloads()
        {
            numberOfReloads++;
            return numberOfReloads;
        }

        public void SetScore(int score)
        {
            Score = score;
        }

        public void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void LoadFirstLevel()
        {
            SceneManager.LoadScene(1);
        }
    }
}