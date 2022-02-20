using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class DoorController : MonoBehaviour, IInteractables
    {
        Animator m_aDoorAnimator;
        public bool IsActive
        {
            get;
            set;
        }
        // Start is called before the first frame update
        void Start()
        {
            m_aDoorAnimator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Interact();
            }
        }

        public void Activate()
        {
            if (!IsActive)
            {
                m_aDoorAnimator.Play("Door_Open", 0, 0.0f);
                Debug.Log("Jee");
                IsActive = true;
            }
            
        }

        public void DeActivate()
        {
            if (IsActive)
            {
                m_aDoorAnimator.Play("Door_Close", 0, 0.0f);
                IsActive = false;
            }
        }

        public void Interact()
        {
            if (IsActive)
            {
                SceneManager.LoadScene("Cabin");
            }
        }
    }
}
