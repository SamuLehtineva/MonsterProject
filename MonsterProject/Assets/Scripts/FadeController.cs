using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class FadeController : MonoBehaviour
    {
        public Animator m_gcAni;

        public void FadeIn()
        {
            m_gcAni.SetBool("FadeIn", true);
        }
    }
}
