using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public interface IInteractables
    {
        bool IsActive
        {
            get;
            set;
        }
        void Activate();
        void DeActivate();
        void Interact();
    }
}
