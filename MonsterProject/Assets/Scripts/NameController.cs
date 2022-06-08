using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GA.MonsterProject
{
    public class NameController : MonoBehaviour
    {
        [SerializeField]
        TMP_Text m_txtInput;

		public void ChangeName()
        {
            GameManager.m_sPetName = m_txtInput.text;
            Debug.Log(GameManager.m_sPetName);
            SceneChanger.LoadLevel("Cabin");
        }
    }
}
