using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager s_UIManager;

        [SerializeField]
        DialogController m_gcDialogController;

        [SerializeField]
        public QuestManager m_gcQuestManager;

        [SerializeField]
        QuestLogController m_gcQuestLogController;

        [SerializeField]
        GameObject m_oPauseMenu;

        [SerializeField]
        Canvas m_gcCanvas;
        public Types.EForm m_iForm = Types.EForm._Baby;
        public int m_iEvolveTresh;

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
        }

        public void CallPause()
        {
            GameManager.s_GameManager.Pause();
        }

        public void PetEvent()
        {
            if (m_gcQuestManager.GetQuestByName("evolve").m_iStatus == Types.EStatus._Done)
            {
                m_gcQuestManager.SetQuestStatus("evolve", Types.EStatus._Inactive);
                Evolve();
            }
            if (m_gcQuestManager.QuestCountDone() == m_iEvolveTresh)
            {
                Debug.Log("quests done: " + m_gcQuestManager.QuestCountDone());
                m_gcQuestManager.SetQuestStatus("evolve", Types.EStatus._Active);
            }

        }

        public void Evolve()
        {
            if (m_iForm == Types.EForm._Teen)
            {
                if (PlayerResources.s_CurrentResources.m_iBond >= 50)
                {
                    m_iForm = Types.EForm._Good;
                }
                else
                {
                    m_iForm = Types.EForm._Bad;
                }
                m_iEvolveTresh = 100;
            }
            else if (m_iForm == Types.EForm._Baby)
            {
                m_iForm = Types.EForm._Teen;
                m_iEvolveTresh = 4;
            }
        }

        public void ResetValues()
        {
            m_iForm = Types.EForm._Baby;
            m_iEvolveTresh = 2;
        }
    }
}
