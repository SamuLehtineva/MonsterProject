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
        public static int m_iMinigameQuestIndex;
        CharMover m_gcCharMover;
        private string[] m_aNoHudScenes = {"MinigameTest", "SImonSays", "Running Minigame"};
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

        void LateUpdate() 
        {
            if (Array.Exists(m_aNoHudScenes, element => element == SceneManager.GetActiveScene().name))
            {
                UIManager.s_UIManager.ToggleHud(false);
            }
            else
            {
                UIManager.s_UIManager.ToggleHud(true);
            }
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        public void PlayerCanMove(bool value)
        {
            if (value)
            {
                StartCoroutine(PlayerCanMoveDelay());
            }
            else
            {
                m_gcCharMover.m_bCanMove = false;
            }
        }

        public bool GetPlayerCanMove()
        {
            return m_gcCharMover.m_bCanMove;
        }

        IEnumerator PlayerCanMoveDelay()
        {
            yield return new WaitForSeconds(0.3f);
            m_gcCharMover.m_bCanMove = true;
        }
    }
}
