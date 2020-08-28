using System;
using System.Collections.Generic;
using System.Text;

namespace Trike.ResponseModels
{
    public class GetUserByDetailReponseModel
    {
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class UserData
    {
        public int userId { get; set; }
        public object firstName { get; set; }
        public object lastName { get; set; }
        public object mobile { get; set; }
        public object email { get; set; }
        public DateTime createdOn { get; set; }
    }

    public class Root
    {
        public bool isSuccess { get; set; }
        public string messgae { get; set; }
        public UserDetails userDetails { get; set; }
    }


}
