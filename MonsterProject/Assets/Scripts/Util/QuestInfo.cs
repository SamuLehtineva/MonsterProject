using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class QuestInfo : MonoBehaviour
    {
        public string m_sName;
        public Types.EStatus m_iStatus = Types.EStatus._Inactive;
        public string m_sDescription;

        public void OnValidate()
        {
            gameObject.name = m_sName;
        }
    }
}