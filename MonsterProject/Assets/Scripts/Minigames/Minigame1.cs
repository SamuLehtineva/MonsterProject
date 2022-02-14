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

        [SerializeField]
        TMP_Text m_txtTurnText;
        void Start()
        {
            m_gcMaterial.color = Color.white;
            m_bIsMyTurn = true;
        }

        void Update()
        {
            m_txtEnemyHealthText.text = "Health: " + m_iEnemyHealth;
            m_txtPetHealthText.text = "Health: " + m_iPetHealth;

            if (Input.GetButtonDown("Fire1"))
            {
                Action(m_gcMoveBetween.GetRatio());
            }

            if (m_bIsMyTurn)
            {
                m_txtTurnText.text = "Attack!";
            }
            else
            {
                m_txtTurnText.text = "Defend!";
            }
            CheckWin();
        }

        public void Action(float ratio)
        {
            if (ratio < 0.6f && ratio > 0.4f)
            {
                m_gcMaterial.color = Color.green;

                if (m_bIsMyTurn)
                {
                    m_iEnemyHealth -= 50;
                    m_txtEnemyHealthText.color = Color.red;
                }
                else
                {
                    m_iPetHealth -= 25;
                    m_txtPetHealthText.color = Color.yellow;
                }
            } 
            else
            {
                m_gcMaterial.color = Color.red;
                
                if (m_bIsMyTurn)
                {
                    m_txtEnemyHealthText.color = Color.yellow;
                }
                else{
                    m_iPetHealth -= 50;
                    m_txtPetHealthText.color = Color.red;
                }
            }
            
            StartCoroutine(ActionDelay());
        }

        public void CheckWin()
        {
            if (m_iEnemyHealth <= 0)
            {
                m_txtTurnText.text = "Victory";
                m_gcMoveBetween.enabled = false;
            }
            else if (m_iPetHealth <= 0)
            {
                m_txtTurnText.text = "Defeat";
                m_gcMoveBetween.enabled = false;
            }
        }

        IEnumerator ActionDelay()
        {
            m_gcMoveBetween.enabled = false;
            yield return new WaitForSeconds(1);
            m_gcMoveBetween.enabled = true;
            m_gcMoveBetween.Reset();
            m_txtEnemyHealthText.color = Color.white;
            m_txtPetHealthText.color = Color.white;
            m_gcMaterial.color = Color.white;
            m_bIsMyTurn = !m_bIsMyTurn;
        }
    }
}
