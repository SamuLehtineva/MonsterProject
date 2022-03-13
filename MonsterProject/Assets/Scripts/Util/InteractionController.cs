using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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




