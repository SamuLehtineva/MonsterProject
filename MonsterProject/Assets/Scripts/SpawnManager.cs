using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace GA.MonsterProject
{
    public class SpawnManager : MonoBehaviour
    {
        Dictionary<string, Vector3> m_dSpawnPoints = new Dictionary<string, Vector3>();

        void Start() {
            SpawnPoint[] points = FindObjectsOfType(typeof(SpawnPoint)) as SpawnPoint[];

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
        }
        
    }
}
