using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class Npc_CabinLady : MonoBehaviour
    {
        [SerializeField]
        Npc_Talk m_gcTalk;

        void Start()
        {
            if (UIManager.s_UIManager.m_gcQuestManager.GetQuestByName("talk_well").m_iStatus == Types.EStatus._Done)
            {
                Destroy(this.gameObject);
                Debug.Log("kill");
            }
        }

        void Update()
        {
            Types.EStatus iEStatus = UIManager.s_UIManager.m_gcQuestManager.GetQuestByName("talk_well").m_iStatus;
            switch (iEStatus)
            {
                case Types.EStatus._Active:
                    m_gcTalk.ShowIcon(true);

                    break;
                    
                case Types.EStatus._Done:
                    if (m_gcTalk.gameObject.activeSelf)
                    {
                        m_gcTalk.Kill();
                    }

                    break;
            }
        }
    }
}
