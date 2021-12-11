using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float lifeTime = 3f;
    public float dmgDistance = 0f;

    public AudioSource audioSource;
    public AudioClip[] ListClips;
    public GameObject[] ListDecals;
    public GameObject DeathMoney;

    // Start is called before the first frame update
    void Start()
    {
        float time = lifeTime;
        if (audioSource && ListClips.Length > 0)
        {
            AudioClip clip = ListClips[Random.Range(0, ListClips.Length - 1)];
            audioSource.clip = clip;
            audioSource.Play();
            time = clip.length + 0.1f;
        }

        if (ListDecals.Length > 0)
        {
            Instantiate(ListDecals[Random.Range(0, ListDecals.Length - 1)], new Vector3(transform.position.x, 0.22f, transform.position.z), transform.rotation);
        }

        if (dmgDistance > 0)
        {
            foreach (NPC_Enemy npc in FindObjectsOfType<NPC_Enemy>())
            {
                if (Vector3.Distance(transform.position, npc.transform.position) <= dmgDistance)
                {
                    npc.Damage();
                }
            }

            var player = FindObjectOfType<PlayerBehavior>();
            if (Vector3.Distance(transform.position, player.transform.position) <= dmgDistance)
            {
                player.DamagePlayer();
            }
        }

        if (DeathMoney)
        {
            Instantiate(DeathMoney, new Vector3(transform.position.x, 0.23f, transform.position.z), transform.rotation);
        }

        Destroy(gameObject, time);
    }
}
