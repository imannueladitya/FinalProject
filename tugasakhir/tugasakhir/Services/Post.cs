using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace tugasakhir.Services
{
    class Post
    {
        public string email { get; set; }
        public string password { get; set; }
        public string success { get; set; }




        public override string ToString()
        {
            return string.Format(
                "email: {0}\npassword: {1}\nsuccess: {2}",
                email, password, success);
        }
    }
}
