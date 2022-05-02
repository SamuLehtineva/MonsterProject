using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class Npc_Randvi : MonoBehaviour
    {
        [SerializeField]
        Npc_Talk m_gcTalk;

        void Update()
        {
            Types.EStatus iEStatus = UIManager.s_UIManager.m_gcQuestManager.GetQuestByName("deliver_package").m_iStatus;
            switch (iEStatus)
            {
                case Types.EStatus._Inactive:
                    m_gcTalk.m_sFileName = "randvi_inactive";

                    break;

                case Types.EStatus._Active:
                    m_gcTalk.m_sFileName = "randvi_active";
                    m_gcTalk.ShowIcon(false);
                    m_gcTalk.gameObject.SetActive(false);

                    break;

                case Types.EStatus._Completed:
                    m_gcTalk.m_sFileName = "randvi_completed";
                    m_gcTalk.m_qRewardA = new QuestReward(0, 20, 0);
                    m_gcTalk.m_eQuestStatusA = Types.EStatus._Done;
                    m_gcTalk.m_bRewardTalk = true;
                    m_gcTalk.gameObject.SetActive(true);

                    break;

                case Types.EStatus._Done:
                    m_gcTalk.m_sFileName = "randvi_done";
                    m_gcTalk.m_bRewardTalk = false;
                    m_gcTalk.ShowIcon(false);

                    break;

                case Types.EStatus._Failed:
                    m_gcTalk.m_sFileName = "randvi_failed";
                    m_gcTalk.ShowIcon(false);

                    break;
            }
        }
    }
}
