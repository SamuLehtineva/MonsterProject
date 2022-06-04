using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class DialogController : MonoBehaviour
    {
        [SerializeField]
        TMP_Text m_txtDialogText;

        [SerializeField]
        TextMeshProUGUI m_txtButtonA;

        [SerializeField]
        TextMeshProUGUI m_txtButtonB;

        [SerializeField]
        TMP_Text m_txtNameText;

        [SerializeField]
        Image m_iContinue;

        [SerializeField]
        GameObject m_oButtons;

        public QuestReward m_gcRewardA;
        public QuestReward m_gcRewardB;

        private ReadTextFile m_ReadText;
        private string[] m_sLines;
        private int m_iCurrentLine;
        private string m_sCurrentIndicator;
        private string[] m_sIndicators = {"#Start", "#ButtonA", "#ButtonB", "#OptionA", "#OptionB", "#ButtonEnd"};
        private bool m_bCanContinue;
        private bool m_bCanEnd;
        public static string m_sFileName = "dialog";
        INpc m_gcNpc;

        void Update()
        {
            if (m_bCanContinue || m_bCanEnd)
            {
                m_iContinue.gameObject.SetActive(true);
            }
            else
            {
                m_iContinue.gameObject.SetActive(false);
            }
            if (Input.GetButtonDown("Fire1"))
            {
                if (m_bCanContinue)
                {
                    m_iCurrentLine += 3;
                    m_bCanContinue = false;
                    ShowDialog();
                }
                else if (m_bCanEnd)
                {
                    EndDialog();
                }
            }
        }

        public void StartDialog(INpc npc)
        {
            m_gcNpc = npc;
            m_ReadText = new ReadTextFile(npc.m_sFileName);
            m_txtNameText.text = m_gcNpc.m_sName.Replace("!MonsterName!", GameManager.m_sPetName);
            m_sLines = m_ReadText.GetLines();

            m_bCanContinue = false;
            m_bCanEnd = false;
            m_iCurrentLine = 0;
            m_sCurrentIndicator = "#Start";
            m_oButtons.SetActive(false);
            ShowDialog();
        }

        public void SetRewards (QuestReward rewardA, QuestReward rewardB)
        {
            m_gcRewardA = rewardA;
            m_gcRewardB = rewardB;
        }

        public void ShowDialog()
        {
            m_txtDialogText.text = "";
            ArrayList sLines = SearchIndicator(m_sCurrentIndicator);

            for (int i = m_iCurrentLine; i < m_iCurrentLine + 3 && i < sLines.Count; i++)
            {
                if (!String.IsNullOrWhiteSpace(sLines[i].ToString()))
                {
                    m_txtDialogText.text += sLines[i] + "\n";
                }
            }

            if (sLines.Count > (m_iCurrentLine + 3))
            {
                m_bCanContinue = true;
                Debug.Log("lines");
            }
            else
            {
                CheckForButtons();
            }
        }

        public void CheckForButtons()
        {
            if (SearchIndicator("#ButtonA").Count > 0 && m_sCurrentIndicator == "#Start")
            {
                m_txtButtonA.text = SearchIndicator("#ButtonA")[0].ToString();
                m_txtButtonB.text = SearchIndicator("#ButtonB")[0].ToString();
                m_oButtons.SetActive(true);
                
                if (m_gcRewardA != null && PlayerResources.s_CurrentResources.m_iMoney + m_gcRewardA.m_iMoney < 0)
                {
                    m_oButtons.transform.Find("Button1A").GetComponent<Button>().interactable = false;
                }
                else
                {
                    m_oButtons.transform.Find("Button1A").GetComponent<Button>().interactable = true;
                }

                if (m_gcRewardB != null && PlayerResources.s_CurrentResources.m_iMoney + m_gcRewardB.m_iMoney < 0)
                {
                    m_oButtons.transform.Find("Button1B").GetComponent<Button>().interactable = false;
                }
                else
                {
                    m_oButtons.transform.Find("Button1B").GetComponent<Button>().interactable = true;
                }
            }
            else
            {
                m_bCanEnd = true;
            }
        }

        public void EndDialog()
        {
            m_gcNpc.DialogEnd();
            m_gcNpc = null;
            m_gcRewardA = null;
            m_gcRewardB = null;
            gameObject.SetActive(false);
            GameManager.s_GameManager.PlayerCanMove(true);
        }

        public void PickOptionA()
        {
            //m_txtDialogText.text = SearchIndicator("#OptionA")[0].ToString();
            m_sCurrentIndicator = "#OptionA";
            m_iCurrentLine = 0;
            m_bCanContinue = false;
            ShowDialog();
            m_gcNpc.PickOptionA();
            m_bCanEnd = true;
        }

        public void PickOptionB()
        {
            m_sCurrentIndicator = "#OptionB";
            m_iCurrentLine = 0;
            m_bCanContinue = false;
            ShowDialog();
            m_gcNpc.PickOptionB();
            m_bCanEnd = true;
        }

        public ArrayList SearchIndicator(string indicator)
        {
            ArrayList content = new ArrayList();

            for (int i = 0; i < m_sLines.Length; i++)
            {
                if (m_sLines[i].Contains(indicator))
                {
                    try
                    {
                       int j = 1;
                        while (!m_sLines[i + j].Contains("#"))
                        {
                            content.Add(m_sLines[i + j]);
                            j++;
                        } 
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Debug.Log(m_sLines[i] + " is an indicator. The next line(s) should contain text that can be used by the specified object");
                        Debug.Log(e);
                    }
                    
                }
            }
            return content;
        }
    }
}
