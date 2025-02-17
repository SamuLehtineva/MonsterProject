using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class DoorController : MonoBehaviour, IInteractables
    {
        [SerializeField]
        Animator m_aDoorAnimator;
        public bool IsActive
        {
            get;
            set;
        }
        AudioClipPlayer m_gcAudi;
        public SceneChanger m_gcChanger;

        void Start()
        {
            IsActive = false;
            m_gcAudi = GetComponent<AudioClipPlayer>();
            m_gcChanger = GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>();
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1") && IsActive)
            {
                Interact();
            }
        }

        public void Activate()
        {
            m_gcAudi.PlayClip(0, PlayerPrefs.GetFloat("EffectVolume"));
            if (!IsActive)
            {
                m_aDoorAnimator.Play("Door_Open", 0, 0.0f);
                IsActive = true;
            }
            
        }

        public void DeActivate()
        {
            if (IsActive)
            {
                m_aDoorAnimator.Play("Door_Close", 0, 0.0f);
                IsActive = false;
            }
        }

        public void Interact()
        {
            GameManager.m_sDestination = "Default";
            GameManager.m_sDestinationScene = "Cabin_Bigger_Room";
            m_gcChanger.LoadWithFadeOut("Cabin_Bigger_Room");
        }
    }
}
