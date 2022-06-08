using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GA.MonsterProject
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager s_UIManager;

        [SerializeField]
        public DialogController m_gcDialogController;

        [SerializeField]
        public QuestManager m_gcQuestManager;

        [SerializeField]
        QuestLogController m_gcQuestLogController;

        public MusicController m_gcMusicController;

        [SerializeField]
        GameObject m_oPauseMenu;

        [SerializeField]
        Canvas m_gcCanvas;

        [SerializeField]
        Image m_gcQuestLogIcon;

        [SerializeField]
        TMP_Text m_txtSavedText;

        public Types.EForm m_iForm = Types.EForm._Baby;

        void Awake()
        {
            if (s_UIManager != null)
            {
                Destroy(gameObject);
            }
            else
            {
                s_UIManager = this;
            }
            DontDestroyOnLoad(this);

            m_gcDialogController.gameObject.SetActive(false);
            TogglePauseMenu(false);
        }

        public void StartDialog(INpc npc)
        {
            GameManager.s_GameManager.PlayerCanMove(false);
            m_gcDialogController.gameObject.SetActive(true);
            m_gcDialogController.StartDialog(npc);
        }

        public void HideDialog()
        {
            m_gcDialogController.gameObject.SetActive(false);
        }

        public void ToggleHud(bool active)
        {
            m_gcCanvas.gameObject.SetActive(active);
        }

        public void TogglePauseMenu(bool value)
        {
            m_oPauseMenu.gameObject.SetActive(value);
            m_gcQuestLogController.UpdateQuestLog();
            ToggleQuestLogIcon(false);
        }

        public void ToggleQuestLogIcon(bool value)
        {
            m_gcQuestLogIcon.gameObject.SetActive(value);
        }

        public void ShowSavedText()
		{
            m_txtSavedText.gameObject.SetActive(true);
            StartCoroutine(SavedTextDelay());
		}

        public void CallPause()
        {
            GameManager.s_GameManager.Pause();
        }

        public void Evolve1()
        {
            if (m_iForm == Types.EForm._Baby)
            {
                m_iForm = Types.EForm._Teen;
                GameManager.m_bCanPlay = true;
                if (GameObject.FindGameObjectWithTag("VideoPlayer") != null)
                {
                    GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<VideoClipPlayer>().PlayClipTeen();
                }
            }
        }

        public void Evolve2()
        {
            if (m_iForm == Types.EForm._Teen)
            {
                GameManager.m_bCanPlay = true;
                if (PlayerResources.s_CurrentResources.m_iBond >= 50)
                {
                    m_iForm = Types.EForm._Good;
                    if (GameObject.FindGameObjectWithTag("VideoPlayer") != null)
                    {
                        GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<VideoClipPlayer>().PlayClipGood();
                    }
                }
                else
                {
                    m_iForm = Types.EForm._Bad;
                    if (GameObject.FindGameObjectWithTag("VideoPlayer") != null)
                    {
                        GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<VideoClipPlayer>().PlayClipBad();
                    }
                }
            }
        }

        public void ResetValues()
        {
            m_iForm = Types.EForm._Baby;
        }

        IEnumerator SavedTextDelay()
		{
            yield return new WaitForSeconds(2);
            m_txtSavedText.gameObject.SetActive(false);
		}
    }
}
