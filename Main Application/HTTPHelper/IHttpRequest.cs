using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTube.HTTPHelper
{
    public interface IHttpRequest
    {
        Uri Uri
        {
            get;
        }
        Encoding Encoding
        {
            get;
        }
        object Tag
        {
            get;
        }
        int ConnectionTimeout
        {
            get;
        }
        bool ResponseAsStream
        {
            get;
        }
    }
}
