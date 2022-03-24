using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class Npc_Talk : MonoBehaviour, IInteractables
    {
        public bool IsActive
        {
            get;
            set;
        }
        public string m_sFileName;
        GameObject m_gcQuestIcon;
        public QuestReward m_qRewardA;
        public QuestReward m_qRewardB;
        static bool m_bUsable = true;

        void Start()
        {
            IsActive = false;
            m_gcQuestIcon = GameObject.Find(transform.parent.gameObject.name + "/alert");
            if (!m_bUsable)
            {
                Kill();
            }
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
            UIManager.s_UIManager.StartDialog(m_sFileName, m_qRewardA, m_qRewardB);
            m_bUsable = false;
            DeActivate();
            Kill();
        }

        void Kill()
        {
            if (m_gcQuestIcon != null)
            {
                m_gcQuestIcon.SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }
}
