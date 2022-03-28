using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class Npc_Trigger : MonoBehaviour, IInteractables, INpc
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
        public QuestReward m_qRewardA;
        public string m_sQuestNameA = "none";
        public Types.EStatus m_eQuestStatusA;
        public QuestReward m_qRewardB;
        public string m_sQuestNameB = "none";
        public Types.EStatus m_eQuestStatusB;
        public bool m_bUsable = true;

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
            UIManager.s_UIManager.StartDialog(this);
            m_bUsable = false;
            Kill();
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

        void Kill()
        {
            gameObject.SetActive(false);
        }

        public bool GetUsable()
        {
            return m_bUsable;
        }
    }
}
