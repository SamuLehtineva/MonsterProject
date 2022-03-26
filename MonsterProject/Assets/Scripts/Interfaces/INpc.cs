using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public interface INpc
    {
        string m_sFileName
        {
            get;
            set;
        }
        void PickOptionA();
        void PickOptionB();
    }
}
