using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;

namespace GA.MonsterProject
{
    public class BinarySaver : ISaveReader, ISaveWriter
    {
        private BinaryReader m_Reader;
        private BinaryWriter m_Writer;
        private FileStream m_FileStream;

        public void FinalizeRead()
        {
            m_Reader.Close();
            m_FileStream.Close();
        }

        public void FinalizeWrite()
        {
            throw new System.NotImplementedException();
        }

        public bool PrepareRead(string savePath)
        {
            if (!File.Exists(savePath))
            {
                return false;
            }

            try
            {
                m_FileStream = File.OpenRead(savePath);
                m_Reader = new BinaryReader(m_FileStream);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return false;
            }

            return true;
        }

        public bool PrepareWrite(string path)
        {
            throw new System.NotImplementedException();
        }

        public bool ReadBool()
        {
            throw new System.NotImplementedException();
        }

        public float ReadFloat()
        {
            throw new System.NotImplementedException();
        }

        public int ReadInt()
        {
            throw new System.NotImplementedException();
        }

        public Types.EStatus ReadStatus()
        {
            throw new System.NotImplementedException();
        }

        public string ReadString()
        {
            throw new System.NotImplementedException();
        }

        public Vector3 ReadVector3()
        {
            throw new System.NotImplementedException();
        }

        public void WriteBool(bool value)
        {
            throw new System.NotImplementedException();
        }

        public void WriteFloat(float value)
        {
            throw new System.NotImplementedException();
        }

        public void WriteInt(int value)
        {
            throw new System.NotImplementedException();
        }

        public void WriteStatus(Types.EStatus value)
        {
            throw new System.NotImplementedException();
        }

        public void WriteString(string value)
        {
            throw new System.NotImplementedException();
        }

        public void WriteVector3(Vector3 value)
        {
            throw new System.NotImplementedException();
        }
    }
}
