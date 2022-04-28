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
        public string m_sName
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
        public bool m_bRewardTalk = false;

        void Start()
        {
            IsActive = true;
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

        public void Kill()
        {
            gameObject.SetActive(false);
        }

        public void DialogEnd()
        {
            if (m_bRewardTalk)
            {
                PickOptionA();
            }
        }
    }
}
