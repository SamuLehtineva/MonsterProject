using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GA.MonsterProject
{
    public class HudController : MonoBehaviour
    {
        public PlayerResources m_gcPlayerResources;

        [SerializeField]
        TMP_Text m_txtMoneyText;

        [SerializeField]
        TMP_Text m_txtReputationText;

        [SerializeField]
        UIBar m_gcBondBar;

        void Update()
        {
            m_txtMoneyText.text = "Money : " + m_gcPlayerResources.GetResource(EResources.EResource._Money);
            m_txtReputationText.text = "Reputation : " + m_gcPlayerResources.GetResource(EResources.EResource._Reputation);
            m_gcBondBar.SetWidth(m_gcPlayerResources.GetResource(EResources.EResource._Bond) / (float) 100f);
        }
    }
}
