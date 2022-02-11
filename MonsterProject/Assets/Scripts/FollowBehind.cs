using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class FollowBehind : MonoBehaviour
    {
        public Transform m_tTarget;

        public float m_fBehindOffset = -1.0f;
        public float m_fMoveSpeed;
        private Vector3 m_vTargetPos;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            m_vTargetPos = m_tTarget.position + (m_tTarget.forward * m_fBehindOffset);
            transform.LookAt(m_vTargetPos, Vector3.up);
            float fRatio = InverseLerp(transform.position, m_vTargetPos, transform.position + transform.forward);
            transform.position += transform.forward * m_fMoveSpeed * Time.deltaTime / fRatio;
            Debug.Log(fRatio);
        }

        public float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
        {
            Vector3 AB = b - a;
            Vector3 AV = value - a;
            return Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB);
        }
    }   
}
