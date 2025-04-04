using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTrack.TaskProcessing
{
    class FileHandler
    {
        public bool CheckIfFileExists(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                Console.WriteLine(ex);
            }
        }

        public bool CheckIfFolderExist(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                Console.WriteLine(ex);
            }
        }
    }
}
