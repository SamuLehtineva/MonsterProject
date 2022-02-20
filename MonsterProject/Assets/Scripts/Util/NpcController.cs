using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class NpcController : MonoBehaviour, IInteractables
    {
        public bool IsActive
        {
            get;
            set;
        }
        // Start is called before the first frame update
        void Start()
        {
            IsActive = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Interact();
            }
            
        }

        public void Activate()
        {
            if (!IsActive)
            {
                IsActive = true;
            }
        }

        public void DeActivate()
        {
            if (IsActive)
            {
                IsActive = false;
            }
        }

        public void Interact()
        {
            if (IsActive) {
                var SceneLoad = SceneManager.LoadSceneAsync("NarrativeBox", LoadSceneMode.Additive);
                    SceneLoad.completed += (s) => {
                        SceneManager.GetSceneByName("NarrativeBox").GetRootGameObjects()[0].gameObject.SetActive(false);
                    };
                Time.timeScale = 0f;
            }
        }
    }
}
