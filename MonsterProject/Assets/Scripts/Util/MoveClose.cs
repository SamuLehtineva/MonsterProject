using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GA.MonsterProject
{
    public class MoveClose : MonoBehaviour
    {
        public Transform m_tTarget;
        public float m_fDesiredDistance = 10f;
        public float m_fMoveSpeed;
        private Vector3 m_vTargetPos;
        private float m_fDistance;

        void LateUpdate()
        {
            m_fDistance = Vector3.Distance(transform.position, m_tTarget.position);
            transform.LookAt(m_tTarget.position, Vector3.up);
            m_vTargetPos = m_tTarget.position;
            float fRatio = InverseLerp(transform.position, m_vTargetPos, transform.position + transform.forward);
            try
            {
                //Debug.Log(fRatio * (JumpToZero(0.2f, m_fDistance / m_fDesiredDistance)));
                transform.position += transform.forward * m_fMoveSpeed * Time.deltaTime / fRatio * (JumpToZero(0.2f, m_fDistance / m_fDesiredDistance));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
        {
            Vector3 AB = b - a;
            Vector3 AV = value - a;
            float result = Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB);
            if (result > 0.0f)
            {
              return Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB);  
            }
            else
            {
                return Mathf.Epsilon;
            }
        }

        public float JumpToZero(float treshold, float value)
        {
            if (value < treshold)
            {
                return 0.0f;
            } 
            else
            {
                return value;
            }
        }

        public bool IsMoving()
        {
            if (JumpToZero(0.2f, m_fDistance / m_fDesiredDistance) > 0)
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
