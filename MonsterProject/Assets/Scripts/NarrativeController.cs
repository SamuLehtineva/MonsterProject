using System.Collections;
using System.Collections.Generic;
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
        public int m_iStartingLine;

        [SerializeField]
        int m_iLineAmount;

        public static QuestReward m_gcRewardA;
        public static QuestReward m_gcRewardB;

        private ReadTextFile m_ReadText;
        private string[] m_sLines;
        public static string m_sFileName = "dialog.txt";
        void Start()
        {
            if (m_sFileName != null)
            {
                m_ReadText = new ReadTextFile(m_sFileName);
            }
            
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            UpdateText(m_iStartingLine, m_iLineAmount);
        }

        public void UpdateText(int startingLine, int lineAmount)
        {
            m_txtDialogText.text = "";
            for (int i = 0; i < lineAmount; i++)
            {
                m_txtDialogText.text += m_ReadText.GetLine(startingLine + i) + "\n";
            }
        }

        public void SetStartingLine(int startingLine)
        {
            m_iStartingLine = startingLine;
        }

        public void SetLineAmount(int lineAmount)
        {
            m_iLineAmount = lineAmount;
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
    }
}
