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
			//Empty for now
		}

		public void Interact()
		{
			UIManager.s_UIManager.StartDialog(this);
			DeActivate();
		}

		public void PickOptionA()
		{
			GameManager.m_bCanPlay = false;
			SceneChanger.LoadLevel("SImonSays");
		}

		public void PickOptionB()
		{
			//Empty for now
		}
    }
}
