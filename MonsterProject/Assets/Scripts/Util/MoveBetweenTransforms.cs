using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class MoveBetweenTransforms : MonoBehaviour
    {
        public Transform m_gcLerpPoint1;
        public Transform m_gcLerpPoint2;

        public float m_fLerpDurationSeconds = 1.0f;
        public float m_fRatio;
        private float m_fEventTime = 0.0f;
        void Start()
        {
            m_fEventTime = Time.time;
        }
        
        void Update()
        {
            m_fRatio = (Time.time - m_fEventTime) / m_fLerpDurationSeconds;
            
            transform.position = Vector3.Lerp(m_gcLerpPoint1.position, m_gcLerpPoint2.position, m_fRatio);

            if (m_fRatio >= 1.0f)
            {
                var gcTemp = m_gcLerpPoint1;
                m_gcLerpPoint1 = m_gcLerpPoint2;
                m_gcLerpPoint2 = gcTemp;
                m_fEventTime = Time.time;
            }
        }

        public float GetRatio()
        {
            return m_fRatio;
        }

        public void Reset()
        {
            transform.position = m_gcLerpPoint1.position;
            m_fEventTime = Time.time;
        }
    }
}
