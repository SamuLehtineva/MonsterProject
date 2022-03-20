using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class GameManager : MonoBehaviour
    {
        public static string m_sDestination;

        public static GameManager s_GameManager;

        CharMover m_gcCharMover;

        void Awake()
        {
            if (s_GameManager != null)
            {
                Destroy(gameObject);
            }
            else
            {
                s_GameManager = this;
            }
            DontDestroyOnLoad(this);

            m_gcCharMover = GameObject.FindWithTag("Player").GetComponent<CharMover>();

            SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive);
        }

        void OnEnable() 
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            try
            {
                if (m_gcCharMover == null)
                {
                    m_gcCharMover = GameObject.FindWithTag("Player").GetComponent<CharMover>();
                }
            }
            catch (NullReferenceException e)
            {
                Debug.Log(e);
            }
            
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        public void PlayerCanMove(bool value)
        {
            m_gcCharMover.m_bCanMove = value;
        }
    }
}
