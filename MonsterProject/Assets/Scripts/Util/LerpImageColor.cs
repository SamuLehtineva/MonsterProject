using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GA.MonsterProject
{
    public class LerpImageColor : MonoBehaviour
    {
        public Image m_gcImage;
        public Color m_gcLerpColor1;
        public Color m_gcLerpColor2;
        public float m_fLerpDurationSeconds = 1.0f;
        private float m_fEventTime = 0.0f;

        void Start()
        {
            m_fEventTime = Time.time;
        }

        void Update()
        {
            float ratio = (Time.time - m_fEventTime) / m_fLerpDurationSeconds;
            m_gcImage.color = Color.Lerp(m_gcLerpColor1, m_gcLerpColor2, ratio);

            if (ratio >= 1f)
            {
                var temp = m_gcLerpColor1;
                m_gcLerpColor1 = m_gcLerpColor2;
                m_gcLerpColor2 = temp;
                m_fEventTime = Time.time;
            }
        }
    }
}
