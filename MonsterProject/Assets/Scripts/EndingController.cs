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

            if (UIManager.s_UIManager.m_iForm == Types.EForm._Good)
            {
                if (PlayerResources.s_CurrentResources.m_iReputation > 50)
                {
                    m_gcPlayer.clip = m_vClips[0];
                }
                else
                {
                    m_gcPlayer.clip = m_vClips[1];
                }
            }
            else
            {
                if (PlayerResources.s_CurrentResources.m_iReputation > 50)
                {
                    m_gcPlayer.clip = m_vClips[2];
                }
                else
                {
                    m_gcPlayer.clip = m_vClips[1];
                }
            }

            m_gcPlayer.Play();
        }
    }
}
