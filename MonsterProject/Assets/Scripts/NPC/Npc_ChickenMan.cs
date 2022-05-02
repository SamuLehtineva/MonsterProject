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
            Types.EStatus iEStatus = UIManager.s_UIManager.m_gcQuestManager.GetQuestByName("fetch_helga").m_iStatus;
            switch (iEStatus)
            {
                case Types.EStatus._Inactive:
                    m_gcTrigger.gameObject.SetActive(true);
                    m_gcTrigger.m_sFileName = "fetch_helga_inactive";
                    m_gcTrigger.m_bRewardTalk = false;

                    m_gcTalk.gameObject.SetActive(false);

                    break;

                case Types.EStatus._Active:
                    m_gcTrigger.gameObject.SetActive(false);

                    m_gcTalk.gameObject.SetActive(true);
                    m_gcTalk.m_sFileName = "fetch_helga_active";
                    m_gcTalk.m_bRewardTalk = false;
                    m_gcTalk.ShowIcon(false);

                    break;
                
                case Types.EStatus._Completed:
                    m_gcTrigger.gameObject.SetActive(false);

                    m_gcTalk.gameObject.SetActive(true);
                    m_gcTalk.m_sFileName = "fetch_helga_complete";
                    m_gcTalk.m_bRewardTalk = true;
                    m_gcTalk.ShowIcon(true);

                    break;
                
                case Types.EStatus._Done:
                    m_gcTrigger.gameObject.SetActive(false);

                    m_gcTalk.gameObject.SetActive(true);
                    m_gcTalk.m_sFileName = "fetch_helga_done";
                    m_gcTalk.m_bRewardTalk = false;
                    m_gcTalk.ShowIcon(false);

                    break;

                case Types.EStatus._Failed:
                    m_gcTrigger.gameObject.SetActive(false);

                    m_gcTalk.gameObject.SetActive(true);
                    m_gcTalk.m_sFileName = "fetch_helga_failed";
                    m_gcTalk.m_bRewardTalk = false;
                    m_gcTalk.ShowIcon(false);

                    break;
            }
        }
    }
}
