using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class Tutorial : MonoBehaviour, INpc, IInteractables
    {
        [field: SerializeField]
        public string m_sName
        {
            get;
            set;
        }

        [field: SerializeField]
        public string m_sFileName
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }
        public void Activate()
        {
            Interact();
        }

        public void DeActivate()
        {
            throw new System.NotImplementedException();
        }

        public void DialogEnd()
        {
            UIManager.s_UIManager.m_gcQuestManager.SetQuestStatus("talk_well", Types.EStatus._Active);
        }

        public void Interact()
        {
            UIManager.s_UIManager.ToggleQuestLogIcon(true);
            UIManager.s_UIManager.StartDialog(this);
        }

        public void PickOptionA()
        {
            throw new System.NotImplementedException();
        }

        public void PickOptionB()
        {
            throw new System.NotImplementedException();
        }
    }
}
