using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FileParserNetStandard {
    public class DataParser {
        

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data)
        {
//            data = data.Select(d => 
//                d.Select(s => 
//                    s.Replace(" ", String.Empty))
//                .ToList())
//            .ToList();
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Count; j++)
                {
                    data[i][j] = data[i][j].Replace(" ", String.Empty);
                }
            }
            return data;
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {
//            data = data.Select(d => d
//                    .Select(s => s
//                        .Replace("\"", String.Empty))
//                    .ToList())
//                .ToList();
//            return data;
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Count; j++)
                {
                    data[i][j] = data[i][j].Replace("\"", String.Empty);
                }
            }

            return data;
        }

    }
}