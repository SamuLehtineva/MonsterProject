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
            transform.LookAt(m_gcTarget, Vector3.up);
        }
    }
}
