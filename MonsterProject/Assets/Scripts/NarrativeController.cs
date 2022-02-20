using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class NarrativeController : MonoBehaviour
    {
        [SerializeField]
        ReadTextFile m_gcReadText;

        [SerializeField]
        QuestController m_gcQuestController;

        [SerializeField]
        TMP_Text m_txtDialogText;

        [SerializeField]
        public int m_iStartingLine;

        [SerializeField]
        int m_iLineAmount;

        private QuestReward m_gcRewardA;
        private QuestReward m_gcRewardB;
        void Start()
        {
            m_gcReadText.m_sFileName = "dialog.txt";
            m_gcRewardA = m_gcQuestController.m_qRewardA;
            m_gcRewardB = m_gcQuestController.m_qRewardB;

        }

        // Update is called once per frame
        void Update()
        {
            UpdateText(m_iStartingLine, m_iLineAmount);
        }

        public void UpdateText(int startingLine, int lineAmount)
        {
            m_txtDialogText.text = "";
            for (int i = 0; i < lineAmount; i++)
            {
                m_txtDialogText.text += m_gcReadText.GetLine(startingLine + i) + "\n";
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
