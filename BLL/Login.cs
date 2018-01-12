using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.Entity;

namespace BLL
{
    public class Login
    {
        CommContracts.LoginUser user;
        
        

        public Login(CommContracts.LoginUser user)
        {
            this.user = user;
        }

        public Login(string username, string password)
        {
            user = new CommContracts.LoginUser();
            user.Username = username;
            user.Password = password;
        }

        public bool Authenticate()
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                Trace.WriteLine("Querying database..." +
                    "usename: " + user.Username + ", password: " + user.Password);
                //return ctx.Users.Any(
                //    u => u.Username == user.Username && 
                //         u.Password == user.Password && 
                //         u.Status != DAL.User.LoginStatus.invalid);

                //var queryResult = from u in ctx.Users
                //                  where u.Username == user.Username &&
                //                        u.Password == user.Password &&
                //                        u.Status != DAL.User.LoginStatus.invalid
                //                  select u;

                var queryResult = from u in ctx.Users
                                  where u.Username == user.Username &&
                                        u.Password == user.Password 
                                  select u;

                Trace.WriteLine("Query database finished, record number: "
                    + queryResult.Count());

                if (queryResult.Count() == 1)
                {
                    var u = queryResult.First();
                    u.LastLogin = DateTime.Now;
                    u.Status = DAL.User.LoginStatus.login;
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Logout()
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var queryResult = from u in ctx.Users
                                  where u.Username == user.Username &&
                                        u.Password == user.Password &&
                                        u.Status == DAL.User.LoginStatus.login
                                  select u;
                if (queryResult.Count() == 1)
                {
                    var u = queryResult.First();
                    u.Status = DAL.User.LoginStatus.logout;
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
