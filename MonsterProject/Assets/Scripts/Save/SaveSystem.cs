using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

namespace GA.MonsterProject
{
    public class SaveSystem : MonoBehaviour
    {
        public string m_sSaveFolder
        {
            get 
            {
                string sDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return Path.Combine(sDocuments, "MonsterGame", "Save");
            }
        }

        public string m_sSaveName
        {
            get
            {
                return "Save.dat";
            }
        }

        void Save()
        {
            Debug.Log("save");

            ISaveWriter writer = new BinarySaver();
            if (!writer.PrepareWrite(Path.Combine(m_sSaveFolder, m_sSaveName)))
            {
                return;
            }

            ISaveable[] aSaveables = FindObjectsOfType(typeof(ISaveable)) as ISaveable[];
            writer.WriteInt(aSaveables.Length);

            foreach (var item in aSaveables)
            {
                item.Save(writer);
            }

            writer.FinalizeWrite();
        }

        void Load()
        {

        }
    }
}
