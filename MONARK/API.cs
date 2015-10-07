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
        string ApiKey { set; }
    }


    public class SMSIT : IAPI
    {
        public string ApiKey { set; private get; } = "";

	public SMSIT(string apieky) {
		ApiKey = apikey;
	}

        public string GenerateUrl(string receiver, string sender, string msg)
        {
            return "http://www.smsit.dk/api/sendSms.php?apiKey=" + ApiKey + "&charset=UTF-8&senderId=" + sender +
                       "&mobile=45" + receiver + "&message=" + msg;
        }


    }


    public class TestAPI : IAPI
    {
        public string ApiKey { set; private get; } = "";
    
        public string GenerateUrl(string receiver, string sender, string msg)
        {
            return "http://107.161.168.149/test/";
 
        }
    }
}


