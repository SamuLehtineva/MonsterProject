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

        void Update()
        {
            Types.EStatus iEStatus = UIManager.s_UIManager.m_gcQuestManager.GetQuestByName("ate_chicken").m_iStatus;
            if (iEStatus == Types.EStatus._Disabled)
            {
                iEStatus = UIManager.s_UIManager.m_gcQuestManager.GetQuestByName("fetch_helga").m_iStatus;
                switch (iEStatus)
                {
                    case Types.EStatus._Inactive:
                        m_gcTrigger.gameObject.SetActive(true);
                        m_gcTrigger.m_sFileName = "fetch_helga/inactive";
                        m_gcTrigger.m_bRewardTalk = false;

                        m_gcTalk.gameObject.SetActive(false);

                        break;

                    case Types.EStatus._Active:
                        m_gcTrigger.gameObject.SetActive(false);

                        m_gcTalk.gameObject.SetActive(true);
                        m_gcTalk.m_sFileName = "fetch_helga/active";
                        m_gcTalk.m_bRewardTalk = false;
                        m_gcTalk.ShowIcon(false);

                        break;
                    
                    case Types.EStatus._Completed:
                        m_gcTrigger.gameObject.SetActive(false);

                        m_gcTalk.gameObject.SetActive(true);
                        m_gcTalk.m_sFileName = "fetch_helga/complete";
                        m_gcTalk.m_bRewardTalk = true;
                        m_gcTalk.ShowIcon(true);

                        break;
                    
                    case Types.EStatus._Done:
                        m_gcTrigger.gameObject.SetActive(false);

                        m_gcTalk.gameObject.SetActive(true);
                        m_gcTalk.m_sFileName = "fetch_helga/done";
                        m_gcTalk.m_bRewardTalk = false;
                        m_gcTalk.ShowIcon(false);

                        break;

                    case Types.EStatus._Failed:
                        m_gcTrigger.gameObject.SetActive(false);

                        m_gcTalk.gameObject.SetActive(true);
                        m_gcTalk.m_sFileName = "fetch_helga/failed";
                        m_gcTalk.m_bRewardTalk = false;
                        m_gcTalk.ShowIcon(false);

                        break;
                }
            }
            else
            {
                switch (iEStatus)
                {
                    case Types.EStatus._Inactive:
                        m_gcTrigger.gameObject.SetActive(true);
                        m_gcTrigger.m_sFileName = "Ate_chicken_inactive";
                        m_gcTrigger.m_qRewardA = new QuestReward(-20, 5, -5);
                        m_gcTrigger.m_sQuestNameA = "ate_chicken";
                        m_gcTrigger.m_eQuestStatusA = Types.EStatus._Done;
                        m_gcTrigger.m_qRewardB = new QuestReward(0, 0, 0);
                        m_gcTrigger.m_sQuestNameB = "ate_chicken";
                        m_gcTrigger.m_eQuestStatusB = Types.EStatus._Failed;

                        m_gcTalk.gameObject.SetActive(false);

                        break;
                }
            }
            
        }
    }
}
