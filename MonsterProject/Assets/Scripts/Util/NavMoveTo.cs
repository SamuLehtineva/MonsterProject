using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GA.MonsterProject
{
    /*
     * Uses NavMeshAgent to follow a transform 
     */
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
            // if target gets too far away, warp to it
            if (m_gcNav.remainingDistance > 3 * m_gcNav.stoppingDistance && m_gcNav.remainingDistance != float.PositiveInfinity)
			{
                m_gcNav.Warp(m_gcTarget.position);
			}
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

        public void SetStoppingDistance(float amount)
		{
            m_gcNav.stoppingDistance = amount;
		}
    }
}
