using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class Npc_Inger : MonoBehaviour
    {
        [SerializeField]
        Npc_Talk m_gcTalk;

        void Update()
        {
            Types.EStatus iEStatus = UIManager.s_UIManager.m_gcQuestManager.GetQuestByName("find_lantern").m_iStatus;
            switch (iEStatus)
            {
                case Types.EStatus._Disabled:
                    m_gcTalk.gameObject.SetActive(false);
                    m_gcTalk.ShowIcon(false);
                    break;

                case Types.EStatus._Inactive:
                    m_gcTalk.m_sFileName = "find_lantern/inactive";

                    break;

                case Types.EStatus._Active:
                    m_gcTalk.m_sFileName = "find_lantern/active";
                    m_gcTalk.ShowIcon(false);

                    break;

                case Types.EStatus._Completed:
                    m_gcTalk.m_sFileName = "find_lantern/completed";
                    m_gcTalk.m_qRewardA = new QuestReward(0, 20, -30);
                    m_gcTalk.m_eQuestStatusA = Types.EStatus._Done;
                    m_gcTalk.m_bRewardTalk = true;
                    m_gcTalk.ShowIcon(true);

                    break;

                case Types.EStatus._Done:
                    m_gcTalk.m_sFileName = "find_lantern/done";
                    m_gcTalk.m_bRewardTalk = false;
                    m_gcTalk.ShowIcon(false);

                    break;

                case Types.EStatus._Failed:
                    m_gcTalk.m_sFileName = "find_lantern/failed";
                    m_gcTalk.m_qRewardB = new QuestReward(0, -10, 10);
                    m_gcTalk.ShowIcon(false);

                    break;
            }
        }
    }
}
