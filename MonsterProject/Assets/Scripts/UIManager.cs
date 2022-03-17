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
        }

        public void StartDialog (string FileName, QuestReward rewardA, QuestReward rewardB) 
        {
            m_gcDialogController.StartDialog(FileName);
            m_gcDialogController.SetRewards(rewardA, rewardB);
        }
    }
}
