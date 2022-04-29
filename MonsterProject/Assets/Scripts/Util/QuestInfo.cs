using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class QuestInfo : MonoBehaviour, ISaveable
    {
        public string m_sName;
        public Types.EStatus m_iStatus = Types.EStatus._Inactive;
        public string m_sDescription;
        public int m_iCurrentProgress = 0;
        public int m_iMaxProgress = 1;

        public void OnValidate()
        {
            gameObject.name = m_sName;
            CheckProgress();
        }

        void Update()
        {
            CheckProgress();
        }

        void CheckProgress()
        {
            if (m_iStatus == Types.EStatus._Completed)
            {
                if (m_iCurrentProgress < m_iMaxProgress)
                {
                    m_iCurrentProgress++;
                }
                
                if (m_iCurrentProgress < m_iMaxProgress)
                {
                    m_iStatus = Types.EStatus._Active;
                }
            }
        }

        /*
        Saves current status
        */
        public void Save(ISaveWriter writer)
        {
            writer.WriteStatus(m_iStatus);
        }

        /*
        Loads status from file
        */
        public void Load(ISaveReader reader)
        {
            m_iStatus = reader.ReadStatus();
        }
    }
}
