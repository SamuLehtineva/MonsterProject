using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    /*
    Interface for objects that need to save data
    */
    public interface ISaveable
    {
        void Save(ISaveWriter writer);
        void Load(ISaveReader reader);
    }
}
