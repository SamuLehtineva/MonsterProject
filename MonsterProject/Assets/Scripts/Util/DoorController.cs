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

        void Start()
        {
            IsActive = false;
            m_gcAudi = GetComponent<AudioClipPlayer>();
        }

        // Update is called once per frame
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
            SceneManager.LoadScene("Cabin_Bigger_Room");
        }
    }
}
