using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class MoveBetweenTransforms : MonoBehaviour
    {
        public Transform m_gcLerpPoint1;
        public Transform m_gcLerpPoint2;
        public Material m_gcMaterial;

        public float m_fLerpDurationSeconds = 1.0f;
        private float m_fEventTime = 0.0f;
        void Start()
        {
            m_fEventTime = Time.time;
        }
        
        

        void Update()
        {
            // 0 ..1    
            float fRatio = (Time.time - m_fEventTime) / m_fLerpDurationSeconds;
            
            transform.position = Vector3.Lerp(m_gcLerpPoint1.position, m_gcLerpPoint2.position, fRatio);

            if (fRatio >= 1.0f)
            {
                var gcTemp = m_gcLerpPoint1;
                m_gcLerpPoint1 = m_gcLerpPoint2;
                m_gcLerpPoint2 = gcTemp;
                m_fEventTime = Time.time;
            }

            if (Input.GetButton("Fire1") && fRatio < 0.6f && fRatio > 0.4f)
            {
                m_gcMaterial.color = Color.green;
            }
            
        }
    }
}
