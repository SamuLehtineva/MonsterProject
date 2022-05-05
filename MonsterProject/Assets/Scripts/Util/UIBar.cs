using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GA.MonsterProject
{
    public class UIBar : MonoBehaviour
    {
        [SerializeField]
        Image m_iMask;

        private float m_fDefaultWidth;

        void Start()
        {
            m_fDefaultWidth = m_iMask.rectTransform.rect.width;
        }

        public void SetWidth(float width)
        {
            m_iMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, m_fDefaultWidth * width);
            Debug.Log(m_iMask.rectTransform.rect.width);
        }
        
    }
}
