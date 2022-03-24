using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GA.MonsterProject
{
    public class HudController : MonoBehaviour
    {
        [SerializeField]
        TMP_Text m_txtMoneyText;

        [SerializeField]
        TMP_Text m_txtReputationText;

        [SerializeField]
        UIBar m_gcBondBar;

        void Update()
        {
            m_txtMoneyText.text = "x " + PlayerResources.s_CurrentResources.GetResource(Types.EResource._Money).ToString();
            m_txtReputationText.text = "Reputation : " + PlayerResources.s_CurrentResources.GetResource(Types.EResource._Reputation);
            m_gcBondBar.SetWidth(PlayerResources.s_CurrentResources.GetResource(Types.EResource._Bond) / (float) 100f);
        }
    }
}
