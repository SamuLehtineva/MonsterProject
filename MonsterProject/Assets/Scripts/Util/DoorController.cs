using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class DoorController : MonoBehaviour, IInteractables
    {
        public bool IsActive
        {
            get;
            set;
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Activate()
        {
            if (!IsActive)
            {
                transform.Rotate(0, 90, 0);
                Debug.Log("Jee");
                IsActive = true;
            }
            
        }

        public void DeActivate()
        {

        }

        public void Interact()
        {

        }
    }
}
