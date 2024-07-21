using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using RemoveDuplicate;

class Program
{
    static void Main()
    {
        string directoryPath = @"C:\Users\Acer\Desktop\asa"; // Kendi dizin yolunuzu buraya yazın
        FileHandler fileHandler = new FileHandler(directoryPath);
        fileHandler.RemoveDuplicateFilesByName();
    }

    
}
