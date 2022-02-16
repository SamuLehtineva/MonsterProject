using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class Interactable : MonoBehaviour
    {
        void Update()
        {
            LoadNarrative();
        }
        public void LoadNarrative()
        {
                if (Input.GetKey(KeyCode.E))
                {
                    var SceneLoad = SceneManager.LoadSceneAsync("NarrativeBox", LoadSceneMode.Additive);
                    Time.timeScale = 0f;
                }
        }
    }
}




