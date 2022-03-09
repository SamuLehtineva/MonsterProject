using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class SimonSays : MonoBehaviour
    {
        public Animator anim;

        void OnMouseDown()
        {
            Action();
        }
        void Action()
        {
            anim.enabled = true;
            anim.SetTrigger("pop");
        }

    }

}
