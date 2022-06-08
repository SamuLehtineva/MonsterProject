using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class Npc_PetPlay : MonoBehaviour, IInteractables, INpc
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

		public string m_sFileName
		{
			get;
			set;
		}

		public GameObject m_oAlert;
		public bool m_bPlay;

		void Start()
		{
			if (GameManager.m_bCanPlay)
			{
				m_sFileName = "pet/play";
			}
			else
			{
				m_sFileName = "pet/play_no";
				m_oAlert.SetActive(false);
			}
		}

		void Update()
		{
			if (Input.GetButtonDown("Fire1") && IsActive && GameManager.s_GameManager.GetPlayerCanMove())
			{
				Interact();
				Debug.Log("juu");
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
			if (m_bPlay)
			{
				SceneChanger.LoadLevel("SImonSays");
			}
		}

		public void Interact()
		{
			UIManager.s_UIManager.StartDialog(this);
			DeActivate();
			m_bPlay = false;
		}

		public void PickOptionA()
		{
			GameManager.m_bCanPlay = false;
			m_bPlay = true;
		}

		public void PickOptionB()
		{
			//Empty for now
		}
    }
}
