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

        [Header("Pause")]
        public static bool GamePaused = false;
        public GameObject PauseMenu;


        public bool rightChoice = false;
        public int RandomNumber;
        public int Points = 0;
        public float timer = 0;
        public float timeLimit = 3;
        GameObject pet;

        // Start is called before the first frame update
        void Start()
        {
            Paused();
            ChangeForm();
            RandomNum();
            
        }

        // Update is called once per frame
        void Update()
        {
            StartMiniGame();
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
            if (Points == 20)
            {
                GameWon();
            }
        }

        void Paused()
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GamePaused = true;
        }

        public void StartMiniGame()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1f;
                GamePaused = false;
                ActivateButton();
            }
        }

        void GameControls()
        {
            if (Input.GetKeyDown(KeyCode.A) && BoolMonLeft == true)
            {
                pet.transform.Find("Left").gameObject.SetActive(false);
                BoolMonLeft = false;
                Points += 1;
                RandomNum();
                StartCoroutine(DelayBetweenSprites());
            } else if (Input.GetKeyDown(KeyCode.W) && BoolMonUp == true)
            {
                pet.transform.Find("Up").gameObject.SetActive(false);
                BoolMonUp = false;
                Points += 1;
                RandomNum();
                StartCoroutine(DelayBetweenSprites());
            } else if (Input.GetKeyDown(KeyCode.D) && BoolMonRight == true)
            {
                pet.transform.Find("Right").gameObject.SetActive(false);
                BoolMonRight = false;
                Points += 1;
                RandomNum();
                StartCoroutine(DelayBetweenSprites());
            } else
            {
                GameLost();
            }
        }

        void ChangeForm()
        {
            pet = transform.Find("Bad").gameObject;
            if (UIManager.s_UIManager != null)
            {
                switch (UIManager.s_UIManager.m_iForm)
                {
                    case Types.EForm._Baby:
                        pet = transform.Find("Baby").gameObject;
                        break;

                    case Types.EForm._Teen:
                        pet = transform.Find("Teen").gameObject;
                        break;

                    case Types.EForm._Bad:
                        pet = transform.Find("Bad").gameObject;
                        break;

                    case Types.EForm._Good:
                        pet = transform.Find("Good").gameObject;
                        break;
                }
            }
            pet.gameObject.SetActive(true);
        }

        void ActivateButton()
        {
            if (RandomNumber == 0) {
                pet.transform.Find("Left").gameObject.SetActive(true);
                BoolMonLeft = true;

            } else if (RandomNumber == 1)
            {
                pet.transform.Find("Up").gameObject.SetActive(true);
                BoolMonUp = true;
            } else //(RandomNumber == 2)
            {
                pet.transform.Find("Right").gameObject.SetActive(true);
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

        IEnumerator DelayBetweenSprites()
        {
            yield return new WaitForSeconds(0.5f);
            ActivateButton();
        }
    }
}
