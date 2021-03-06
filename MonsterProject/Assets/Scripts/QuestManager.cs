using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Linq;

namespace GA.MonsterProject
{
    [ExecuteInEditMode]
    public class QuestManager : MonoBehaviour, ISaveable
    {
        public int m_iEvolveTresh1 = 4;
        public int m_iEvolveTresh2 = 8;
        public QuestInfo[] m_aQuests;

        [field: SerializeField]
        private bool m_bStep1 = false;

        [field: SerializeField]
        private bool m_bStep2 = false;
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

            if (status == Types.EStatus._Done || status == Types.EStatus._Failed)
            {
                

                if (name == "evolve")
                {
                    UIManager.s_UIManager.Evolve1();
                }
                else if (name == "evolve2")
                {
                    UIManager.s_UIManager.Evolve2();
                }
                CheckProgress();
            }

            if (!GetQuestByName(name).m_bHidden && status != Types.EStatus._Done && status != Types.EStatus._Failed)
            {
                UIManager.s_UIManager.ToggleQuestLogIcon(true);
            }
        }

        public int QuestCountDone()
        {
            int count = 0;
            for (int i = 0; i < m_aQuests.Length; i++)
            {
                if ((m_aQuests[i].m_iStatus == Types.EStatus._Done || m_aQuests[i].m_iStatus == Types.EStatus._Failed) && !m_aQuests[i].m_bHidden)
                {
                    count++;
                }
            }
            return count;
        }

        public QuestInfo[] GetActiveQuests()
        {
            List<QuestInfo> Result = new List<QuestInfo>();
            foreach (QuestInfo quest in m_aQuests)
            {
                if ((quest.m_iStatus == Types.EStatus._Active || quest.m_iStatus == Types.EStatus._Completed) && !quest.m_bHidden)
                {
                    Result.Add(quest);
                }
            }

            return Result.ToArray();
        }

        public void CheckProgress()
        {
            int iProgress = QuestCountDone();

            if (iProgress >= m_iEvolveTresh1 && GetQuestByName("evolve").m_iStatus == Types.EStatus._Inactive)
            {
                SetQuestStatus("evolve", Types.EStatus._Active);
            } 
            else if (iProgress >= m_iEvolveTresh2 && GetQuestByName("evolve2").m_iStatus == Types.EStatus._Inactive)
            {
                SetQuestStatus("evolve2", Types.EStatus._Active);
            }

            if (iProgress > m_iEvolveTresh1 && !m_bStep1)
            {
                m_bStep1 = true;

                SetQuestStatus("fetch_flower", Types.EStatus._Inactive);

                if (GetQuestByName("deliver_package").m_iStatus == Types.EStatus._Failed)
                {
                    SetQuestStatus("marget_kill_jackalopes", Types.EStatus._Failed);
                }
                else
                {
                    SetQuestStatus("marget_kill_jackalopes", Types.EStatus._Inactive);
                }

                if (GetQuestByName("talk_well").m_iStatus == Types.EStatus._Failed)
                {
                    SetQuestStatus("find_lantern", Types.EStatus._Failed);
                }
                else
                {
                    SetQuestStatus("find_lantern", Types.EStatus._Inactive);
                }
            }

            if (iProgress > m_iEvolveTresh2 && !m_bStep2)
            {
                m_bStep2 = true;

                if (UIManager.s_UIManager.m_iForm == Types.EForm._Good)
                {
                    SetQuestStatus("move_rock", Types.EStatus._Inactive);
                }
                else if (UIManager.s_UIManager.m_iForm == Types.EForm._Bad)
                {
                    SetQuestStatus("ate_chicken", Types.EStatus._Inactive);
                }
            }

            if (GetQuestByName("move_rock").m_iStatus == Types.EStatus._Failed || GetQuestByName("move_rock").m_iStatus == Types.EStatus._Done)
			{
                SetQuestStatus("last", Types.EStatus._Active);
			}
            else if (GetQuestByName("ate_chicken").m_iStatus == Types.EStatus._Failed || GetQuestByName("ate_chicken").m_iStatus == Types.EStatus._Done)
			{
                SetQuestStatus("last", Types.EStatus._Active);
            }
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
            writer.WriteBool(m_bStep1);
            writer.WriteBool(m_bStep2);
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
            m_bStep1 = reader.ReadBool();
            m_bStep2 = reader.ReadBool();
        }
    }
}
