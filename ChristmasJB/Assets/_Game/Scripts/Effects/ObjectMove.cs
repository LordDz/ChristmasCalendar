using UnityEngine;

namespace Assets._Game.Scripts.Effects
{
    public class ObjectMove : MonoBehaviour
    {
        [SerializeField]
        float speed = 50f;

        [SerializeField]
        float timeWait = 0.3f;

        private float timeCooldown = 0f;
        private float moveDir = 1f;

        void Update()
        {
            transform.position = new Vector3(transform.position.x + (speed * moveDir * Time.deltaTime), transform.position.y, transform.position.z);
            timeCooldown += Time.deltaTime;

            if (timeCooldown >= timeWait)
            {
                timeCooldown = 0;
                moveDir *= -1;
            }
        }
    }
}