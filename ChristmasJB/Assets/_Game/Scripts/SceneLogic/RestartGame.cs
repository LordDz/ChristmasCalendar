using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Game.Scripts
{
    public class RestartGame : MonoBehaviour
    {
        public void BackToMainMenu()
        {
            var loadedObjects = GetDontDestroyOnLoadObjects();
            foreach (var loadedObj in loadedObjects)
            {
                var sceneLoader = loadedObj.GetComponent<SceneLoader>();
                if (sceneLoader != null)
                {
                    Destroy(sceneLoader);
                }
            }
            SceneManager.LoadScene(0);
        }

        public void ExitGame()
        {
            Application.Quit();
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