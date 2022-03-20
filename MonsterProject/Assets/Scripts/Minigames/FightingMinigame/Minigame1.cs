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

        public SpriteRenderer m_gcEnemyRenderer;
        public SpriteRenderer m_gcPetRenderer;

        public Sprite m_gcPetIdle;
        public Sprite m_gcPetAttack;
        public Sprite m_gcPetHit;

        public Sprite m_gcEnemyIdle;
        public Sprite m_gcEnemyAttack;
        public Sprite m_gcEnemyHit;
        private bool m_bCanAct;
        void Start()
        {
            m_gcSpriteRenderer.sprite = m_gcAtkSprite;
            m_bIsMyTurn = true;
            m_bCanAct = true;
        }

        void Update()
        {
            m_gcEnemyBar.SetWidth(m_iEnemyHealth / 100f);
            m_gcPetBar.SetWidth(m_iPetHealth / 100f);

            if (Input.GetButtonDown("Fire2") && m_bCanAct)
            {
                if (m_bIsMyTurn)
                {
                    m_gcPetRenderer.sprite = m_gcPetAttack;
                }
                else
                {
                    m_gcEnemyRenderer.sprite = m_gcEnemyAttack;
                    m_gcPetRenderer.sprite = m_gcPetHit;
                }
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
                    m_gcEnemyRenderer.sprite = m_gcEnemyHit;
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
            m_bCanAct = false;
            m_gcMoveBetween.enabled = false;
            yield return new WaitForSeconds(1);
            m_gcMoveBetween.enabled = true;
            m_bCanAct = true;
            m_gcMoveBetween.Reset();
            m_bIsMyTurn = !m_bIsMyTurn;
            m_gcEnemyRenderer.sprite = m_gcEnemyIdle;
            m_gcPetRenderer.sprite = m_gcPetIdle;
        }

        IEnumerator EndDelay()
        {
            yield return new WaitForSeconds(2);
            GameManager.m_sDestination = "Yard_Fight";
            SceneManager.LoadScene("Yard");
        }
    }
}
