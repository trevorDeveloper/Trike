using System;
using System.Collections.Generic;
using System.Text;

namespace Trike.ResponseModels
{
    public class ClientTokenResponseModel
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public string clientToken { get; set; }
    }
}
