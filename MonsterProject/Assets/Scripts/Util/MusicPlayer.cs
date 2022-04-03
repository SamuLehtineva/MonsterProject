using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicPlayer : MonoBehaviour
    {
        private AudioSource m_gcAudi;

        void Start()
        {
            m_gcAudi = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            m_gcAudi.volume = PlayerPrefs.GetFloat("MusicVolume");
        }
    }
}
