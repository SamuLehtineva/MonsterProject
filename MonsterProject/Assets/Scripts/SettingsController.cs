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

        public void SetMusicVolume()
        {
            PlayerPrefs.SetFloat("MusicVolume", m_gcMusicSlider.value);
            Debug.Log(PlayerPrefs.GetFloat("MusicVolume"));
        }
    }
}
