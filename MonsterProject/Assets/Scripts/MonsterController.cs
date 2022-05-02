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
        Types.EForm m_iForm;

        void Start()
        {
            m_iForm = UIManager.s_UIManager.m_iForm;
            ChangeForm();
            m_gcAnimator = GetComponentInChildren<Animator>();
            DeActivate();
            //m_gcAnimator.SetBool("IsMoving", true);
        }

        void Update()
        {
            m_gcAnimator.SetBool("IsMoving", m_gcMoveClose.IsMoving());
            if (m_iForm != UIManager.s_UIManager.m_iForm)
            {
                m_iForm = UIManager.s_UIManager.m_iForm;
                ChangeForm();
            }
        }

        void ChangeForm()
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }

            switch(m_iForm)
            {
                case Types.EForm._Baby:
                    transform.Find("Baby").gameObject.SetActive(true);
                    break;
                
                case Types.EForm._Teen:
                    transform.Find("Teen").gameObject.SetActive(true);
                    break;
                
                case Types.EForm._Bad:
                    transform.Find("Bad").gameObject.SetActive(true);
                    break;

                case Types.EForm._Good:
                    transform.Find("Good").gameObject.SetActive(true);
                    break;
            }
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
