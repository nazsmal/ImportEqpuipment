using System;
using System.IO;

namespace ImportEqpuipment
{
    public class LogFile : IDisposable
    {
        StreamWriter file;

        public string FileName { get; private set; }

        public LogFile()
        {
            CreateFile();
        }

        ~LogFile()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (file != null)
            {
                file.Close();
            }
        }

        private void CreateFile()
        {
            FileName = Path.GetTempFileName();
            file = File.CreateText(FileName);
        }

        public void Write(string text)
        {
            file.WriteLine(text);
        }
    }
}
