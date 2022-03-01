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
            m_txtDialogText.text = SearchIndicator(m_sIndicators[0]);
            m_txtButtonA.text = SearchIndicator(m_sIndicators[1]);
            m_txtButtonB.text = SearchIndicator(m_sIndicators[2]);
            
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            
        }

        public void exitText()
        {
            Debug.Log("exitText");
            SceneManager.UnloadSceneAsync("NarrativeBox");
            Time.timeScale = 1f;
        }

        public void GiveRewardA()
        {
            m_txtDialogText.text = SearchIndicator("#OptionA");
            GameObject.FindWithTag("Player").gameObject.GetComponent<PlayerResources>().AddResources(m_gcRewardA.m_iMoney, m_gcRewardA.m_iReputation, m_gcRewardA.m_iBond);
        }

        public void GiveRewardB()
        {
            m_txtDialogText.text = SearchIndicator("#OptionB");
            GameObject.FindWithTag("Player").gameObject.GetComponent<PlayerResources>().AddResources(m_gcRewardB.m_iMoney, m_gcRewardB.m_iReputation, m_gcRewardB.m_iBond);
        }

        public string SearchIndicator(string indicator)
        {
            string content = "";

            for (int i = 0; i < m_sLines.Length; i++)
            {
                if (m_sLines[i].Contains(indicator))
                {
                    try
                    {
                       int j = 1;
                        while (!m_sLines[i + j].Contains("#"))
                        {
                            content += m_sLines[i + j] + "\n";
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
