using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace MONARK
{
    internal class MultiSend
    {
        private readonly string api;
        private readonly List<string> Recievers;

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
                var urlToApi = "http://www.smsit.dk/api/sendSms.php?apiKey=" + api + "&charset=UTF-8&senderId=" + sender +
                               "&mobile=45" + number + "&message=" + msg;
                var HTTP = new HttpRequest();
                var ret = HTTP.GrabData(urlToApi);

                if (ret != "0")
                {
                    MessageBox.Show("Server returned: " + ret);
                }
            }
            return true;
        }

        private List<string> ReadCsvList(string location)
        {
            var reader = new StreamReader(File.OpenRead(@location));
            var listB = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (IsDigitsOnly(line) && line.Length == 8)
                {
                    Recievers.Add(line);
                }
                else
                {
                    MessageBox.Show("Number is not didgits or not a valid number ( 8 ciffers)");
                }
            }
            return Recievers;
        }

        private bool IsDigitsOnly(string str)

        {
            foreach (var c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}