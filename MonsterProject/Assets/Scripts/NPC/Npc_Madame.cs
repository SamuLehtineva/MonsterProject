using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class Npc_Madame : MonoBehaviour
    {
        [SerializeField]
        Npc_Talk m_gcTalk;

        void Update()
        {
            Types.EStatus iEStatus = UIManager.s_UIManager.m_gcQuestManager.GetQuestByName("move_rock").m_iStatus;
            if (iEStatus != Types.EStatus._Active)
            {
                iEStatus = UIManager.s_UIManager.m_gcQuestManager.GetQuestByName("marget_kill_jackalopes").m_iStatus;
                switch (iEStatus)
                {
                    case Types.EStatus._Disabled:
                        m_gcTalk.gameObject.SetActive(false);
                        m_gcTalk.ShowIcon(false);
                        break;

                    case Types.EStatus._Inactive:
                        m_gcTalk.m_sFileName = "madame_innkeep_inactive";
                        m_gcTalk.gameObject.SetActive(true);

                        break;

                    case Types.EStatus._Active:
                        m_gcTalk.m_sFileName = "madame_innkeep_active";
                        m_gcTalk.ShowIcon(false);

                        break;

                    case Types.EStatus._Completed:
                        m_gcTalk.m_sFileName = "madame_innkeep_completed";
                        m_gcTalk.m_qRewardA = new QuestReward(10, 10, -10);
                        m_gcTalk.m_eQuestStatusA = Types.EStatus._Done;
                        m_gcTalk.m_bRewardTalk = true;

                        break;

                    case Types.EStatus._Done:
                        m_gcTalk.m_sFileName = "madame_innkeep_done";
                        m_gcTalk.m_bRewardTalk = false;
                        m_gcTalk.ShowIcon(false);

                        break;

                    case Types.EStatus._Failed:
                        m_gcTalk.m_sFileName = "madame_innkeep_failed";
                        m_gcTalk.ShowIcon(false);

                        break;
                }
            }
            else
            {
                m_gcTalk.gameObject.SetActive(true);
                m_gcTalk.m_sFileName = "move_rock/active";
                m_gcTalk.ShowIcon(true);
                m_gcTalk.m_qRewardA = new QuestReward(0, 10, 0);
                m_gcTalk.m_eQuestStatusA = Types.EStatus._Done;
                m_gcTalk.m_sQuestNameA = "move_rock";
                m_gcTalk.m_bRewardTalk = true;
            }
        }
    }
}
