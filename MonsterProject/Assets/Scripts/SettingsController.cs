using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GA.MonsterProject
{
    public class SettingsController : MonoBehaviour
    {
        [SerializeField]
        Slider m_gcMusicSlider;

        void Start()
        {
            if (PlayerPrefs.HasKey("MusicVolume"))
            {
                m_gcMusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            }
            else
            {
                m_gcMusicSlider.value = 0.5f;
            }
        }

        public void SetMusicVolume()
        {
            PlayerPrefs.SetFloat("MusicVolume", m_gcMusicSlider.value);
        }

        public void CloseSettings()
        {
            SceneChanger.UnloadLevelAsync("Settings");
        }
    }
}
