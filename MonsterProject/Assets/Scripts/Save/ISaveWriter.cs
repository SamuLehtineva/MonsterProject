using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public interface ISaveWriter
    {
        bool PrepareWrite(string path);
        void FinalizeWrite();
        
        void WriteInt(int value);
        void WriteBool(bool value);
        void WriteString(string value);
        void WriteFloat(float value);
        void WriteStatus(Types.EStatus value);
        void WriteVector3(Vector3 value);
    }
}
