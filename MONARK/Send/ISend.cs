using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONARK
{
    interface ISend
    {
        /*!
        Send msg to receiver as receiver.
        */
        bool Send(string reciever, string sender, string msg);
    }
}
