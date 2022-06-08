using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class SimonSays : MonoBehaviour
    {
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

        private GameObject pet;
        private AudioClipPlayer Audi;
        private bool Over;

        // Start is called before the first frame update
        void Start()
        {
            Paused();
            ChangeForm();
            RandomNum();
            Audi = GetComponent<AudioClipPlayer>();
            Over = false;
        }

        // Update is called once per frame
        void Update()
        {
            StartMiniGame();
            timer += Time.deltaTime;
            if(timer >= timeLimit && !Over)
            {
                GameLost();
            }
            if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D)) && !GamePaused)
            {
                GameControls();
                timer = 0;
            }
            if (Points == 20 && !Over)
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
                Audi.PlayClip(0, 1);
            } else if (Input.GetKeyDown(KeyCode.W) && BoolMonUp == true)
            {
                pet.transform.Find("Up").gameObject.SetActive(false);
                BoolMonUp = false;
                Points += 1;
                RandomNum();
                StartCoroutine(DelayBetweenSprites());
                Audi.PlayClip(0, 1);
            } else if (Input.GetKeyDown(KeyCode.D) && BoolMonRight == true)
            {
                pet.transform.Find("Right").gameObject.SetActive(false);
                BoolMonRight = false;
                Points += 1;
                RandomNum();
                StartCoroutine(DelayBetweenSprites());
                Audi.PlayClip(0, 1);
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
            if (PlayerResources.s_CurrentResources != null)
			{
                PlayerResources.s_CurrentResources.AddResource(Types.EResource._Bond, 5);
			}

            Over = true;
            Audi.PlayClip(2, 1);
            Debug.Log("Won");
            StartCoroutine(EndDelay());
        }

        void GameLost()
        {
            Over = true;
            Audi.PlayClip(1, 1);
            Debug.Log("Lost");
            StartCoroutine(EndDelay());
        }

        IEnumerator DelayBetweenSprites()
        {
            yield return new WaitForSeconds(0.5f);
            ActivateButton();
        }

        IEnumerator EndDelay()
		{
            yield return new WaitForSeconds(1);
            SceneChanger.LoadLevel("Cabin_Bigger_Room");
		}
    }
}
