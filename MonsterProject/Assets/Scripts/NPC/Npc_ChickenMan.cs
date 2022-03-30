using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class Npc_ChickenMan : MonoBehaviour
    {
        [SerializeField]
        Npc_Talk m_gcTalk;

        [SerializeField]
        Npc_Trigger m_gcTrigger;
        static bool m_bTriggered = false;

        void Update()
        {
            if (UIManager.s_UIManager.m_gcQuestManager.GetQuestByName("fetch_helga").m_iStatus == Types.EStatus._Completed)
            {
                m_gcTalk.m_sFileName = "fetch_helga_complete";
                m_gcTalk.m_bRewardTalk = true;
                m_gcTalk.m_bKillAfterUse = true;
            }

            if (!m_gcTrigger.gameObject.activeInHierarchy && !m_bTriggered)
            {
                m_gcTalk.gameObject.SetActive(true);
                m_bTriggered = true;
            }
        }
    }
}
