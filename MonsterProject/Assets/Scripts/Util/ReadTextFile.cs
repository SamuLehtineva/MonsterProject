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
            //Debug.Log(Application.dataPath);
            
            TextAsset file = (TextAsset)Resources.Load(filename, typeof(TextAsset));
            m_sFileContents = file.text;

            m_sLines = m_sFileContents.Split("\n"[0]);
            for (int i = 0; i < m_sLines.Length; i++)
            {
                m_sLines[i] = m_sLines[i].Replace("!MonsterName!", GameManager.m_sPetName);
            }
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
