using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace GA.MonsterProject
{
    public class VideoClipPlayer : MonoBehaviour
    {
        [SerializeField]
        VideoClip m_vTeen;

        [SerializeField]
        VideoClip m_vBad;

        [SerializeField]
        VideoClip m_vGood;
        VideoPlayer m_gcVideo;
        
        void Start()
        {
            m_gcVideo = GameObject.Find("Main Camera").GetComponent<VideoPlayer>();
            m_gcVideo.loopPointReached += EndReached;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                //PlayClipTeen();
            }
        }

        public void PlayClipTeen()
        {
            GameManager.s_GameManager.PlayerCanMove(false);
            m_gcVideo.clip = m_vTeen;
            m_gcVideo.Play();
        }

        void EndReached(VideoPlayer vp)
        {
            m_gcVideo.Stop();
            GameManager.s_GameManager.PlayerCanMove(true);
        }

        void OnDisable()
        {
            m_gcVideo.loopPointReached -= EndReached;
        }

    }
}
