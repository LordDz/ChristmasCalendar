using UnityEngine;

namespace Assets._Game.Scripts.Items
{
    public class ItemJB : MonoBehaviour
    {
        private bool isCollectingMoney = false;

        [SerializeField]
        GameObject SoundToPlayOnPosition;

        [SerializeField]
        int purchaseCost = 100;

        public GameObject ObjEnableOnPickup;
        public GameObject ObjDisableOnPickup;

        private void CollectJB()
        {
            isCollectingMoney = true;
            Instantiate(SoundToPlayOnPosition, transform.position, transform.rotation);

            GameManager.AddScore(-purchaseCost);
            ObjEnableOnPickup.SetActive(true);

            AlertEnemies();

            Destroy(gameObject);
            Destroy(ObjDisableOnPickup);
        }

        private void AlertEnemies()
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, 500f, transform.up);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider != null && hit.collider.tag == "Enemy")
                {
                    hit.collider.GetComponent<NPC_Enemy>().SetAlertPos(transform.position);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!isCollectingMoney && other.tag == "Player" && GameManager.GetScore() >= purchaseCost)
            {
                CollectJB();
            }
        }
    }
}