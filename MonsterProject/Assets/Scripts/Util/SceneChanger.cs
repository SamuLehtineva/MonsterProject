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

        public static void LoadLevelAsync(string LevelName)
        {
            SceneManager.LoadSceneAsync(LevelName, LoadSceneMode.Additive);
        }

        public static void UnloadLevelAsync(string LevelName)
        {
            SceneManager.UnloadSceneAsync(LevelName);
        }

        public void CloseApp()
        {
            Application.Quit();
        }
    }
}
