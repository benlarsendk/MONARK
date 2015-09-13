using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONARK
{
    public interface IAPI
    {
        string GenerateUrl(string rec, string send, string msg);
    }


    public class SMSIT : IAPI
    {
        private string APIKey;

        public SMSIT(string API)
        {
            APIKey = API;
        }

        public string GenerateUrl(string rec, string send, string msg)
        {
            return "http://www.smsit.dk/api/sendSms.php?apiKey=" + APIKey + "&charset=UTF-8&senderId=" + send +
                       "&mobile=45" + rec + "&message=" + msg;
        }
    }


    public class TestAPI : IAPI
    {
        private string APIKey;

        public TestAPI(string API)
        {
            APIKey = API;
        }

        public string GenerateUrl(string rec, string send, string msg)
        {
            return "http://107.161.168.149/test/";
 
        }
    }
}


