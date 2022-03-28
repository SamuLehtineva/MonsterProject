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

        void Start()
        {
            
        }

        void Update()
        {
            if (!m_gcTrigger.gameObject.activeInHierarchy && !m_bTriggered)
            {
                m_gcTalk.gameObject.SetActive(true);
                m_bTriggered = true;
            }
        }
    }
}
