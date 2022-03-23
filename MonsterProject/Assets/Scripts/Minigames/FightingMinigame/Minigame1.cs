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
        public SpriteRenderer m_gcSpotRenderer;
        public SpriteRenderer m_gcIconRenderer;
        public Sprite m_gcAtkSprite;
        public Sprite m_gcDefSprite;

        [SerializeField]
        TMP_Text m_txtTurnText;
        public int m_iPetHealth = 100;

        [SerializeField]
        UIBar m_gcPetBar;
        public SpriteRenderer m_gcPetRenderer;
        public Sprite m_gcPetIdle;
        public Sprite m_gcPetAttack;
        public Sprite m_gcPetHit;

        public int m_iEnemyHealth = 100;

        [SerializeField]
        UIBar m_gcEnemyBar;
        public SpriteRenderer m_gcEnemyRenderer;
        public Sprite m_gcEnemyIdle;
        public Sprite m_gcEnemyAttack;
        public Sprite m_gcEnemyHit;
        public bool m_bIsMyTurn;
        private bool m_bCanAct;
        private float m_fSweetSpot;
        private float m_fSpotWidth;
        private AudioClipPlayer m_gcClipPlayer;
        void Start()
        {
            m_bIsMyTurn = true;
            m_bCanAct = true;
            m_fSweetSpot = 0.15f;
            m_gcClipPlayer = GetComponent<AudioClipPlayer>();
        }

        void Update()
        {
            m_gcEnemyBar.SetWidth(m_iEnemyHealth / 100f);
            m_gcPetBar.SetWidth(m_iPetHealth / 100f);
            ScaleIcon();
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
                m_gcIconRenderer.sprite = m_gcAtkSprite;
                m_fSpotWidth = 1f;
            }
            else
            {
                m_txtTurnText.text = "Defend!";
                m_gcIconRenderer.sprite = m_gcDefSprite;
            }
            CheckWin();
        }

        public void ScaleIcon()
        {
            if (m_bIsMyTurn)
            {
                m_fSpotWidth = Mathf.Lerp(0f, 1f, m_iEnemyHealth / 100f);
                if (m_fSpotWidth < 0.45f)
                {
                    m_fSpotWidth = 0.45f;
                }
                m_gcSpotRenderer.transform.localScale = new Vector3(m_fSpotWidth, 1f, 1f);
            }
            else
            {
                m_gcSpotRenderer.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            
        }

        public void Action(float ratio)
        {
            if (ratio < 0.5f + Mathf.Lerp(0f, m_fSweetSpot, m_fSpotWidth) && ratio > 0.5f - Mathf.Lerp(0f, m_fSweetSpot, m_fSpotWidth))
            {

                if (m_bIsMyTurn)
                {
                    m_gcEnemyRenderer.sprite = m_gcEnemyHit;
                    m_iEnemyHealth -= 50;
                    m_gcClipPlayer.PlayClip(0, 1f);
                }
                else
                {
                    m_iPetHealth -= 25;
                    m_gcClipPlayer.PlayClip(2, 0.5f);
                }
            } 
            else
            {
                if (!m_bIsMyTurn)
                {
                    m_iPetHealth -= 50;
                    m_gcClipPlayer.PlayClip(1, 1f);
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
