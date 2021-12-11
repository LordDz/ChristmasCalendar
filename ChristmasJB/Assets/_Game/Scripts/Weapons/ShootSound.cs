using System.Collections;
using UnityEngine;

namespace Assets._Game.Scripts.Weapons
{
    public class ShootSound : MonoBehaviour
    {
        [SerializeField]
        AudioClip[] audioClips;

        [SerializeField]
        GameObject SoundToPlayOnPosition;

        [SerializeField]
        private bool PlayAs3D = true;

        public void PlaySound()
        {
            if (audioClips.Length > 0)
            {
                if (PlayAs3D && SoundToPlayOnPosition)
                {
                    var sound = Instantiate(SoundToPlayOnPosition, transform.position, transform.rotation);
                    var audioSource = sound.GetComponent<AudioSource>();
                    if (audioSource)
                    {
                        audioSource.clip = audioClips[Random.Range(0, audioClips.Length - 1)];
                        audioSource.Play();
                    }
                }
                else if (!PlayAs3D)
                {
                    var audioSource = GetComponent<AudioSource>();
                    audioSource.clip = audioClips[Random.Range(0, audioClips.Length - 1)];
                    audioSource.Play();
                }
            }
        }

        public void StopSound()
        {
            if (!PlayAs3D)
            {
                var audioSource = GetComponent<AudioSource>();
                audioSource.Stop();

            }
        }
    }
}
