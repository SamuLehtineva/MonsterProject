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
        TMP_Text m_txtDialogText;

        [SerializeField]
        public int m_iStartingLine;

        [SerializeField]
        int m_iLineAmount;
        void Start()
        {
        
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

        public void GiveMoney(int amount)
        {
            GameObject.Find("Player").gameObject.GetComponent<PlayerResources>().AddResource(EResources.EResource._Money, amount);
        }

        public void GiveReputation(int amount)
        {
            GameObject.Find("Player").gameObject.GetComponent<PlayerResources>().AddResource(EResources.EResource._Reputation, amount);
        }

        public void exitText()
        {
            Debug.Log("exitText");
            SceneManager.UnloadSceneAsync("NarrativeBox");
            Time.timeScale = 1f;
        }
    }
}
