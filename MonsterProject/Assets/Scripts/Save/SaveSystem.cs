using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;

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

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Save();
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                Load();
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

            ISaveable[] aSaveables = FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>().ToArray();
            writer.WriteInt(aSaveables.Length);

            foreach (var item in aSaveables)
            {
                item.Save(writer);
            }

            writer.FinalizeWrite();
        }

        void Load()
        {
            Debug.Log("load");
            ISaveReader reader = new BinarySaver();
            if (!reader.PrepareRead(Path.Combine(m_sSaveFolder, m_sSaveName)))
            {
                return;
            }

            ISaveable[] aSaveables = FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>().ToArray();
            int iSavedCount = reader.ReadInt();
            for (int i = 0; i < iSavedCount; i++)
            {
                aSaveables[i].Load(reader);
            }

            reader.FinalizeRead();
        }
    }
}
