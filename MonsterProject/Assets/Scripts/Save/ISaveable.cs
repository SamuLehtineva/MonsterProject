using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public interface ISaveable
    {
        void Save();
        void Load();
    }
}
