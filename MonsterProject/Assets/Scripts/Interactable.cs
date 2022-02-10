using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class Interactable : MonoBehaviour
    {
        private bool LoadNarrative;
        private bool InArea = false;

        private void OnTriggerEnter()
        {
            Debug.Log("OnTriggerEnter");
            InArea = true;
            if (InArea == true)
            {
                Debug.Log("InArea=True");
                PauseForNarrative();
            }
            InArea = false;
        }
        public void PauseForNarrative()
        {

            if (Input.GetKey(KeyCode.E))
            {
                var SceneLoad = SceneManager.LoadSceneAsync("NarrativeBox", LoadSceneMode.Additive);
                LoadNarrative = true;
                Time.timeScale = 0f;
                Debug.Log("KeyCodeE");

            }
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.UnloadSceneAsync("NarrativeBox");
                LoadNarrative = false;
                Time.timeScale = 1f;
                Debug.Log("KeyCodeEsc");
            }
        }




    }
}




