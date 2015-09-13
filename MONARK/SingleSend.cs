using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONARK
{
    class SingleSend
    {
        private string UrlToApi;
        public bool Send(string reciever, string sender, string msg)
        {
            if (!IsDigitsOnly(reciever) || sender == null || msg == null)
            {
                System.Windows.MessageBox.Show("Number is not valid");
                return false;
            }
            else
            {
                UrlToApi = "...."; // Not implemented
                HttpRequest HTTP = new HttpRequest();
                string ret = HTTP.GrabData(UrlToApi);

                if (ret != "0")
                {
                    System.Windows.MessageBox.Show("Server returned: " + ret);
                }
                return true;
            }
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
