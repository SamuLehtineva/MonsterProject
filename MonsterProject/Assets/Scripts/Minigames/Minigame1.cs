using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GA.MonsterProject
{
    public class Minigame1 : MonoBehaviour
    {
        public MoveBetweenTransforms m_gcMoveBetween;
        public Material m_gcMaterial;
        public int m_iEnemyHealth = 100;
        public int m_iPetHealth = 100;
        public bool m_bIsMyTurn;

        [SerializeField]
        TMP_Text m_txtEnemyHealthText;

        [SerializeField]
        TMP_Text m_txtPetHealthText;
        private bool m_bPressed;
        void Start()
        {
            m_gcMaterial.color = Color.black;
            m_bPressed = false;
        }

        void Update()
        {
            m_txtEnemyHealthText.text = "Health: " + m_iEnemyHealth;
            m_txtPetHealthText.text = "Health: " + m_iPetHealth;

            if (Input.GetButtonDown("Fire1"))
            {
                if (m_gcMoveBetween.GetRatio() < 0.6f && m_gcMoveBetween.GetRatio() > 0.4f)
                {
                    m_gcMaterial.color = Color.green;

                    m_iEnemyHealth -= 50;
                    StartCoroutine(ActionDelay());
                }
                else{
                    m_gcMaterial.color = Color.red;
                    
                }
                m_bPressed = !m_bPressed;
            }
            
        }

        IEnumerator ActionDelay()
        {
            m_gcMoveBetween.enabled = false;
            m_txtEnemyHealthText.color = Color.red;
            yield return new WaitForSeconds(1);
            m_gcMoveBetween.enabled = true;
            m_gcMoveBetween.Reset();
            m_txtEnemyHealthText.color = Color.white;
        }
    }
}
