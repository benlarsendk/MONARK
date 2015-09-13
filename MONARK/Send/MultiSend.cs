using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace MONARK
{
    internal class MultiSend : ISend
    {
        private string[] receivers;
        private IAPI api;

        public MultiSend(IAPI api)
        {
            receivers = new List<string>();
            this.api = api;
        }

        public bool Send(string receiverListLocation, string sender, string msg)
        {
            receivers = receiver.Split(';');

            foreach (var person in receivers)
            {
                var apiUrl = api.GenerateUrl(person, sender, msg);
                var http = new HttpRequest();
                string ret = http.GrabData(apiUrl);

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
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
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
    }
}