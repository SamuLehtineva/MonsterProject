using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    [ExecuteInEditMode]
    public class QuestManager : MonoBehaviour, ISaveable
    {
        QuestInfo[] m_aQuests;
        // Start is called before the first frame update
        public void OnValidate()
        {
            m_aQuests = GetComponentsInChildren<QuestInfo>();
        }

        void Awake()
        {
            if (m_aQuests == null)
            {
                m_aQuests = GetComponentsInChildren<QuestInfo>();
            }
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

        public int QuestCountDone()
        {
            int count = 0;
            for (int i = 0; i < m_aQuests.Length; i++)
            {
                if (m_aQuests[i].m_iStatus == Types.EStatus._Done && m_aQuests[i].m_sName != "none")
                {
                    count++;
                }
            }
            return count;
        }

        /*
        Calls the Save method on all quests
        */
        public void Save(ISaveWriter writer)
        {
            foreach (var quest in m_aQuests)
            {
                quest.Save(writer);
            }
        }

        /*
        Calls the load method on all quests
        */
        public void Load(ISaveReader reader)
        {
            foreach (QuestInfo quest in m_aQuests)
            {
                quest.Load(reader);
            }
        }
    }
}
