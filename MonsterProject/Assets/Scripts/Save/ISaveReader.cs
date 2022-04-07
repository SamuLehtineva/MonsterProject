using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public interface ISaveReader
    {
        bool PrepareRead(string savePath);
        void FinalizeRead();

        int ReadInt();
        bool ReadBool();
        string ReadString();
        float ReadFloat();
        Types.EStatus ReadStatus();
        Vector3 ReadVector3();
    }
}
