using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NarrativeController : MonoBehaviour
{

    private bool LoadNarrative;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }

    public void Pause()
    {
        if (Input.GetKey(KeyCode.E))
        {
            var SceneLoad = SceneManager.LoadSceneAsync("NarrativeBox", LoadSceneMode.Additive);
            LoadNarrative = true;
            Time.timeScale = 0f;

        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.UnloadSceneAsync("NarrativeBox");
            LoadNarrative = false;
            Time.timeScale = 1f;
        }
    }
}