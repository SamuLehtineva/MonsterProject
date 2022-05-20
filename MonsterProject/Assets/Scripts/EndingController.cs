using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace GA.MonsterProject
{
    public class EndingController : MonoBehaviour
    {
        public VideoClip[] m_vClips;
        VideoPlayer m_gcPlayer;

        void Start()
        {
            m_gcPlayer = GetComponent<VideoPlayer>();

            if (PlayerResources.s_CurrentResources.m_iReputation < 25)
            {
                m_gcPlayer.clip = m_vClips[0];
            }
        }
    }
}
