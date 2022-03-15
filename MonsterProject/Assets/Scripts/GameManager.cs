using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class GameManager : MonoBehaviour
    {
        public static string m_sDestination;

        void Awake()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        }
    }
}
