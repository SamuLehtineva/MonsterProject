using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class PlayerResources : MonoBehaviour
    {
        public int m_iMoney = 100;

        public int m_iReputation = 100;

        public int m_iBond = 50;
        
        public int GetResource(EResources.EResource resource)
        {
            int iAmount = 0;
            switch (resource)
            {
                case EResources.EResource._Money:
                    iAmount = m_iMoney;
                    break;

                case EResources.EResource._Reputation:
                    iAmount = m_iReputation;
                    break;

                case EResources.EResource._Bond:
                    iAmount = m_iBond;
                    break;
            }

            return iAmount;
        }

        public void AddResource(EResources.EResource resource, int amount)
        {
            switch (resource)
            {
                case EResources.EResource._Money:
                    m_iMoney += amount;

                    if (m_iMoney < 0)
                    {
                        m_iMoney = 0;
                    }

                    break;

                case EResources.EResource._Reputation:
                    m_iReputation += amount;

                    if (m_iReputation < 0)
                    {
                        m_iReputation = 0;
                    }

                    break;

                case EResources.EResource._Bond:
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
    }
}