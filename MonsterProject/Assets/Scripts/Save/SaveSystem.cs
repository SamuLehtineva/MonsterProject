using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public class SaveSystem : MonoBehaviour
    {
        void Save()
        {
            ISaveable[] aSaveables = FindObjectsOfType(typeof(ISaveable)) as ISaveable[];
        }

        void Load()
        {

        }
    }
}
