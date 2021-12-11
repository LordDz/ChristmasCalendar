using UnityEngine;

namespace Assets._Game.Scripts.Effects
{
    public class ObjectRotate : MonoBehaviour
    {
        [SerializeField]
        float speed = 50f;

        void Update()
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
    }
}