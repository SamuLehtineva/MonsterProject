using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class PetController : MonoBehaviour
    {
        [SerializeField]
        MoveClose m_gcMoveClose;

        [SerializeField]
        AudioClip m_gcPetSound;

        [SerializeField]
        SpriteRenderer m_2dInteract;
        private Animator m_gcAnimator;
        private AudioSource m_gcAudioSource;

        void Start()
        {
            m_gcAnimator = GetComponent<Animator>();
            m_gcAudioSource = GetComponent<AudioSource>();
            DeActivate();
            //m_gcAnimator.SetBool("IsMoving", true);
        }

        void Update()
        {
            m_gcAnimator.SetBool("IsMoving", m_gcMoveClose.IsMoving());
        }

        public void Activate()
        {
            m_2dInteract.gameObject.SetActive(true);
        }

        public void DeActivate()
        {
            m_2dInteract.gameObject.SetActive(false);
        }
        public void PlayPetAnimation()
        {
            m_gcAnimator.Play("Pet");
            m_gcAudioSource.PlayOneShot(m_gcPetSound);
            DeActivate();
        }
    }
}
