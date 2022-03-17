using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class LookAtTarget : MonoBehaviour
    {
        [SerializeField]
        Transform m_gcTarget;

        void Update()
        {
            //transform.forward = m_gcTarget.forward;
            //transform.rotation = m_gcTarget.rotation;
            transform.LookAt(m_gcTarget);
        }
    }
}
