using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class QuestProgressActivator : MonoBehaviour
    {
        public GameObject m_goTarget;
        public string m_sQuestName;
        public int m_iProgressTresHold;

        void Update()
        {
            if (UIManager.s_UIManager.m_gcQuestManager.GetQuestByName(m_sQuestName).m_iCurrentProgress >= m_iProgressTresHold)
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
