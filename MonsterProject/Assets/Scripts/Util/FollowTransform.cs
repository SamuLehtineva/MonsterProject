using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class FollowTransform : MonoBehaviour
    {
        public Transform m_tTarget;

        public float m_fXOffset;
        public float m_fYOffset;
        public float m_fZOffset;

        void Update()
        {
            Vector3 vCurrentPos = transform.position;
            Vector3 vWantedPos = m_tTarget.position;

            vWantedPos.y += m_fYOffset;
            vWantedPos.x += m_fXOffset;
            vWantedPos.z += m_fZOffset;

            transform.position = Vector3.Lerp(vCurrentPos, vWantedPos, 25.0f * Time.deltaTime);
            transform.position = vWantedPos;
            transform.LookAt(m_tTarget);
        }
    }
}
