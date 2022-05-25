using System.Collections;
using System.Collections.Generic;
using System;
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
        public GameObject FireBall;
        public bool m_bIsMyTurn;

        [Header("Pet")]
        public int m_iPetHealth = 100;

        [SerializeField]
        UIBar m_gcPetBar;
        public Animator m_gcPetAnimator;

        [Header("Enemy")]
        public int m_iEnemyHealth = 100;

        [SerializeField]
        UIBar m_gcEnemyBar;
        public Animator m_gcEnemyAnimator;

        private bool m_bCanAct;
        private float m_fSweetSpot;
        private float m_fSpotWidth;
        private AudioClipPlayer m_gcClipPlayer;
        private Sprite[] m_aPetSprites;
        private Sprite[] m_aEnemySpites;
        private QuestInfo m_gcCurrentQuest;
        void Start()
        {
            ChangeForm();
            m_bIsMyTurn = true;
            m_bCanAct = true;
            m_fSweetSpot = 0.15f;
            m_gcClipPlayer = GetComponent<AudioClipPlayer>();

            try {
                m_gcCurrentQuest = GameManager.m_qMinigameQuest;
            }
            catch (NullReferenceException e)
            {
                Debug.Log(e);
            }
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
                    m_gcPetAnimator.Play("attack");
                }
                else
                {
                    m_gcEnemyAnimator.Play("attack");
                    m_gcPetAnimator.Play("hurt");
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

        void ChangeForm()
        {
            GameObject pet = transform.Find("Teen").gameObject;
            if (UIManager.s_UIManager != null)
            {
                switch(UIManager.s_UIManager.m_iForm)
                {
                    case Types.EForm._Baby:
                        pet = transform.Find("Baby").gameObject;
                        break;
                    
                    case Types.EForm._Teen:
                        pet = transform.Find("Teen").gameObject;
                        break;
                    
                    case Types.EForm._Bad:
                        pet = transform.Find("Bad").gameObject;
                        break;

                    case Types.EForm._Good:
                        pet = transform.Find("Good").gameObject;
                        break;
                }
            }
            pet.gameObject.SetActive(true);
            m_gcPetAnimator = pet.GetComponent<Animator>();
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
                    m_gcEnemyAnimator.Play("hurt");
                    m_iEnemyHealth -= 50;
                    m_gcClipPlayer.PlayClip(0, 1f);
                    Instantiate(FireBall);
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
                if (m_gcCurrentQuest != null)
                {
                    if (m_gcCurrentQuest.m_iStatus == Types.EStatus._Active)
                    {
                        UIManager.s_UIManager.m_gcQuestManager.SetQuestStatus(m_gcCurrentQuest.m_sName, Types.EStatus._Completed);
                    }
                }
                StartCoroutine(EndDelay());
            }
            else if (m_iPetHealth <= 0)
            {
                m_txtTurnText.text = "Defeat";
                m_gcMoveBetween.enabled = false;
                //PlayerResources.s_CurrentResources
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
            m_gcEnemyAnimator.Play("idle");
            m_gcPetAnimator.Play("idle");
        }

        IEnumerator EndDelay()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(GameManager.m_sDestinationScene);
        }
    }
}
