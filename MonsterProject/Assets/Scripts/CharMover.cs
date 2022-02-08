using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class CharMover : MonoBehaviour
    {
        private CharacterController m_ccCharacterController;
        private Vector3 m_vDirection;

        public float m_fMoveSpeed;
        public float m_fTurnSpeed;
        // Start is called before the first frame update
        void Start()
        {
            m_ccCharacterController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            m_vDirection.x = Input.GetAxis("Horizontal");
            m_vDirection.z = Input.GetAxis("Vertical");
            m_vDirection.Normalize();

            m_vDirection *= m_fMoveSpeed;

            m_ccCharacterController.Move(m_vDirection * Time.deltaTime);

            Debug.DrawLine(transform.position, transform.position + transform.forward * 5.0f, Color.green);

            if (m_vDirection != Vector3.zero)
            {
                Quaternion gTargetRotation = Quaternion.LookRotation(m_vDirection, Vector3.up);
                Quaternion qNewRotation = Quaternion.Slerp(transform.rotation, gTargetRotation, m_fTurnSpeed * Time.deltaTime);
                transform.rotation = gTargetRotation;
            }
        }
    }
}
