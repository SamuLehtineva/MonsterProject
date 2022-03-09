using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class RunningMinigame : MonoBehaviour
    {
        public CharacterController charCont;
        public Rigidbody rigbod;
        public bool onGround = false;
        public LayerMask groundLayer;
        public Vector3 moveDirection;

        [Header("Jumping")]
        public float rayLength = 0.5f;
        public float jumpHeight = 15f;

        [Header("Movement")]
        public float moveSpeed = 1000f;
        public float speedWhileJumping = 200f;



        void Update()
        {
            if(onGround == true)
            {
                rigbod.AddForce(moveSpeed * Time.deltaTime, 0, 0);
            } else
            {
                rigbod.AddForce(speedWhileJumping * Time.deltaTime, 0, 0);
            }

            onGround = Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayer);
            if (Input.GetButtonDown("Jump") && onGround)
            {
                Jump();
            }
        }

        void Jump()
        {
            rigbod.velocity = new Vector3(rigbod.velocity.x, 0);
            rigbod.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayLength);
        }
    }
}

