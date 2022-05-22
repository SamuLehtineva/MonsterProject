using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class Npc_Jens : MonoBehaviour
    {
        [SerializeField]
        Npc_Talk m_gcTalk;

        void Update()
        {
            Types.EStatus iEStatus = UIManager.s_UIManager.m_gcQuestManager.GetQuestByName("move_rock").m_iStatus;
            switch (iEStatus)
            {
                case Types.EStatus._Disabled:
                    m_gcTalk.gameObject.SetActive(false);
                    m_gcTalk.ShowIcon(false);
                    break;

                case Types.EStatus._Inactive:
                    m_gcTalk.m_sFileName = "move_rock/inactive";
                    m_gcTalk.gameObject.SetActive(true);

                    break;

                case Types.EStatus._Active:
                    m_gcTalk.gameObject.SetActive(false);
                    m_gcTalk.ShowIcon(false);

                    break;

                case Types.EStatus._Completed:
                    m_gcTalk.gameObject.SetActive(false);

                    break;

                case Types.EStatus._Done:
                    m_gcTalk.m_sFileName = "move_rock/done";
                    m_gcTalk.m_bRewardTalk = false;
                    m_gcTalk.ShowIcon(false);

                    break;

                case Types.EStatus._Failed:
                    m_gcTalk.gameObject.SetActive(false);
                    m_gcTalk.ShowIcon(false);

                    break;
            }
        }
    }
}
