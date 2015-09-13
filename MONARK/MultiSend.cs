using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONARK
{
    class MultiSend
    {
        private List<string> Recievers;

        public MultiSend(string resCsv)
        {
            Recievers = new List<string>();
            ReadCsvList(resCsv);
        } 

        public bool Send(List<String> res, string sender, string msg)
        {
            foreach (var number in Recievers)
            {
                string urlToApi = "...";
                HttpRequest HTTP = new HttpRequest();
                string ret = HTTP.GrabData(urlToApi);

                if (ret != "0")
                {
                    // Return error
                }
            }
            return true;
        }

        private List<string> ReadCsvList(string location)
        {
            var reader = new StreamReader(File.OpenRead(@location));
            List<string> listB = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (IsDigitsOnly(line) && line.Length == 8)
                {
                    Recievers.Add(line);
                }
                else
                {
                    // Throw errorcode-
                }
                
                
            }
            return Recievers;
        }

        private bool IsDigitsOnly(string str)

        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
