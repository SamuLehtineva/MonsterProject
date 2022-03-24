using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class Npc_Trigger : MonoBehaviour, IInteractables
    {
        public bool IsActive
        {
            get;
            set;
        }

        public string m_sFileName;
        public QuestReward m_qRewardA;
        public QuestReward m_qRewardB;

        public void Activate()
        {
            if (IsActive)
            {
                Interact();
            }
        }

        public void DeActivate()
        {
            gameObject.SetActive(false);
        }

        public void Interact()
        {
            UIManager.s_UIManager.StartDialog(m_sFileName, m_qRewardA, m_qRewardB);
            DeActivate();
        }

        void Start()
        {
            IsActive = true;
        }
    }
}
