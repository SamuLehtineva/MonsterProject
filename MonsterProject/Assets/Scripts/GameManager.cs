using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class GameManager : MonoBehaviour, ISaveable
    {
        public static string m_sDestination = "Default";
        public static string m_sDestinationScene = "Cabin";
        public static GameManager s_GameManager;
        public static int m_iMinigameQuestIndex = 0;
        public bool m_bPaused = false;
        CharMover m_gcCharMover;
        private string[] m_aNoHudScenes = {"MinigameTest", "SImonSays", "Running Minigame", "Menu"};
        private float m_fFixedDeltaTime;
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
            m_sDestinationScene = SceneManager.GetActiveScene().name;
            Debug.Log("active scene: " + m_sDestinationScene);
            SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive);

            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
            m_fFixedDeltaTime = Time.fixedDeltaTime;
            m_bPaused = false;
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
            
            if (UIManager.s_UIManager != null)
            {
                UIManager.s_UIManager.HideDialog();
                UIManager.s_UIManager.TogglePauseMenu(false);
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

        public void Pause()
        {
            if (!m_bPaused)
            {
                Time.timeScale = 0f;
                m_bPaused = true;
            }
            else
            {
                Time.timeScale = 1f;
                m_bPaused = false;
            }
            Time.fixedDeltaTime = m_fFixedDeltaTime * Time.timeScale;
            UIManager.s_UIManager.TogglePauseMenu(m_bPaused);
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

        public void Save(ISaveWriter writer)
        {
            writer.WriteString(m_sDestination);
            writer.WriteString(m_sDestinationScene);
        }

        public void Load(ISaveReader reader)
        {
            m_bPaused = false;
            m_sDestination = reader.ReadString();
            m_sDestinationScene = reader.ReadString();
            SceneManager.LoadScene(m_sDestinationScene);
        }
    }
}
