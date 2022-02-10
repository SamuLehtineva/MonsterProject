using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{

    public class PlayerCollision : MonoBehaviour
    {
        public Interactable interactable;

        private bool InArea = false;

        private void OnTriggerEnter()
        {
            Debug.Log("TriggerEnter");
            InArea = true;
            if(InArea == true)
            {
                Debug.Log("InArea=True");
                interactable.PauseForNarrative();
            }
            InArea = false;
        }




    }
}
