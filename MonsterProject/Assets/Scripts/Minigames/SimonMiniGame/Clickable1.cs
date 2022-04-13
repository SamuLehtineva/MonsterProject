using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class Clickable1 : MonoBehaviour
    {
        void Update()
        {

        }
        void OnMouseDown()
        {
            gameObject.SetActive(false);
        }
    }
}
