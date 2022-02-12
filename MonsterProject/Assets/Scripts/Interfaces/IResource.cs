using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public interface IResource
    {
        int CurrentAmount
        {
            get;
        }

        int MaxAmount
        {
            get;
        }

        int MinAmount
        {
            get;
        }

        void IncreaseAmount(int amount);
        void DecreaseAmount(int amount);
    }
}
