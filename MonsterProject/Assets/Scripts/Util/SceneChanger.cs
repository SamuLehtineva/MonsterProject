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
            if (!SceneManager.GetSceneByName(LevelName).isLoaded)
            {
                SceneManager.LoadSceneAsync(LevelName, LoadSceneMode.Additive);
            }
        }

        public static void LoadLevelAdditive(string LevelName)
        {
            if (!SceneManager.GetSceneByName(LevelName).isLoaded)
            {
                SceneManager.LoadScene(LevelName, LoadSceneMode.Additive);
            }
        }

        public static void UnloadLevelAsync(string LevelName)
        {
            SceneManager.UnloadSceneAsync(LevelName);
        }

        public void LoadWithFade(string LevelName)
        {
            GameManager.s_GameManager.PlayerCanMove(false);
            UIManager.s_UIManager.m_gcMusicController.FadeOut();
            StartCoroutine(LoadAsyncScene(LevelName));
        }

        IEnumerator LoadAsyncScene(string sceneName)
        {
            AsyncOperation asyncLoadFade = SceneManager.LoadSceneAsync("Transitions", LoadSceneMode.Additive);

            while (!asyncLoadFade.isDone)
            {
                yield return null;
            }

            yield return new WaitForSeconds(2);
            SceneManager.LoadSceneAsync(sceneName);
        }

        public void CloseApp()
        {
            Application.Quit();
        }
    }
}
