using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class MonsterController : MonoBehaviour
    {
        [SerializeField]
        MoveClose m_gcMoveClose;

        [SerializeField]
        AudioClipPlayer m_gcAudi;

        [SerializeField]
        SpriteRenderer m_2dInteract;
        private Animator m_gcAnimator;

        void Start()
        {
            m_gcAnimator = GetComponentInChildren<Animator>();
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
            m_gcAnimator.Play("Being_Pet");
            m_gcAudi.PlayClip(0, 1);
            DeActivate();
        }
    }
}
