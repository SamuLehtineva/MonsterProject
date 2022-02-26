using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using GA.MonsterProject;

namespace GA.MonsterProject
{
    public class NarrativeController : MonoBehaviour
    {
        [SerializeField]
        TMP_Text m_txtDialogText;

        [SerializeField]
        TextMeshProUGUI m_txtButtonA;

        [SerializeField]
        TextMeshProUGUI m_txtButtonB;

        [SerializeField]
        public int m_iStartingLine;

        [SerializeField]
        int m_iLineAmount;

        public static QuestReward m_gcRewardA;
        public static QuestReward m_gcRewardB;

        private ReadTextFile m_ReadText;
        private string[] m_sLines;
        private string[] m_sIndicators = {"#Start", "#ButtonA", "#ButtonB", "#OptionA", "#OptionB", "#ButtonEnd"};
        public static string m_sFileName = "dialog2.txt";
        void Start()
        {
            if (m_sFileName != null)
            {
                m_ReadText = new ReadTextFile(m_sFileName);
                m_sLines = m_ReadText.GetLines();
            }
            UpdateText(m_iStartingLine, m_iLineAmount);
            CheckLine();
            
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            
        }

        public void UpdateText(int startingLine, int lineAmount)
        {
            m_txtDialogText.text = "";
            for (int i = 0; i < lineAmount; i++)
            {
                m_txtDialogText.text += m_sLines[startingLine -1 + i] + "\n";
            }
        }

        public void SetStartingLine(int startingLine)
        {
            m_iStartingLine = startingLine;
            UpdateText(m_iStartingLine, m_iLineAmount);
        }

        public void SetLineAmount(int lineAmount)
        {
            m_iLineAmount = lineAmount;
            UpdateText(m_iStartingLine, m_iLineAmount);
        }

        public void exitText()
        {
            Debug.Log("exitText");
            SceneManager.UnloadSceneAsync("NarrativeBox");
            Time.timeScale = 1f;
        }

        public void GiveRewardA()
        {
            GameObject.FindWithTag("Player").gameObject.GetComponent<PlayerResources>().AddResources(m_gcRewardA.m_iMoney, m_gcRewardA.m_iReputation, m_gcRewardA.m_iBond);
        }

        public void GiveRewardB()
        {
            GameObject.FindWithTag("Player").gameObject.GetComponent<PlayerResources>().AddResources(m_gcRewardB.m_iMoney, m_gcRewardB.m_iReputation, m_gcRewardB.m_iBond);
        }

        public void CheckLine()
        {
            for (int i = 0; i < m_sLines.Length; i++)
            {
                for (int j = 0; j < m_sIndicators.Length; j++)
                {
                    if (m_sLines[i].Contains(m_sIndicators[j]))
                    {
                        try
                        {
                            switch (j)
                            {
                                case 1:
                                    m_txtButtonA.text = m_sLines[i+1];
                                    break;

                                case 2:
                                    m_txtButtonB.text = m_sLines[i+1];
                                    break;
                            }
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Debug.Log(m_sLines[i] + " is an indicator. The next line should contain text that can be used by the specified object");
                            Debug.Log(e);
                        }
                    }
                }
                /*Debug.Log(m_sLines[i]);
                if (m_sLines[i].Contains("#ButtonA"))
                {
                    try
                    {
                        m_txtButtonA.text = m_sLines[i+1];
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        m_txtButtonA.text = "Option A";
                        Debug.Log(m_sLines[i] + " is an indicator. The next line should contain text that can be used by the specified object");
                        Debug.Log(e);
                    }
                    
                }*/
            }
        }
    }
}
