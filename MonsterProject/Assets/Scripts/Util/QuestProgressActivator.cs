using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class QuestProgressActivator : MonoBehaviour
    {
        public GameObject m_goTarget;
        public string m_sQuestName;
        public int m_iProgressTarget;
        private QuestInfo m_qQuest;

        void Start()
        {
            m_qQuest = UIManager.s_UIManager.m_gcQuestManager.GetQuestByName(m_sQuestName);
        }

        void Update()
        {
            if (m_qQuest.m_iCurrentProgress == m_iProgressTarget && m_qQuest.m_iStatus == Types.EStatus._Active)
            {
                m_goTarget.SetActive(true);
            }
            else
            {
                m_goTarget.SetActive(false);
            }
        }
    }
}
