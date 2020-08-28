using System;
using System.Collections.Generic;
using System.Text;

namespace Trike.ResponseModels
{
    public class LoginResponseModel
    {
        public bool issuccess { get; set; }
        public string messgae { get; set; }
        public string token { get; set; }
        public UserDetails userDetails { get; set; }
    }

    public class UserDetails
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public DateTime createdOn { get; set; }
    }
}
