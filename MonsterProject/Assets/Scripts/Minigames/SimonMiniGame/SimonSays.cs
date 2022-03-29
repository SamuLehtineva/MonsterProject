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

        // Start is called before the first frame update
        void Start()
        {
            ActivateButton();
        }

        // Update is called once per frame
        void Update()
        {
            GameControls();
        }

        void GameControls()
        {
            if (Input.GetKey(KeyCode.A) && BoolMonLeft == true)
            {
                MonsterLeft.SetActive(false);
                Points += 1;
                RandomNum();
                ActivateButton();
            } else if (Input.GetKey(KeyCode.W) && BoolMonUp == true)
            {
                MonsterLeft.SetActive(false);
                Points += 1;
                RandomNum();
                ActivateButton();
            } else if (Input.GetKey(KeyCode.D) && BoolMonRight == true)
            {
                MonsterLeft.SetActive(false);
                Points += 1;
                RandomNum();
                ActivateButton();
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
            Debug.Log(RandomNumber);
        }
    }
}
