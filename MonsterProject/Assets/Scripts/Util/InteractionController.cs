using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class InteractionController : MonoBehaviour
    {

        [SerializeField]
        Canvas m_gcCanvas;

        bool m_bCanInteract;

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




