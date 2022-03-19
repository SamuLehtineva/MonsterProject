using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class FaceTransform : MonoBehaviour
    {
        public Transform m_gcTarget;
        void Update()
        {
            transform.rotation = m_gcTarget.rotation;
        }
    }
}
