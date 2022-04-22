using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioClipPlayer : MonoBehaviour
    {
        [SerializeField]
        List<AudioClip> m_lClips = new List<AudioClip>();
        private AudioSource m_gcAudio;

        void Start()
        {
            m_gcAudio = GetComponent<AudioSource>();
        }

        public void PlayClip(int index, float volume)
        {
            m_gcAudio.PlayOneShot(m_lClips[index], volume * PlayerPrefs.GetFloat("EffectVolume"));
        }

        public void PlayClipDelayed(int index, int delayInSecs)
        {
            StartCoroutine(PlayDelay(index, delayInSecs));
        }

        IEnumerator PlayDelay(int index, int seconds)
        {
            yield return new WaitForSeconds(seconds);
            m_gcAudio.PlayOneShot(m_lClips[index]);
        }
    }
}
