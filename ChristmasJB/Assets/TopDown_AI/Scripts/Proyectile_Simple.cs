using UnityEngine;
using System.Collections;

public class Proyectile_Simple : MonoBehaviour
{
    public float lifeTime = 3.0f;
    public float speed = 1.5f;
    public GameObject explosionPrefab;

    Rigidbody rigidProjectile;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip[] audioClips;

    [SerializeField]
    bool ExplodeUponHit = true;

    void Start()
    {
        rigidProjectile = GetComponent<Rigidbody>();
        rigidProjectile.AddForce(transform.forward * speed);
        //Destroy(gameObject, lifeTime);
        StartCoroutine(ExplodeWhenTimedOut());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (rigidProjectile)
        {
            rigidProjectile.AddForce(-transform.forward * speed);
        }

        if (!ExplodeUponHit)
        {
            return;
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerBehavior>().DamagePlayer();
            DestroyProjectile();

        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<NPC_Enemy>().Damage();
            DestroyProjectile();
        }
        else if (collision.gameObject.tag == "Props")
        {
            //collision.gameObject.GetComponent<NPC_Enemy>().Damage();
            DestroyProjectile();
        }
    }

    private void PlayRandomSound()
    {
        if (audioClips.Length > 0)
        {
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length - 1)];
            audioSource.Play();
        }
    }

    IEnumerator ExplodeWhenTimedOut()
    {
        PlayRandomSound();
        yield return new WaitForSeconds(lifeTime);
        DestroyProjectile();
    }
    void DestroyProjectile()
    {
        if (audioSource)
        {
            audioSource.Stop();
        }
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        //explosion.transform.LookAt(mousePointer.transform);
        //bullet.transform.Rotate(0, Random.Range(-7.5f, 7.5f), 0);
    }
}
