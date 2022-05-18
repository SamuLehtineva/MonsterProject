using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class RunMiniCamera : MonoBehaviour
    {
        public Transform player;
        //Offsetting the camera lower than the basic settings so the game looks more like a 2d game
        public float m_fXOffset = 6f;
        public float m_fYOffset = -4f;
        public float m_fZOffset = -10f;
        void Update()
        {
            transform.position = new Vector3(m_fXOffset + player.position.x, m_fYOffset, m_fZOffset + player.position.z);
        }
    }
}
