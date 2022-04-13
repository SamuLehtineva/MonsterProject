using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class PlayerResources : MonoBehaviour, ISaveable
    {
        public int m_iMoney = 100;
        public int m_iReputation = 100;
        public int m_iBond = 50;
        public static PlayerResources s_CurrentResources;

        void Awake()
        {
            if (s_CurrentResources != null && s_CurrentResources != this)
            {
                GameObject.Destroy(this);
            }
            else
            {
                s_CurrentResources = this;
            }
        }
        
        public int GetResource(Types.EResource resource)
        {
            int iAmount = 0;
            switch (resource)
            {
                case Types.EResource._Money:
                    iAmount = m_iMoney;
                    break;

                case Types.EResource._Reputation:
                    iAmount = m_iReputation;
                    break;

                case Types.EResource._Bond:
                    iAmount = m_iBond;
                    break;
            }

            return iAmount;
        }

        public void AddResource(Types.EResource resource, int amount)
        {
            switch (resource)
            {
                case Types.EResource._Money:
                    m_iMoney += amount;

                    if (m_iMoney < 0)
                    {
                        m_iMoney = 0;
                    }

                    break;

                case Types.EResource._Reputation:
                    m_iReputation += amount;

                    if (m_iReputation < 0)
                    {
                        m_iReputation = 0;
                    }
                    else if (m_iReputation > 100)
                    {
                        m_iReputation = 100;
                    }

                    break;

                case Types.EResource._Bond:
                    m_iBond += amount;

                    if (m_iBond < 0)
                    {
                        m_iBond = 0;
                    }
                    else if (m_iBond > 100)
                    {
                        m_iBond = 100; 
                    }
                    break;
            }
        }

        public void AddResources(int money, int rep, int bond)
        {
            m_iMoney += money;
            if (m_iMoney < 0)
            {
                m_iMoney = 0;
            }

            m_iReputation += rep;
            if (m_iReputation < 0)
            {
                m_iReputation = 0;
            }

            m_iBond += bond;

            if (m_iBond < 0)
            {
                m_iBond = 0;
            }
            else if (m_iBond > 100)
            {
                m_iBond = 100; 
            }
        }

        public void AddResources(QuestReward reward)
        {
            m_iMoney += reward.m_iMoney;
            if (m_iMoney < 0)
            {
                m_iMoney = 0;
            }

            m_iReputation += reward.m_iReputation;
            if (m_iReputation < 0)
            {
                m_iReputation = 0;
            }

            m_iBond += reward.m_iBond;

            if (m_iBond < 0)
            {
                m_iBond = 0;
            }
            else if (m_iBond > 100)
            {
                m_iBond = 100; 
            }
        }

        public void Save(ISaveWriter writer)
        {
            writer.WriteInt(m_iMoney);
            writer.WriteInt(m_iBond);
            writer.WriteInt(m_iReputation);
        }

        public void Load(ISaveReader reader)
        {
            m_iMoney = reader.ReadInt();
            m_iBond = reader.ReadInt();
            m_iReputation = reader.ReadInt();
        }
    }
}
