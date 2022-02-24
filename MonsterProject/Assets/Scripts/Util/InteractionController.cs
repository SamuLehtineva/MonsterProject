using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class InteractionController : MonoBehaviour
    {
        [SerializeField]
        Canvas m_gcCanvas;
        public LayerMask interactableLayermask;

        void Update()
        {
            RaycastHit hit;

            if(Physics.Raycast(transform.position,Vector3.forward, out hit, 2, interactableLayermask))
            {
                //LoadNarrative();
            }
            
        }
        public void LoadNarrative()
        {
                if (Input.GetButtonDown("Fire1"))
                {
                    var SceneLoad = SceneManager.LoadSceneAsync("NarrativeBox", LoadSceneMode.Additive);
                    SceneLoad.completed += (s) => {
                        SceneManager.GetSceneByName("NarrativeBox").GetRootGameObjects()[0].gameObject.SetActive(false);
                    };
                    Time.timeScale = 0f;
                }
        }

        private void OnTriggerEnter(Collider other) {
            IInteractables mytest = other.gameObject.GetComponent(typeof(IInteractables)) as IInteractables;
            if (mytest is IInteractables)
            {
                mytest.Activate();
                m_gcCanvas.gameObject.SetActive(true);
            }
            
            Debug.Log(other.tag);
        }

        private void OnTriggerExit(Collider other) {
            IInteractables mytest = other.gameObject.GetComponent(typeof(IInteractables)) as IInteractables;
            if (mytest is IInteractables)
            {
                mytest.DeActivate();
                m_gcCanvas.gameObject.SetActive(false);
            }
        }
    }
}




