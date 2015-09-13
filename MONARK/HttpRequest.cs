using System.IO;
using System.Net;

namespace MONARK
{
    internal class HttpRequest
    {
        public string GrabData(string url)
        {
            var req = WebRequest.Create(url);
            var resp = req.GetResponse();
            var sr = new StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
    }
}