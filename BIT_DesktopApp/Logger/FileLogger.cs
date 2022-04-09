using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.Logger
{
    public class FileLogger : LogBase
    {
        string filePath = @"log.txt";
        public override void Log(string message)
        {
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
}
