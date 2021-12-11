using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Game.Scripts.SceneLogic
{
    public class ExitLevel : MonoBehaviour
    {
        private bool isExitingLevel = false;

        private void LeaveTheLevel()
        {
            isExitingLevel = true;
            StartCoroutine(LeaveAfterShortTime());
        }

        IEnumerator LeaveAfterShortTime()
        {
            yield return new WaitForSeconds(0.1f);
            var loadedObjects = GetDontDestroyOnLoadObjects();
            foreach (var loadedObj in loadedObjects)
            {
                var sceneLoader = loadedObj.GetComponent<SceneLoader>();
                if (sceneLoader)
                {
                    sceneLoader.SetScore(GameManager.GetScore());
                }
            }

            SceneManager.LoadScene(2);
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

        private void OnTriggerEnter(Collider other)
        {
            if (!isExitingLevel && other.tag == "Player")
            {
                LeaveTheLevel();
            }
        }
    }
}