using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class MusicController : MonoBehaviour
    {
        public float m_fLerpDurationSeconds = 2f;
        public AudioClip m_cgClip;
        private AudioSource m_gcAudi;
        private float m_fEventTime = 0.0f;
        private float m_fRatio = 0.0f;
        private float m_fTargetVolume1 = 0.0f;
        private float m_fTargetVolume2;
        private bool m_bFading;

        void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name != "Settings" && scene.name != "HUD" && scene.name != "Transitions")
            {
               PlayMusic(); 
            }
        }

        void Start()
        {
            m_gcAudi = GetComponent<AudioSource>();
            PlayMusic();
        }

        public void PlayMusic()
        {
            m_cgClip = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().clip;
            m_gcAudi.clip = m_cgClip;
            m_gcAudi.Play();
            m_fEventTime = Time.time;
            m_fRatio = 0.0f;
            m_fTargetVolume1 = 0.0f;
            m_fTargetVolume2 = PlayerPrefs.GetFloat("MusicVolume");
            m_bFading = false;

        }

        void Update()
        {
            if (m_fRatio < 1f)
            {
                m_fRatio = (Time.time - m_fEventTime) / m_fLerpDurationSeconds;
            }
            else if (!m_bFading)
            {
                m_fTargetVolume2 = PlayerPrefs.GetFloat("MusicVolume");
            }
            m_gcAudi.volume = Mathf.Lerp(m_fTargetVolume1, m_fTargetVolume2, m_fRatio);
        }

        public void SetVolume(float volume)
        {
            m_gcAudi.volume = volume;
        }

        public void FadeOut()
        {
            m_fEventTime = Time.time;
            m_fRatio = 0.0f;
            m_fTargetVolume1 = m_gcAudi.volume;
            m_fTargetVolume2 = 0.0f;
            m_bFading = true;
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
