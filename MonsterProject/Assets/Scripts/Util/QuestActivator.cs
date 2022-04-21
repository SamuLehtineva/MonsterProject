using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class QuestActivator : MonoBehaviour
    {
        public GameObject m_goTarget;
        public string m_sQuestName;

        void Update()
        {
            if (UIManager.s_UIManager.m_gcQuestManager.GetQuestByName(m_sQuestName).m_iStatus == Types.EStatus._Active)
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
