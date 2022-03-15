using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        GameObject m_oButtons;

        public QuestReward m_gcRewardA;
        public QuestReward m_gcRewardB;

        private ReadTextFile m_ReadText;
        private string[] m_sLines;
        private int m_iCurrentLine;
        private string[] m_sIndicators = {"#Start", "#ButtonA", "#ButtonB", "#OptionA", "#OptionB", "#ButtonEnd"};
        private bool m_bCanContinue;
        private bool m_bCanEnd;
        public static string m_sFileName = "dialog";

        void Start()
        {
            if (m_sFileName != null)
            {
                m_ReadText = new ReadTextFile(m_sFileName);
                m_sLines = m_ReadText.GetLines();
            }

            m_bCanContinue = false;
            m_bCanEnd = false;
            m_iCurrentLine = 0;

            ShowDialog();
            m_oButtons.SetActive(false);
            
            m_txtButtonA.text = SearchIndicator(m_sIndicators[1])[0].ToString();
            m_txtButtonB.text = SearchIndicator(m_sIndicators[2])[0].ToString();
            
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire2"))
            {
                
                if (m_bCanContinue)
                {
                    Debug.Log("Jee");
                    m_iCurrentLine += 3;
                    m_bCanContinue = false;
                    ShowDialog();
                }
                else if (m_bCanEnd)
                {
                    Debug.Log("End");
                }
            }
        }

        public void StartDialog(string sFileName)
        {
            m_ReadText = new ReadTextFile(sFileName);
            m_sLines = m_ReadText.GetLines();
        }

        public void ShowDialog()
        {
            m_txtDialogText.text = "";
            ArrayList sLines = SearchIndicator("#Start");

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
            }
            else
            {
                m_oButtons.SetActive(true);
            }

        }

        public void exitText()
        {
            Debug.Log("exitText");
            SceneManager.UnloadSceneAsync("NarrativeBox");
            Time.timeScale = 1f;
        }

        public void GiveRewardA()
        {
            m_txtDialogText.text = SearchIndicator("#OptionA")[0].ToString();
            m_bCanEnd = true;
            PlayerResources.s_CurrentResources.AddResources(m_gcRewardA);
        }

        public void GiveRewardB()
        {
            m_txtDialogText.text = SearchIndicator("#OptionB")[0].ToString();
            m_bCanEnd = true;
            PlayerResources.s_CurrentResources.AddResources(m_gcRewardB);
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
