using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GA.MonsterProject
{
    public class SceneChanger : MonoBehaviour
    {
        public static void LoadLevel(string LevelName)
        {
            SceneManager.LoadScene(LevelName);
        }

        public void CloseApp()
        {
            Application.Quit();
        }
    }
}
