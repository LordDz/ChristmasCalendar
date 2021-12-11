using System.Collections;
using UnityEngine;

namespace Assets._Game.Scripts.Weapons
{
    public class CatExplode : MonoBehaviour
    {
        private bool catIsExploding = false;

        [SerializeField]
        private float catExplosionCooldown = 0.4f;

        public Transform CatSprite;
        public ShootSound shootSound;

        [SerializeField]
        private GameObject ExplosionPrefab;

        [SerializeField]
        private NPC_Enemy cat;

        // Update is called once per frame
        void Update()
        {
            if (catIsExploding)
            {
                CatExplosionUpdate();
            }
        }

        private void CatExplosionStart()
        {
            catIsExploding = true;
            shootSound.PlaySound();
        }

        private void CatExplosionUpdate()
        {
            catExplosionCooldown -= Time.deltaTime;
            float catIncrease = 40f * Time.deltaTime;

            CatSprite.localScale = new Vector3(CatSprite.localScale.x + catIncrease, CatSprite.localScale.y + catIncrease, CatSprite.localScale.z);

            if (catExplosionCooldown <= 0)
            {
                catIsExploding = false;
                shootSound.StopSound();
                GameObject explosionCat = Instantiate(ExplosionPrefab, transform.position, transform.rotation);
                explosionCat.transform.Rotate(0, Random.Range(-7.5f, 7.5f), 0);
                cat.Damage(true);
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!catIsExploding && other.tag == "Player")
            {
                CatExplosionStart();
            }
        }
    }
}