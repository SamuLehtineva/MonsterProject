using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class Minigame1 : MonoBehaviour
    {
        public MoveBetweenTransforms m_gcMoveBetween;
        public SpriteRenderer m_gcSpriteRenderer;
        public Sprite m_gcAtkSprite;
        public Sprite m_gcDefSprite;
        public int m_iEnemyHealth = 100;
        public int m_iPetHealth = 100;
        public bool m_bIsMyTurn;

        [SerializeField]
        UIBar m_gcEnemyBar;

        [SerializeField]
        UIBar m_gcPetBar;

        [SerializeField]
        TMP_Text m_txtTurnText;
        void Start()
        {
            m_gcSpriteRenderer.sprite = m_gcAtkSprite;
            m_bIsMyTurn = true;
        }

        void Update()
        {
            m_gcEnemyBar.SetWidth(m_iEnemyHealth / 100f);
            m_gcPetBar.SetWidth(m_iPetHealth / 100f);

            if (Input.GetButtonDown("Fire2"))
            {
                Action(m_gcMoveBetween.GetRatio());
            }

            if (m_bIsMyTurn)
            {
                m_txtTurnText.text = "Attack!";
                m_gcSpriteRenderer.sprite = m_gcAtkSprite;
            }
            else
            {
                m_txtTurnText.text = "Defend!";
                m_gcSpriteRenderer.sprite = m_gcDefSprite;
            }
            CheckWin();
        }

        public void Action(float ratio)
        {
            if (ratio < 0.6f && ratio > 0.4f)
            {

                if (m_bIsMyTurn)
                {
                    m_iEnemyHealth -= 50;
                }
                else
                {
                    m_iPetHealth -= 25;
                }
            } 
            else
            {
                if (!m_bIsMyTurn)
                {
                    m_iPetHealth -= 50;
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
                StartCoroutine(EndDelay());
            }
            else if (m_iPetHealth <= 0)
            {
                m_txtTurnText.text = "Defeat";
                m_gcMoveBetween.enabled = false;
                StartCoroutine(EndDelay());
            }
        }

        IEnumerator ActionDelay()
        {
            m_gcMoveBetween.enabled = false;
            yield return new WaitForSeconds(1);
            m_gcMoveBetween.enabled = true;
            m_gcMoveBetween.Reset();
            m_bIsMyTurn = !m_bIsMyTurn;
        }

        IEnumerator EndDelay()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Yard");
        }
    }
}
