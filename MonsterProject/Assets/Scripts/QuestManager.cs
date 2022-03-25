using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    [ExecuteInEditMode]
    public class QuestManager : MonoBehaviour
    {
        QuestInfo[] m_aQuests;
        // Start is called before the first frame update
        public void OnValidate()
        {
            m_aQuests = GetComponentsInChildren<QuestInfo>();
        }
    }
}
