using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class AreaExit : MonoBehaviour
    {
        [SerializeField]
        string m_sTargetAreaName;
        
        void OnTriggerEnter(Collider other) {
            if (other.tag == "Player")
            {
                SceneManager.LoadScene(m_sTargetAreaName);
            }
        }
    }
}
