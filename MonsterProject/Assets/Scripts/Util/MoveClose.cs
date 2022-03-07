using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class MoveClose : MonoBehaviour
    {
        public Transform m_tTarget;
        public float m_fDesiredDistance = 10f;
        public float m_fMoveSpeed;
        private Vector3 m_vTargetPos;
        private float m_fDistance;

        void Update()
        {
            m_fDistance = Vector3.Distance(transform.position, m_tTarget.position);
            transform.LookAt(m_tTarget.position, Vector3.up);
            m_vTargetPos = m_tTarget.position;
            float fRatio = InverseLerp(transform.position, m_vTargetPos, transform.position + transform.forward);
            transform.position += transform.forward * m_fMoveSpeed * Time.deltaTime / fRatio * (m_fDistance / m_fDesiredDistance);
        }

        public float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
        {
            Vector3 AB = b - a;
            Vector3 AV = value - a;
            return Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB);
        }
    }
}
