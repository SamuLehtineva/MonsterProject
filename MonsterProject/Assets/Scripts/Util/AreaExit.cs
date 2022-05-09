using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class AreaExit : MonoBehaviour
    {
        [SerializeField]
        string m_sTargetSceneName;

        [SerializeField]
        string m_sTargetSpawnName;

        public SceneChanger m_gcChanger;

        void Start()
        {
            m_gcChanger = GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>();
        }
        
        void OnTriggerEnter(Collider other) {
            if (other.tag == "Player")
            {
                GameManager.m_sDestinationScene = m_sTargetSceneName;
                GameManager.m_sDestination = m_sTargetSpawnName;
                m_gcChanger.LoadWithFade(m_sTargetSceneName);
                Debug.Log(GameManager.m_sDestination);
            }
        }
    }
}
