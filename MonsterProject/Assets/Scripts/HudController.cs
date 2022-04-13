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
        UIBar m_gcRepBar;

        [SerializeField]
        UIBar m_gcBondBar;

        void Update()
        {
            m_txtMoneyText.text = "x " + PlayerResources.s_CurrentResources.GetResource(Types.EResource._Money).ToString();
            m_gcRepBar.SetWidth(PlayerResources.s_CurrentResources.GetResource(Types.EResource._Reputation) / (float) 100f);
            m_gcBondBar.SetWidth(PlayerResources.s_CurrentResources.GetResource(Types.EResource._Bond) / (float) 100f);
        }
    }
}
