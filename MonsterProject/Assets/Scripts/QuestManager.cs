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
        
        public QuestInfo GetQuestByName(string name)
        {
            foreach (QuestInfo quest in m_aQuests)
            {
                if (quest.m_sName.Equals(name))
                {
                    return quest;
                }
            }
            return null;
        }

        public void SetQuestStatus(string name, Types.EStatus status)
        {
            foreach (QuestInfo quest in m_aQuests)
            {
                if (quest.m_sName.Equals(name))
                {
                    quest.m_iStatus = status;
                }
            }
        }
    }
}
