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
        public bool m_bTeleport = true;
        public float m_fTeleportDist;
        private NavMeshAgent m_gcNav;

        void Start()
        {
            m_gcNav = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            m_gcNav.destination = m_gcTarget.position;
            if (m_bTeleport && m_gcNav.remainingDistance > m_fTeleportDist)
			{
                transform.position = m_gcTarget.position;
                m_gcNav.ResetPath();
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
    }
}
