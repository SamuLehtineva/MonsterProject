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

        [SerializeField]
        Slider m_gcEffectSlider;

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

            if (PlayerPrefs.HasKey("EffectVolume"))
            {
                m_gcEffectSlider.value = PlayerPrefs.GetFloat("EffectVolume");
            }
            else
            {
                m_gcEffectSlider.value = 0.5f;
            }
        }

        public void SetMusicVolume()
        {
            PlayerPrefs.SetFloat("MusicVolume", m_gcMusicSlider.value);
        }

        public void SetEffectVolume()
        {
            PlayerPrefs.SetFloat("EffectVolume", m_gcEffectSlider.value);
        }

        public void CloseSettings()
        {
            SceneChanger.UnloadLevelAsync("Settings");
        }
    }
}
