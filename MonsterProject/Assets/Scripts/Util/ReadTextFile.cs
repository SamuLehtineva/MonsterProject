using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace GA.MonsterProject
{
    public class ReadTextFile : MonoBehaviour
    {
        string m_sFileName = "dialog.txt";
        string m_sFileContents;
        string[] m_sLines;
        void Start()
        {
            StreamReader srReader = new StreamReader(Application.dataPath + "/TextFiles/" + m_sFileName);
            m_sFileContents = srReader.ReadToEnd();
            srReader.Close();

            m_sLines = m_sFileContents.Split("\n"[0]);

        }

        public string GetLine(int line) {
            return m_sLines[line -1];
        }
    }
}
