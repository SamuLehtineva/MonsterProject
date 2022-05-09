using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class MusicController : MonoBehaviour
    {
        public float m_fLerpDurationSeconds = 1.0f;
        public AudioClip m_cgClip;
        private AudioSource m_gcAudi;
        private float m_fEventTime = 0.0f;
        private float m_fRatio = 0.0f;

        void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name != "Settings" && scene.name != "HUD")
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
        }

        void Update()
        {
            if (m_fRatio < 1f)
            {
                m_fRatio = (Time.time - m_fEventTime) / m_fLerpDurationSeconds;
            }
            m_gcAudi.volume = Mathf.Lerp(0.0f, PlayerPrefs.GetFloat("MusicVolume"), m_fRatio);
        }

        public void SetVolume(float volume)
        {
            m_gcAudi.volume = volume;
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
