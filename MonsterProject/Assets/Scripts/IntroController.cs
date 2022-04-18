using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GA.MonsterProject
{
    public class IntroController : MonoBehaviour
    {
        [SerializeField]
        Sprite[] m_sSprites = new Sprite[8];

        [SerializeField]
        Image m_iImage;
        private int m_iCurrent = 0;

        void Update()
        {
            m_iImage.sprite = m_sSprites[m_iCurrent];
            if (Input.GetButtonDown("Fire1"))
            {
                m_iCurrent++;
                if (m_iCurrent >= m_sSprites.Length)
                {
                    SceneChanger.LoadLevel("Cabin");
                }
            }
        }
    }
}
