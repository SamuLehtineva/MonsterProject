using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class QuestPickup : MonoBehaviour, IInteractables, ISaveable, INpc
    {
        public bool IsActive
        {
            get;
            set;
        }

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

        public string m_sQuestName;
        public bool m_bUsed = false;
        Collider m_gcCollider;
        GameObject m_oQuestIcon;

        void Start()
        {
            m_gcCollider = GetComponent<Collider>();
            m_oQuestIcon = GameObject.Find(this.name + "/alert");
        }

        void Update()
        {
            if (m_bUsed)
            {
                this.gameObject.SetActive(false);
            }
            else if (UIManager.s_UIManager.m_gcQuestManager.GetQuestByName(m_sQuestName).m_iStatus != Types.EStatus._Active)
            {
                m_gcCollider.enabled = false;
                m_oQuestIcon.SetActive(false);
            }
            else
            {
                m_gcCollider.enabled = true;
                m_oQuestIcon.SetActive(true);
            }
            
            if (Input.GetButtonDown("Fire1") && IsActive && GameManager.s_GameManager.GetPlayerCanMove())
            {
                Interact();
            }
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void DeActivate()
        {
            IsActive = false;
        }

        public void DialogEnd()
        {
            UIManager.s_UIManager.m_gcQuestManager.SetQuestStatus(m_sQuestName, Types.EStatus._Completed);
            m_bUsed = true;
        }

        public void Interact()
        {
            UIManager.s_UIManager.StartDialog(this);
            DeActivate();
            Debug.Log("jeee");
        }

        public void PickOptionA()
        {
            //empty for now
        }

        public void PickOptionB()
        {
            //empty for now
        }

        public void Save(ISaveWriter writer)
        {
            writer.WriteBool(m_bUsed);
        }

        public void Load(ISaveReader reader)
        {
            m_bUsed = reader.ReadBool();
        }

        
    }
}
