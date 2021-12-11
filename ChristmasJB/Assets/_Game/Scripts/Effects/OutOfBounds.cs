using UnityEngine;

namespace Assets._Game.Scripts.Effects
{
    public class OutOfBounds : MonoBehaviour
    {
        public GameObject ExplosionToSpawn;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Instantiate(ExplosionToSpawn, other.transform.position, other.transform.rotation);
            }
        }
    }
}