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
        EResources.EResource m_eResource;

        void Update()
        {
            m_txtMoneyText.text = "Money : " + m_gcPlayerResources.GetResource(EResources.EResource._Money);
            m_txtReputationText.text = "Reputation : " + m_gcPlayerResources.GetResource(EResources.EResource._Reputation);

            if (Input.GetButtonDown("Fire3"))
            {
                m_gcPlayerResources.AddResource(m_eResource, 10);
            }
        }
    }
}
