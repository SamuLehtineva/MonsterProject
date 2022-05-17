using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class QuestActivatorArray : MonoBehaviour
    {
        public GameObject m_oTarget;
        public string m_sQuestName;
        public Types.EStatus[] m_iStatuses;        

        void Update()
        {
            bool bVar = false;
            foreach (Types.EStatus stat in m_iStatuses)
            {
                if (UIManager.s_UIManager.m_gcQuestManager.GetQuestByName(m_sQuestName).m_iStatus == stat)
                {
                    bVar = true;
                }
            }
            
            m_oTarget.SetActive(bVar);
        }
    }
}
