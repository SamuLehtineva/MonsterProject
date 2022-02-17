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
                Debug.Log(hit.collider.name);
                LoadNarrative();
            }
            
        }
        public void LoadNarrative()
        {
                if (Input.GetButtonDown("Fire1"))
                {
                    var SceneLoad = SceneManager.LoadSceneAsync("NarrativeBox", LoadSceneMode.Additive);
                    Time.timeScale = 0f;
                }
        }
    }
}




