using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GA.MonsterProject
{
    public class IntroController : MonoBehaviour
    {
        private int m_iCurrent = 1;

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                m_iCurrent++;
                
                if (m_iCurrent == 9)
                {
                    SceneChanger.LoadLevel("Name");
                }
                else
                {
                    foreach (Transform child in transform)
                    {
                        if (child.name != "Continue")
                        {
                            child.gameObject.SetActive(false);
                        }
                    }
                    transform.Find(m_iCurrent.ToString()).gameObject.SetActive(true);
                }
            }
        }
    }
}
