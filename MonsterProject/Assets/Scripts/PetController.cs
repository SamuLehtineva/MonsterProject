using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class PetController : MonoBehaviour
    {
        [SerializeField]
        MoveClose m_gcMoveClose;
        private Animator m_gcAnimator;

        void Start()
        {
            m_gcAnimator = GetComponent<Animator>();
            //m_gcAnimator.SetBool("IsMoving", true);
        }

        void Update()
        {
            m_gcAnimator.SetBool("IsMoving", m_gcMoveClose.IsMoving());

            if (Input.GetButtonDown("Fire2"))
            {
                m_gcAnimator.Play("Pet");
            }
        }
    }
}
