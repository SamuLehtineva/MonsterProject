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
        public string m_sFileName{
            get;
            set;
        }
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
            UIManager.s_UIManager.StartDialog(this);
            m_bUsable = false;
            Kill();
        }

        public void PickOptionA()
        {
            PlayerResources.s_CurrentResources.AddResources(m_qRewardA);
        }

        public void PickOptionB()
        {
            PlayerResources.s_CurrentResources.AddResources(m_qRewardB);
        }

        void Kill()
        {
            gameObject.SetActive(false);
        }
    }
}
