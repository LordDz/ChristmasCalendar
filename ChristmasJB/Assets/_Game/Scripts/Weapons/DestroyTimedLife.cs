using System.Collections;
using UnityEngine;

namespace Assets._Game.Scripts.Weapons
{
    public class DestroyTimedLife : MonoBehaviour
    {
        [SerializeField]
        float timeAlive = 3f;
        // Use this for initialization
        void Start()
        {
            Destroy(gameObject, timeAlive);
        }
    }
}
