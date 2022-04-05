using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class RunMiniCamera : MonoBehaviour
    {
        public Transform player;
        public float m_fXOffset = 6f;
        public float m_fYOffset = -4f;
        public float m_fZOffset = -10f;
        void Update()
        {
            transform.position = player.position + new Vector3(m_fXOffset, m_fYOffset, m_fZOffset);
        }
    }
}
