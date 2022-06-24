using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class Npc_Evolution : MonoBehaviour, IInteractables, INpc
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

		[field: SerializeField]
		public string m_sEvolution
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
			IsActive = false;
		}

		public void DialogEnd()
		{
			UIManager.s_UIManager.m_gcQuestManager.SetQuestStatus(m_sEvolution, Types.EStatus._Done);
		}

		public void Interact()
		{
			UIManager.s_UIManager.m_gcDialogController.SetRewards(new QuestReward(-50, 0, 10), new QuestReward(0, 0, -25));
			UIManager.s_UIManager.StartDialog(this);
		}

		public void PickOptionA()
		{
			PlayerResources.s_CurrentResources.AddResources(-50, 0, 10);
		}

		public void PickOptionB()
		{
			PlayerResources.s_CurrentResources.AddResources(0, 0, -25);
		}
    }
}
