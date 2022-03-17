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
            
        }

        void OnMouseDown()
        {
            //Debug.Log(gameObject);
            if(gameObject.tag == "PlayerLeft" && MonsterLeft.activeSelf)
            {
                MonsterLeft.SetActive(false);
                Points = +1;
            }
            if (gameObject.tag == "PlayerUp" && MonsterUp.activeSelf)
            {
                MonsterUp.SetActive(false);
                Points = +1;
            }
            if (gameObject.tag == "PlayerRight" && MonsterRight.activeSelf)
            {
                MonsterRight.SetActive(false);
                Points = +1;
            }
            Debug.Log(Points);
        }

        void ActivateButton()
        {
            RandomNum();

            if (RandomNumber == 0) {
                MonsterLeft.SetActive(true);
            } else if (RandomNumber == 1)
            {
                MonsterUp.SetActive(true);
            } else //(RandomNumber == 2)
            {
                MonsterRight.SetActive(true);
            }
        }

        void RandomNum()
        {
            RandomNumber = Random.Range(0, 3);
            Debug.Log(RandomNumber);
        }

        

    }
}
