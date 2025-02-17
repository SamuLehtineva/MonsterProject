using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class CharMover : MonoBehaviour
    {
        [SerializeField]
        MonsterController m_gcPetController;
        private CharacterController m_ccCharacterController;
        private Vector3 m_vDirection;
        private Animator m_gcANimator;
        public float m_fMoveSpeed;
        public float m_fGravity;
        public float m_fTurnSpeed;

        public bool m_bCanMove;

        void Start()
        {
            m_ccCharacterController = GetComponent<CharacterController>();
            m_gcANimator = GetComponent<Animator>();
            m_bCanMove = true;
        }

        void Update()
        {
            m_vDirection.x = Input.GetAxis("Horizontal");
            m_vDirection.z = Input.GetAxis("Vertical");
            m_vDirection.Normalize();
            
            if (m_bCanMove)
            {
                m_vDirection *= m_fMoveSpeed;
                m_vDirection.y -= m_fGravity;

                m_ccCharacterController.Move(m_vDirection * Time.deltaTime);

                m_vDirection.y = 0;

                Debug.DrawLine(transform.position, transform.position + transform.forward * 5.0f, Color.green);

                if (m_vDirection != Vector3.zero)
                {
                    m_gcANimator.SetBool("IsMoving", true);
                    Quaternion gTargetRotation = Quaternion.LookRotation(m_vDirection, Vector3.up);
                    transform.rotation = gTargetRotation;
                }
                else
                {
                    m_gcANimator.SetBool("IsMoving", false);
                }

                TryPet();
            }
            else
            {
                m_gcANimator.SetBool("IsMoving", false);
            }
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.s_GameManager.Pause();
            }
        }
        
        void TryPet()
        {
            
            RaycastHit rHit;
            if (Physics.Raycast(transform.position, transform.forward, out rHit, 3.0f))
            {
                if (rHit.transform.tag == "Pet")
                {
                    m_gcPetController.Activate();
                    if (Input.GetButtonDown("Fire3"))
                    {
                        StartCoroutine(ActionDelay(2));
                        m_gcANimator.Play("Petting");
                        m_gcPetController.PlayPetAnimation();
                    }
                }
            }
            else
            {
                m_gcPetController.DeActivate();
            }
        }

        IEnumerator ActionDelay(int seconds)
        {
            m_bCanMove = false;
            yield return new WaitForSeconds(seconds);
            m_bCanMove = true;
        }
    }
}
