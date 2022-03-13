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

        // Game is paused in the beginning so the player can read some instructions
        void Start()
        {
            Paused();
        }

        // Checks if the character is in the air and if it is it can't jump
        // In second If() is checks if the player presses spacebar and the player character is on the ground the character jumps
        // Calls 3 other methods that either start the game, or ends it depending on if the player wins or loses
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

        // Using velocity and AddForce to get the character to jump
        void Jump()
        {
            rigbod.velocity = new Vector3(rigbod.velocity.x, 0);
            rigbod.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        // Starts the game if the player presses E
        public void StartMiniGame()
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1f;
                GamePaused = false;
            }
        }

        // Pauses the game
        void Paused ()
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GamePaused = true;
        }

        //Checks if the character touches the gameObject that end the game as a win
        public void WinMiniGame()
        {
            Vector3 right = transform.TransformDirection(Vector3.right);

            if (Physics.Raycast(transform.position, right, rayLength)) {
                Debug.Log("WON");
                SceneManager.LoadScene("Town");
            }
        }

        //Checks if the character touches any other gameObject and ends the game as a lose
        public void LoseMiniGame()
        {
            Vector3 right = transform.TransformDirection(Vector3.right);

            if (Physics.Raycast(transform.position, right, rayLength))
            {
                Debug.Log("LOST");
                SceneManager.LoadScene("Town");
            }
        }

        //Draws the rays
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayLength);
            Gizmos.DrawLine(transform.position, transform.position + Vector3.right * rayLength);
        }
    }
}

