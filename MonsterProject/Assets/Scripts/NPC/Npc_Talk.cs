using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class Npc_Talk : MonoBehaviour, IInteractables, INpc
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
        GameObject m_gcQuestIcon;
        public QuestReward m_qRewardA;
        public string m_sQuestNameA = "none";
        public Types.EStatus m_eQuestStatusA;
        public QuestReward m_qRewardB;
        public string m_sQuestNameB = "none";
        public Types.EStatus m_eQuestStatusB;
        public bool m_bRewardTalk = false;

        void Start()
        {
            IsActive = false;
            m_gcQuestIcon = GameObject.Find(transform.parent.gameObject.name + "/alert");
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1") && IsActive && GameManager.s_GameManager.GetPlayerCanMove())
            {
                Interact();
            }
        }

        public void Activate()
        {
            if (!IsActive)
            {
                IsActive = true;
            }
        }

        public void DeActivate()
        {
            if (IsActive)
            {
                IsActive = false;
            }
        }

        public void Interact()
        {
            UIManager.s_UIManager.StartDialog(this);
            DeActivate();
        }

        public void Kill()
        {
            if (m_gcQuestIcon != null)
            {
                m_gcQuestIcon.SetActive(false);
            }
            gameObject.SetActive(false);
        }

        public void PickOptionA()
        {
            PlayerResources.s_CurrentResources.AddResources(m_qRewardA);
            UIManager.s_UIManager.m_gcQuestManager.SetQuestStatus(m_sQuestNameA, m_eQuestStatusA);
        }

        public void PickOptionB()
        {
            PlayerResources.s_CurrentResources.AddResources(m_qRewardB);
            UIManager.s_UIManager.m_gcQuestManager.SetQuestStatus(m_sQuestNameB, m_eQuestStatusB);
        }

        public void DialogEnd()
        {
            if (m_bRewardTalk)
            {
                PickOptionA();
            }
        }
        
        public void ShowIcon(bool value)
        {
            m_gcQuestIcon.SetActive(value);
        }
    }
}
