using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommContracts;
using System.ServiceModel;

namespace CommClient
{
    public class Login
    {
        private ILoginService client;
        private string username;
        private string password;

        public Login(string username, string password)
        {
            this.username = username;
            this.password = password;
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public bool Authenticate()
        {
            LoginUser login = new LoginUser();
            login.Username = username;
            login.Password = password;
            return client.UserAuthenticate(login);
        }

        public bool Logout()
        {
            LoginUser login = new LoginUser();
            login.Username = username;
            login.Password = password;
            return client.UserLogout(login);
        }
    }
}
