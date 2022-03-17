using System.Collections;
using System.Collections.Generic;
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

        void Update ()
        {
            if (m_gcCharMover == null)
            {
                m_gcCharMover = GameObject.FindWithTag("Player").GetComponent<CharMover>();
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                UIManager.s_UIManager.StartDialog("dialog", new QuestReward(1, 1, 1), new QuestReward(-5, -5, -5));
                PlayerCanMove(false);
            }
        }

        public void PlayerCanMove(bool value)
        {
            m_gcCharMover.m_bCanMove = value;
        }
    }
}
