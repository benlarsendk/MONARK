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
        private string api;

        public MultiSend(string resCsv, string apikey)
        {
            api = apikey;
            Recievers = new List<string>();
            ReadCsvList(resCsv);
        } 

        public bool Send(string sender, string msg)
        {
            foreach (var number in Recievers)
            {
                string urlToApi = "http://www.smsit.dk/api/sendSms.php?apiKey=" + api + "&charset=UTF-8&senderId=" + sender + "&mobile=45" + number + "&message=" + msg;
                HttpRequest HTTP = new HttpRequest();
                string ret = HTTP.GrabData(urlToApi);

                if (ret != "0")
                {
                    System.Windows.MessageBox.Show("Server returned: " + ret); 
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
                    System.Windows.MessageBox.Show("Number is not didgits or not a valid number ( 8 ciffers)" );
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
