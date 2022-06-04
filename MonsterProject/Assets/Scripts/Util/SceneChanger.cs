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

        public void LoadWithFadeOut(string LevelName)
        {
            GameManager.s_GameManager.PlayerCanMove(false);
            UIManager.s_UIManager.m_gcMusicController.FadeOut();
            StartCoroutine(LoadAsyncFadeOut(LevelName));
        }

        public void LoadFadeIn()
        {
            StartCoroutine(LoadAsyncFadeIn());
        }

        public void BattleStart(string LevelName)
        {
            GameManager.s_GameManager.PlayerCanMove(false);
            UIManager.s_UIManager.m_gcMusicController.FadeOut();
            StartCoroutine(LoadBattleStart(LevelName));
        }

        IEnumerator LoadAsyncFadeOut(string sceneName)
        {
            AsyncOperation asyncLoadFade = SceneManager.LoadSceneAsync("Transitions", LoadSceneMode.Additive);

            while (!asyncLoadFade.isDone)
            {
                yield return null;
            }

            yield return new WaitForSeconds(2);
            SceneManager.LoadSceneAsync(sceneName);
        }

        IEnumerator LoadAsyncFadeIn()
        {
            AsyncOperation asyncLoadFade = SceneManager.LoadSceneAsync("Transitions", LoadSceneMode.Additive);

            while (!asyncLoadFade.isDone)
            {
                yield return null;
            }

            SceneManager.GetSceneByName("Transitions").GetRootGameObjects()[0].GetComponent<FadeController>().FadeIn();
            yield return new WaitForSeconds(2);
            SceneManager.UnloadSceneAsync("Transitions");
        }

        IEnumerator LoadBattleStart(string scenename)
		{
            AsyncOperation asyncLoadBattle = SceneManager.LoadSceneAsync("Transition_2", LoadSceneMode.Additive);

            while (!asyncLoadBattle.isDone)
			{
                yield return null;
			}

            yield return new WaitForSeconds(2);
            SceneManager.LoadSceneAsync(scenename);
		}

        public void CloseApp()
        {
            Application.Quit();
        }
    }
}
