using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommContracts;
using System.ServiceModel;

namespace CommClient
{
    public class User
    {
        private ILoginService client;

        public User()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public CommContracts.User Authenticate(string username, string password)
        {
            CommContracts.User login = new CommContracts.User();
            login.Username = username;
            login.Password = password;
            return client.UserAuthenticate(login);
        }

        public bool Logout(CommContracts.User user)
        {
            return client.UserLogout(user);
        }

        public List<CommContracts.User> GetAllLoginUser(string strName = "")
        {
            return client.GetAllLoginUser(strName);
        }

        public bool UpdateLoginUser(CommContracts.User job)
        {
            return client.UpdateLoginUser(job);
        }

        public bool SaveLoginUser(CommContracts.User job)
        {
            return client.SaveLoginUser(job);
        }

        public bool DeleteLoginUser(int jobID)
        {
            return client.DeleteLoginUser(jobID);
        }

        public CommContracts.User getUser(int UserID)
        {
            return client.getUser(UserID);
        }
    }
}
