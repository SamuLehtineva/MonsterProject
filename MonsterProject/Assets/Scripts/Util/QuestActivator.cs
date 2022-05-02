using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class QuestActivator : MonoBehaviour
    {
        public GameObject m_goTarget;
        public string m_sQuestName;
        public Types.EStatus m_iStatus = Types.EStatus._Active;

        void Update()
        {
            if (UIManager.s_UIManager.m_gcQuestManager.GetQuestByName(m_sQuestName).m_iStatus == m_iStatus)
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
