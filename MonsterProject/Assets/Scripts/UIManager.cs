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
        GameObject m_oPauseMenu;

        [SerializeField]
        Canvas m_gcCanvas;

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
        }

        public void CallPause()
        {
            GameManager.s_GameManager.Pause();
        }
    }
}
