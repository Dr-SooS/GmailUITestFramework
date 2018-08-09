using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework.Models
{
    public class UserCreds
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override bool Equals(object obj)
        {
            var ud = (UserCreds) obj;
            return ud.Email.Equals(Email) && ud.FirstName.Equals(FirstName) && ud.LastName.Equals(LastName);
        }
    }
}
