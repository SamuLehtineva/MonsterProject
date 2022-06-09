using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

namespace GA.MonsterProject
{
    public class EndingController : MonoBehaviour, INpc
    {
        public VideoClip[] m_vClips;
        public bool m_bCanEnd;
        public GameObject m_oContinue;
        VideoPlayer m_gcPlayer;

		public string m_sName
        {
            get;
            set;
        }

		public string m_sFileName
        {
            get;
            set;
        }

		void Start()
        {
            m_bCanEnd = false;
            m_oContinue.SetActive(false);
            m_gcPlayer = GetComponent<VideoPlayer>();

            if (UIManager.s_UIManager != null && UIManager.s_UIManager.m_iForm == Types.EForm._Good)
            {
                if (PlayerResources.s_CurrentResources.m_iReputation > 50)
                {
                    m_gcPlayer.clip = m_vClips[0];
                    m_sFileName = "endings/posbondposrep";
                }
                else
                {
                    m_gcPlayer.clip = m_vClips[1];
                    m_sFileName = "endings/posbondnegrep";
                }
            }
            else
            {
                if (PlayerResources.s_CurrentResources != null && PlayerResources.s_CurrentResources.m_iReputation > 50)
                {
                    m_gcPlayer.clip = m_vClips[3];
                    m_sFileName = "endings/negbondposrep";
                }
                else
                {
                    m_gcPlayer.clip = m_vClips[2];
                    m_sFileName = "endings/negbondnegrep";
                }
            }

            m_gcPlayer.Play();
            UIManager.s_UIManager.StartDialog(this);
        }

        void Update()
		{
            if (Input.GetButtonDown("Fire1") && m_bCanEnd)
			{
                SceneChanger.LoadLevel("Credits");
			}
		}

        public void DialogEnd()
        {
            m_oContinue.SetActive(true);
            m_bCanEnd = true;
        }

        public void PickOptionA()
        {
            //Empty
        }

        public void PickOptionB()
        {
            //Empty
        }
    }
}
