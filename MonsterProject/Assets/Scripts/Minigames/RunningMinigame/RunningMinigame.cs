using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class RunningMinigame : MonoBehaviour, MiniGameInterface
    {
        public CharacterController charCont;
        public Rigidbody rigbod;
        public bool onGround = false;
        public LayerMask groundLayer;
        public Vector3 moveDirection;

        public static bool GamePaused = false;
        public GameObject PauseMenu;

        [Header("Jumping")]
        public float rayLength = 0.5f;
        public float jumpHeight = 15f;

        [Header("Movement")]
        public float moveSpeed = 1000f;
        public float speedWhileJumping = 200f;

        void Start()
        {
            Paused();
        }

        void Update()
        {
            if (onGround == true)
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
            StartMiniGame();
            WinMiniGame();
            LoseMiniGame();
        }

        void Jump()
        {
            rigbod.velocity = new Vector3(rigbod.velocity.x, 0);
            rigbod.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        public void StartMiniGame()
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1f;
                GamePaused = false;
            }
        }

        void Paused ()
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GamePaused = true;
        }

        public void WinMiniGame()
        {
            Vector3 right = transform.TransformDirection(Vector3.right);

            if (Physics.Raycast(transform.position, right, rayLength)) {
                Debug.Log("WON");
                SceneManager.LoadScene("Town");
            }
        }

        public void LoseMiniGame()
        {
            Vector3 right = transform.TransformDirection(Vector3.right);

            if (Physics.Raycast(transform.position, right, rayLength))
            {
                Debug.Log("LOST");
                SceneManager.LoadScene("Town");
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayLength);
            Gizmos.DrawLine(transform.position, transform.position + Vector3.right * rayLength);
        }
    }
}

