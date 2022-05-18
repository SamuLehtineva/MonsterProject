using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    // This script causes the attached gameobject to follow the specified transform
    public class FollowTransform : MonoBehaviour
    {
        // The transform of the target to be followed
        public Transform m_tTarget;

        // These offsets define attached objects position in relation to the target
        // Setting all to 0 sets position to targets position
        public float m_fXOffset;
        public float m_fYOffset;
        public float m_fZOffset;

        // These offsets define where attached object is looking in relation to the target
        public float m_fXLookOffset = 0;
        public float m_fYLookOffset = 0;
        public float m_fZLookOffset;

        void LateUpdate()
        {
            Vector3 vCurrentPos = transform.position;
            Vector3 vWantedPos = m_tTarget.position;

            vWantedPos.y += m_fYOffset;
            vWantedPos.x += m_fXOffset;
            vWantedPos.z += m_fZOffset;

            transform.position = vWantedPos;
            Vector3 vTarget = m_tTarget.transform.position;
            vTarget += new Vector3(m_fXLookOffset, m_fYLookOffset, m_fZLookOffset);
            transform.LookAt(vTarget);
        }
    }
}
