using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FileParserNetStandard {
    public delegate List<List<string>> Parser(List<List<string>> data);
    public class CsvHandler {
        
        /// <summary>
        /// Takes a list of list of strings applies datahandling via dataHandler delegate and writes result as csv to writeFile.
        /// </summary>
        /// <param name="readFile"></param>
        /// <param name="writeFile"></param>
        /// <param name="dataHandler"></param>
        public void ProcessCsv(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>>  dataHandler) {
            var fileHandler = new FileHandler();
            try
            {
                var csv = fileHandler.ReadFile(readFile);
                var data = fileHandler.ParseCsv(csv);
                dataHandler(data);
                fileHandler.WriteFile(writeFile, ',', data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ProcessCsv(string readFile, string writeFile, Parser dataHandler)
        {
            var fileHandler = new FileHandler();
            try
            {
                var csv = fileHandler.ReadFile(readFile);
                var data = fileHandler.ParseCsv(csv);
                dataHandler(data);
                fileHandler.WriteFile(writeFile, ',', data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}