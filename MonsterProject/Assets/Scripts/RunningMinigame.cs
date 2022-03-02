using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class RunningMinigame : MonoBehaviour
    {
        public Rigidbody rigbod;

        public float jumpForce = 2.0f;

        public Vector3 jump;

        public bool onGround;

        void FixedUpdate()
        {
            onGround = true;
            jump = new Vector3(0.0f, 2.0f, 0.0f);
            rigbod.AddForce(1000 * Time.deltaTime, 0, 0);

            if (Input.GetKeyDown(KeyCode.Space) && onGround)
            {

                rigbod.AddForce(jump * jumpForce, ForceMode.Impulse);
                onGround = false;
            }

        }
    }
}

