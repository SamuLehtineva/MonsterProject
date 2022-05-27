using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GA.MonsterProject
{
    public class NavMoveTo : MonoBehaviour
    {
        [SerializeField]
        public Transform m_gcTarget;
        private NavMeshAgent m_gcNav;

        void Start()
        {
            m_gcNav = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            m_gcNav.destination = m_gcTarget.position;
        }

        public bool IsMoving()
		{
            if (m_gcNav.remainingDistance > m_gcNav.stoppingDistance)
			{
                return true;
			}
            else
			{
                return false;
			}
		}
    }
}
