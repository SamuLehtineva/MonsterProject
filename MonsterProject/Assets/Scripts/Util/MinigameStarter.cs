using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class MinigameStarter : MonoBehaviour, IInteractables, INpc
    {
        public bool IsActive
        {
            get;
            set;
        }

        [field: SerializeField]
        public string m_sFileName 
        {
            get;
            set;    
        }

        public string m_SceneName;
        public int m_iMinigameQuestIndex;
        public string m_sSpawnPoint;

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
            UIManager.s_UIManager.StartDialog(this);
            DeActivate();
        }

        public void PickOptionA()
        {
            //empty for now
        }

        public void PickOptionB()
        {
            //empty for now
        }

        public void DialogEnd()
        {
            GameManager.m_sDestination = m_sSpawnPoint;
            GameManager.m_iMinigameQuestIndex = m_iMinigameQuestIndex;
            SceneManager.LoadScene(m_SceneName);
        }
    }
}
