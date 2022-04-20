using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class Npc_FisherMan : MonoBehaviour
    {
        [SerializeField]
        Npc_Talk m_gcTalk;

        void Update()
        {
            Types.EStatus iEStatus = UIManager.s_UIManager.m_gcQuestManager.GetQuestByName("fetch_flower").m_iStatus;
            switch (iEStatus)
            {
                case Types.EStatus._Inactive:
                    m_gcTalk.m_sFileName = "fetch_flower_inactive";

                    break;

                case Types.EStatus._Active:
                    m_gcTalk.m_sFileName = "fetch_flower_active";
                    
                    break;
                
                case Types.EStatus._Completed:
                    m_gcTalk.m_sFileName = "fetch_flower_completed";
                    m_gcTalk.m_qRewardA = new QuestReward(10, 10, 0);
                    m_gcTalk.m_bRewardTalk = true;

                    break;
                
                case Types.EStatus._Done:
                    m_gcTalk.m_sFileName = "fetch_flower_done";
                    m_gcTalk.m_bRewardTalk = false;

                    break;

                case Types.EStatus._Failed:
                    m_gcTalk.m_sFileName = "fetch_flower_failed";

                    break;
            }
        }
    }
}
