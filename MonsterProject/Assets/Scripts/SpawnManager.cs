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
        Dictionary<string, Vector3> m_dSpawnPoints = new Dictionary<string, Vector3>();


        void Start() {

            SpawnPoint[] points = FindObjectsOfType(typeof(SpawnPoint)) as SpawnPoint[];
            Debug.Log(points.Length);

            for (int i = 0; i < points.Length; i++)
            {
                try
                {
                    m_dSpawnPoints.Add(points[i].m_sSpawnName, points[i].transform.position);
                }
                catch (ArgumentException)
                {
                    Debug.Log("Each spawn point must have a unique name");
                }
            }

            try
            {
                m_gcPlayer.transform.position = m_dSpawnPoints[GameManager.m_sDestination];
            }
            catch (KeyNotFoundException)
            {
                Debug.Log("Spawn manager cant find a spawn with the name: " + GameManager.m_sDestination);
            }
            
        }
        
    }
}
