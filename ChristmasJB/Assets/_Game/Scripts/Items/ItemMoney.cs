using UnityEngine;

namespace Assets._Game.Scripts.Items
{
    public class ItemMoney : MonoBehaviour
    {
        private bool isCollectingMoney = false;

        [SerializeField]
        int PickupScore = 50;

        [SerializeField]
        GameObject SoundToPlayOnPosition;

        private void CollectMoney()
        {
            isCollectingMoney = true;
            Instantiate(SoundToPlayOnPosition, transform.position, transform.rotation);

            if (Mathf.Abs(PickupScore) > 0)
            {
                GameManager.AddScore(PickupScore);
            }
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!isCollectingMoney && other.tag == "Player")
            {
                CollectMoney();
            }
        }
    }
}