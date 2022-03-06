using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class AreaExit : MonoBehaviour
    {
        [SerializeField]
        string m_sTargetSceneName;

        [SerializeField]
        string m_sTargetSpawnName;
        
        void OnTriggerEnter(Collider other) {
            if (other.tag == "Player")
            {
                SceneManager.LoadScene(m_sTargetSceneName);
                GameManager.m_sDestination = m_sTargetSpawnName;
                Debug.Log(GameManager.m_sDestination);
            }

            
        }
    }
}
