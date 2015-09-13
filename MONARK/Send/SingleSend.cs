using System.Windows;

namespace MONARK
{
    internal class SingleSend : ISend
    {
        private IAPI api;

        public SingleSend(IAPI api)
        {
            this.api = api;
        }

        public bool Send(string receiver, string sender, string msg)
        {
            var apiUrl = api.GenerateUrl(receiver, sender, msg);
            var http = new HttpRequest();
            string ret = http.GrabData(apiUrl);

            if (ret != "0")
            {
                MessageBox.Show("Server returned: " + ret);
            }

            return true;
        }
    }
}