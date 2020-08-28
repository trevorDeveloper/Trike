using System;
using System.Collections.Generic;
using System.Text;

namespace Trike.RequestModels
{
    public class RegisterUserRequestModel
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
