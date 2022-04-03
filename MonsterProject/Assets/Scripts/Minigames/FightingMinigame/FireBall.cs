using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class FireBall : MonoBehaviour
    {
        public Animation m_gcAnim;

        void Update()
        {
            if (!m_gcAnim.isPlaying)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
