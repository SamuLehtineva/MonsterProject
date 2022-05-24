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
        public float timer = 0;
        public float timeLimit = 2;

        // Start is called before the first frame update
        void Start()
        {
            RandomNum();
            ActivateButton();
        }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if(timer >= timeLimit)
            {
                GameLost();
            }
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D))
            {
                GameControls();
                timer = 0;
            }
            if (Points == 10)
            {
                GameWon();
            }
        }

        void GameControls()
        {
            if (Input.GetKeyDown(KeyCode.A) && BoolMonLeft == true)
            {
                MonsterLeft.SetActive(false);
                BoolMonLeft = false;
                Points += 1;
                RandomNum();
                ActivateButton();
            } else if (Input.GetKeyDown(KeyCode.W) && BoolMonUp == true)
            {
                MonsterUp.SetActive(false);
                BoolMonUp = false;
                Points += 1;
                RandomNum();
                ActivateButton();
            } else if (Input.GetKeyDown(KeyCode.D) && BoolMonRight == true)
            {
                MonsterRight.SetActive(false);
                BoolMonRight = false;
                Points += 1;
                RandomNum();
                ActivateButton();
            } else
            {
                GameLost();
            }
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
