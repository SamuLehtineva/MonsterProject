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
        private Animator m_gcAnimator;
        private AudioSource m_gcAudioSource;

        void Start()
        {
            m_gcAnimator = GetComponent<Animator>();
            m_gcAudioSource = GetComponent<AudioSource>();
            //m_gcAnimator.SetBool("IsMoving", true);
        }

        void Update()
        {
            m_gcAnimator.SetBool("IsMoving", m_gcMoveClose.IsMoving());

            if (Input.GetButtonDown("Fire2"))
            {
                m_gcAnimator.Play("Pet");
                m_gcAudioSource.PlayOneShot(m_gcPetSound);
            }
        }
    }
}
