using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger_LoadScene : MonoBehaviour
{

    [SerializeField]
    private string sceneName;

    void OnTriggerEnter(Collider user)
    {
        if (user.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
