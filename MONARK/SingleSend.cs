using System.Windows;

namespace MONARK
{
    internal class SingleSend
    {
        private string UrlToApi;

        public bool Send(string reciever, string sender, string msg, string api)
        {
            if (!IsDigitsOnly(reciever) || sender == null || msg == null)
            {
                MessageBox.Show("Number is not valid");
                return false;
            }
            UrlToApi = "http://www.smsit.dk/api/sendSms.php?apiKey=" + api + "&charset=UTF-8&senderId=" + sender +
                       "&mobile=45" + reciever + "&message=" + msg;
            var HTTP = new HttpRequest();

            var ret = HTTP.GrabData(UrlToApi);

            if (ret != "0")
            {
                MessageBox.Show("Server returned: " + ret);
            }
            return true;
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