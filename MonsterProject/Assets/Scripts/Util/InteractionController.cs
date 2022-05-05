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
        GameObject m_goInteraction;
        bool m_bCanInteract;
        
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                m_goInteraction.SetActive(false);
            }
        }
        private void OnTriggerEnter(Collider other) {
            IInteractables mytest = other.gameObject.GetComponent(typeof(IInteractables)) as IInteractables;
            if (mytest is IInteractables)
            {
                mytest.Activate();
                m_goInteraction.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other) {
            IInteractables mytest = other.gameObject.GetComponent(typeof(IInteractables)) as IInteractables;
            if (mytest is IInteractables)
            {
                mytest.DeActivate();
                m_goInteraction.SetActive(false);
            }
        }
    }
}




