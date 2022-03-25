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
        QuestManager m_gcQuestManager;

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
        }

        public void StartDialog (string FileName, QuestReward rewardA, QuestReward rewardB) 
        {
            GameManager.s_GameManager.PlayerCanMove(false);
            m_gcDialogController.gameObject.SetActive(true);
            m_gcDialogController.StartDialog(FileName);
            m_gcDialogController.SetRewards(rewardA, rewardB);
        }

        public void ToggleHud(bool active)
        {
            m_gcCanvas.gameObject.SetActive(active);
        }
    }
}
