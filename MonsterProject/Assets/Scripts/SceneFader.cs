using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class SceneFader : MonoBehaviour
    {
        SceneChanger m_gcChanger;

        void Start()
        {
            m_gcChanger.LoadFadeIn();
        }
    }
}
