using mshtml;
using SHDocVw;
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace MONARK
{
    class HttpRequest
    {
        private readonly InternetExplorer IE;

        public HttpRequest()
        {
            IE.Visible = false;
        }

        public string GrabData(string url)
        {

            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
    }
}
