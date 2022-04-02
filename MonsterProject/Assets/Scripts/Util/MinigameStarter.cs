using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class MinigameStarter : MonoBehaviour, IInteractables
    {
        public bool IsActive
        {
            get;
            set;
        }

        public string m_SceneName;
        public int m_iMinigameQuestIndex;

        void Start()
        {
            IsActive = false;
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1") && IsActive)
            {
                Interact();
            }
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void DeActivate()
        {
            IsActive = false;
        }

        public void Interact()
        {
            GameManager.m_iMinigameQuestIndex = m_iMinigameQuestIndex;
            SceneManager.LoadScene(m_SceneName);
        }
    }
}
