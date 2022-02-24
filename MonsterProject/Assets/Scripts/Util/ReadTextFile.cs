using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace GA.MonsterProject
{
    public class ReadTextFile
    {
        string m_sFileContents;
        string[] m_sLines;

        public ReadTextFile(string filename)
        {
            StreamReader srReader = new StreamReader(Application.dataPath + "/TextFiles/" + filename);
            m_sFileContents = srReader.ReadToEnd();
            srReader.Close();

            m_sLines = m_sFileContents.Split("\n"[0]);
        }

        public string GetLine(int line) 
        {
            return m_sLines[line -1];
        }

        public string[] GetLines()
        {
            return m_sLines;
        }
    }
}
