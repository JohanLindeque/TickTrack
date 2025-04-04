using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    _exportFilePath = Directory.GetCurrentDirectory();
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




    }
}
