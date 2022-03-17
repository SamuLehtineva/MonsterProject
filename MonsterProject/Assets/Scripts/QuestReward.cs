using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    [System.Serializable]
    public class QuestReward
    {
        public int m_iMoney;
        public int m_iReputation;
        public int m_iBond;

        public QuestReward (int money, int reputation, int bond)
        {
            m_iMoney = money;
            m_iReputation = reputation;
            m_iBond = bond;
        }
    }
}
