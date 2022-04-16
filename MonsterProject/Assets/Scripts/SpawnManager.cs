using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

namespace GA.MonsterProject
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        Transform m_gcPlayer;
        Transform[] m_aSpawnPoints;
        private CharacterController m_gcController;

        void Start() {
            m_gcController = m_gcPlayer.GetComponent<CharacterController>();
            m_gcController.gameObject.SetActive(false);
            m_aSpawnPoints = new Transform[transform.childCount];

            for (int i = 0; i < m_aSpawnPoints.Length; i++)
            {
                try
                {
                    m_aSpawnPoints[i] = transform.GetChild(i);
                }
                catch (ArgumentException)
                {
                    Debug.Log("Each spawn point must have a unique name");
                }
            }

            try
            {
                foreach (Transform item in m_aSpawnPoints)
                {
                    if (item.name.Equals(GameManager.m_sDestination))
                    {
                        m_gcPlayer.position = item.position;
                        m_gcPlayer.forward = item.forward;
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                Debug.Log("Spawn manager cant find a spawn with the name: " + GameManager.m_sDestination);
            }

            m_gcController.gameObject.SetActive(true);
            
        }    
    }
}
