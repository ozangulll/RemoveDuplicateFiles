using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RemoveDuplicate
{
    internal class FileHandler
    {
        private string _directoryPath;
        private Dictionary<string, string> _fileNames;
        private Regex _duplicateFilePattern;

        public FileHandler(string directoryPath)
        {
            _directoryPath = directoryPath;
            _fileNames = new Dictionary<string, string>();
            _duplicateFilePattern = new Regex(@"\s\(\d+\)$");
        }

        public void RemoveDuplicateFilesByName()
        {
            var files = Directory.GetFiles(_directoryPath);
            bool hasDuplicates = false;

            foreach (var file in files)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                string fileExtension = Path.GetExtension(file);
                string baseFileName = _duplicateFilePattern.Replace(fileNameWithoutExtension, "");
                string fullBaseFileName = baseFileName + fileExtension;

                if (_fileNames.ContainsKey(fullBaseFileName))
                {
                    Console.WriteLine($"Duplicate file found: {file}");
                    File.Delete(file);
                    hasDuplicates = true;
                }
                else
                {
                    _fileNames[fullBaseFileName] = file;
                }
            }

            if (hasDuplicates)
            {
                Console.WriteLine("Duplicate files removed.");
            }
            else
            {
                Console.WriteLine("There are no duplicate files.");
            }
        }
    }
}



