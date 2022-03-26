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
        static bool m_bUsable = true;

        void Start()
        {
            IsActive = true;
            if (!m_bUsable)
            {
                Kill();
            }
        }

        public void Activate()
        {
            Interact();
        }

        public void DeActivate()
        {
            IsActive = false;
        }

        public void Interact()
        {
            UIManager.s_UIManager.StartDialog(m_sFileName, m_qRewardA, m_qRewardB);
            m_bUsable = false;
            Kill();
        }

        void Kill()
        {
            gameObject.SetActive(false);
        }
    }
}
