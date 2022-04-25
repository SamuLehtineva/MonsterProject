using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA.MonsterProject
{
    public static class Types
    {
        public enum EResource
        {
            _Money,
            _Reputation,
            _Bond,
        }

        public enum EStatus
        {
            _Inactive,
            _Active,
            _Completed,
            _Failed,
            _Done,
        }

        public enum EForm
        {
            _Baby,
            _Teen,
            _Bad,
            _Good,
        }
    }
}
