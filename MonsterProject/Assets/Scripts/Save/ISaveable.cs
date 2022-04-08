using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public interface ISaveable
    {
        void Save(ISaveWriter writer);
        void Load(ISaveReader reader);
    }
}
