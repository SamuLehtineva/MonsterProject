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
        public QuestReward m_qRewardA;
        public QuestReward m_qRewardB;

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
            DeActivate();
        }
    }
}