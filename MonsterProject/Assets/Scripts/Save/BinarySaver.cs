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
            m_Writer.Close();
            m_FileStream.Close();
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
            try 
            {
                string sDirectory = Path.GetDirectoryName(path);
                if (!Directory.Exists(sDirectory))
                {
                    Directory.CreateDirectory(sDirectory);
                }

                m_FileStream = File.Open(path, FileMode.Create);
                m_Writer = new BinaryWriter(m_FileStream);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return false;
            }
            return true;
        }

        public bool ReadBool()
        {
            return m_Reader.ReadBoolean();
        }

        public float ReadFloat()
        {
            return m_Reader.ReadSingle();
        }

        public int ReadInt()
        {
            return m_Reader.ReadInt32();
        }

        public Types.EStatus ReadStatus()
        {
            int val = m_Reader.ReadInt32();
            return (Types.EStatus)val;
        }

        public string ReadString()
        {
            return m_Reader.ReadString();
        }

        public Vector3 ReadVector3()
        {
            float x = m_Reader.ReadSingle();
            float y = m_Reader.ReadSingle();
            float z = m_Reader.ReadSingle();
            return new Vector3(x, y, z);
        }

        public void WriteBool(bool value)
        {
            m_Writer.Write(value);
        }

        public void WriteFloat(float value)
        {
            m_Writer.Write(value);
        }

        public void WriteInt(int value)
        {
            m_Writer.Write(value);
        }

        public void WriteStatus(Types.EStatus value)
        {
            m_Writer.Write((int)value);
        }

        public void WriteString(string value)
        {
            m_Writer.Write(value);
        }

        public void WriteVector3(Vector3 value)
        {
            m_Writer.Write(value.x);
            m_Writer.Write(value.y);
            m_Writer.Write(value.z);
        }
    }
}
