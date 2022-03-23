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

        private List<GameObject> m_lTriggers = new List<GameObject>();

        void Update()
        {
            if (m_lTriggers.Count > 0)
            {
                m_gcCanvas.gameObject.SetActive(true);
            }
            else
            {
                m_gcCanvas.gameObject.SetActive(false);
            }
        }
        private void OnTriggerEnter(Collider other) {
            IInteractables mytest = other.gameObject.GetComponent(typeof(IInteractables)) as IInteractables;
            if (mytest is IInteractables)
            {
                mytest.Activate();
                m_lTriggers.Add(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other) {
            IInteractables mytest = other.gameObject.GetComponent(typeof(IInteractables)) as IInteractables;
            if (mytest is IInteractables)
            {
                mytest.DeActivate();
                m_lTriggers.Remove(other.gameObject);
            }
        }
    }
}




