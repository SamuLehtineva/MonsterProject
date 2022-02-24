using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class Interactable : MonoBehaviour
    {
        public LayerMask interactableLayermask;

        void Update()
        {
            RaycastHit hit;

            if(Physics.Raycast(transform.position,Vector3.forward, out hit, 2, interactableLayermask))
            {
                Debug.Log("hit");
                LoadNarrative();
            }
            
        }
        public void LoadNarrative()
        {
                if (Input.GetButtonDown("Fire1"))
                {
                    var SceneLoad = SceneManager.LoadSceneAsync("NarrativeBox", LoadSceneMode.Additive);
                    SceneLoad.completed += (s) => {
                        //SceneManager.GetSceneByName("NarrativeBox").GetRootGameObjects()[0].gameObject.SetActive(false);
                        SceneManager.GetSceneByName("NarrativeBox").GetRootGameObjects()[0].gameObject.transform.position = GameObject.Find("Main Camera").transform.position;
                        SceneManager.GetSceneByName("NarrativeBox").GetRootGameObjects()[0].gameObject.transform.rotation = GameObject.Find("Main Camera").transform.rotation;
                    };
                    Time.timeScale = 0f;
                }
        }
    }
}




