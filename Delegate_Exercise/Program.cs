using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;

namespace Delegate_Exercise {

    internal class Delegate_Exercise
    {
        private static readonly string readFilePath = "/Users/richard/dev/Dip-Seminar-Delegates-Lambda-Linq_Exercises/Files/data.csv";
        private static readonly string writeFilePath = "/Users/richard/dev/Dip-Seminar-Delegates-Lambda-Linq_Exercises/Files/processed_data.csv";
        private static readonly string optionalWriteFilePath = "/Users/richard/dev/Dip-Seminar-Delegates-Lambda-Linq_Exercises/Files/processed_data_optional.csv";

        public static void Main(string[] args)
        {
            var csvHandler = new CsvHandler();
            
            var genericParser = CreateGenericParser();
            csvHandler.ProcessCsv(readFilePath, writeFilePath, genericParser);

            var parser = CreateParser();
            csvHandler.ProcessCsv(readFilePath, optionalWriteFilePath, parser);
        }

        private static Func<List<List<string>>, List<List<string>>> CreateGenericParser()
        {
            var dataParser = new DataParser();
            var genericParser = new Func<List<List<string>>, List<List<string>>>(dataParser.StripWhiteSpace);
            genericParser += dataParser.StripQuotes;
            genericParser += RemoveHashTag;
            return genericParser;
        }
        
        private static Parser CreateParser()
        {
            var dataParser = new DataParser();
            var parser = new Parser(dataParser.StripWhiteSpace);
            parser += dataParser.StripQuotes;
            parser += RemoveHashTag;
            parser += Capitalise;
            return parser;
        }

        private static List<List<string>> RemoveHashTag(List<List<string>> data)
        {
//            data = data.Select(d => d
//                .Select(s => s
//                    .Replace("#", ""))
//                .ToList())
//                .ToList();
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Count; j++)
                {
                    data[i][j] = data[i][j].Replace("#", String.Empty);
                }
            }
            return data;
        }

        private static List<List<string>> Capitalise(List<List<string>> data)
        {
//            data = data.Select((d, dIndex) => d
//                .Select(s => s
//                    .ToUpper())
//                .ToList())
//                .ToList();
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Count; j++)
                {
                    data[i][j] = data[i][j].ToUpper();
                }
            }
            return data;
        }
    }
}