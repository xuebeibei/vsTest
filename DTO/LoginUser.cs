using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoginUser
    {
        public enum LoginStatus{ login, logout };
        public LoginUser()
        {
            this.Username = "Anonymous";
            this.Password = "";
            this.Status = LoginStatus.logout;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginStatus Status { get; set; }
    }
}
