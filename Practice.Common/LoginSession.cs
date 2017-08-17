using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWeb.Common
{
    public class LoginSession
    {
        public LoginSession()
        {

        }

        public string CompanyName { get; set; }
        public User UserInfo { get; set; }
    }

    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
