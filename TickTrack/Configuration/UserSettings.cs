using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickTrack.TaskProcessing;

namespace TickTrack.Configuration
{
    class UserSettings
    {
        private string _exportFileType;
        private string _exportFilePath;
        private bool _isFormattedExport;


        public string ExportFileType { get => _exportFileType; set => _exportFileType = value; }
        public string ExportFilePath { get => _exportFilePath;
            set {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine($"Export File Path not valid: {value}");
                    _exportFilePath = CreateDefaultExportPath();
                }
                else
                {
                    _exportFilePath = value;
                }
            }  }
        public bool IsFormattedExport { get => _isFormattedExport; set => _isFormattedExport = value; }

        public UserSettings(string exportFileType, string exportFilePath, bool isFormattedExport)
        {
            ExportFileType = exportFileType;
            ExportFilePath = exportFilePath;
            IsFormattedExport = isFormattedExport;
        }

        public void ImportUserSettings(string settingsFilePath)
        {

        }

        public void SaveUserSettings(string settingsFilePath)
        {

        }

        private string CreateDefaultExportPath()
        {
            FileHandler fileHandler = new FileHandler();

            string defaultDataPath = Path.Combine(Directory.GetCurrentDirectory(), $"Data");
            string defaultExportName = $"Export-{DateTime.Today.ToString(@"DD MMM YYYY")}";

            if (fileHandler.CheckIfFolderExist(defaultDataPath))
            {
                string defaultPath = Path.Combine(defaultDataPath, defaultExportName);
                if (fileHandler.CheckIfFileExists(defaultPath))
                {
                    return defaultPath;
                }
            }

            return "";
        }


    }
}
