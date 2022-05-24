using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class SimonSays : MonoBehaviour
    {
        [Header("Monster")]
        public GameObject MonsterLeft;
        public GameObject MonsterUp;
        public GameObject MonsterRight;

        [Header("Player")]
        public GameObject PlayerLeft;
        public GameObject PlayerUp;
        public GameObject PlayerRight;

        [Header("Booleans")]
        public bool BoolMonLeft = false;
        public bool BoolMonUp = false;
        public bool BoolMonRight = false;


        public bool rightChoice = false;
        public int RandomNumber;
        public int Points = 0;

        public Types.EDirection randomDir;
        public Types.EDirection playerDir;

        // Start is called before the first frame update
        void Start()
        {
            RandomNum();
            ActivateButton();
        }

        // Update is called once per frame
        void Update()
        {
            GameControls();
            if (Points == 10)
            {
                GameWon();
            }
        }

        void GameControls()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerDir = Types.EDirection._Left;
                MonsterLeft.SetActive(false);
                BoolMonLeft = false;
                Points += 1;
                RandomNum();
                ActivateButton();
            } else if (Input.GetKeyDown(KeyCode.W) && BoolMonUp == true)
            {
                playerDir = Types.EDirection._Up;
                MonsterUp.SetActive(false);
                BoolMonUp = false;
                Points += 1;
                RandomNum();
                ActivateButton();
            } else if (Input.GetKeyDown(KeyCode.D) && BoolMonRight == true)
            {
                playerDir = Types.EDirection._Right;
                MonsterRight.SetActive(false);
                BoolMonRight = false;
                Points += 1;
                RandomNum();
                ActivateButton();
            }

            if(playerDir == randomDir)
            {
                GameWon();
            } else if(playerDir != Types.EDirection._Empty)
            {
                GameLost();
            }

            playerDir = Types.EDirection._Empty;
        }

        void ActivateButton()
        {
            if (RandomNumber == 0) {
                MonsterLeft.SetActive(true);
                BoolMonLeft = true;

            } else if (RandomNumber == 1)
            {
                MonsterUp.SetActive(true);
                BoolMonUp = true;
            } else //(RandomNumber == 2)
            {
                MonsterRight.SetActive(true);
                BoolMonRight = true;
            }
        }

        void RandomNum()
        {
            RandomNumber = Random.Range(0, 3);
            randomDir = (Types.EDirection)Random.Range(0, 3);
        }

        void GameWon()
        {
            Debug.Log("Won");
        }

        void GameLost()
        {
            Debug.Log("Lost");
        }
    }
}
