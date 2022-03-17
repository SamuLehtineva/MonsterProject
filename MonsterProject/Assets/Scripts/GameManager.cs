using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class GameManager : MonoBehaviour
    {
        public static string m_sDestination;

        public static GameManager s_GameManager;

        void Awake()
        {
            if (s_GameManager != null)
            {
                Destroy(gameObject);
            }
            else
            {
                s_GameManager = this;
            }
            DontDestroyOnLoad(this);

            SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive);
            
        }
    }
}
