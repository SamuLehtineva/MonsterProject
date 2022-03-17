using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class SineBounce : MonoBehaviour
    {
        public float m_fBounceSpeed;
        public float m_fBounceDistance;
        public bool m_bAbsolute;

        private Vector3 m_vOrigin;
        private float m_fAngle;
        void Start()
        {
            m_vOrigin = transform.position;
        }

        void Update()
        {
            m_fAngle += m_fBounceSpeed * Time.deltaTime;
            float fSine = Mathf.Sin(m_fAngle) * m_fBounceDistance;

            if (m_bAbsolute)
            {
                fSine = Mathf.Abs(fSine);
            }

            transform.position = m_vOrigin + new Vector3(0, fSine, 0);
        }
    }
}
