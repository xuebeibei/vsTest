﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.Entity;
using AutoMapper;

namespace BLL
{
    public class Login
    {
        CommContracts.User user;
        
        public Login()
        {

        }

        public Login(CommContracts.User user)
        {
            this.user = user;
        }

        public Login(string username, string password)
        {
            user = new CommContracts.User();
            user.Username = username;
            user.Password = password;
        }

        public bool Authenticate()
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                Trace.WriteLine("Querying database..." +
                    "usename: " + user.Username + ", password: " + user.Password);

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

        public List<CommContracts.User> GetAllLoginUser(string strName = "")
        {
            List<CommContracts.User> list = new List<CommContracts.User>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.Users
                            where a.Username.StartsWith(strName)
                            select a;
                foreach (DAL.User ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.User, CommContracts.User>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.User temp = mapper.Map<CommContracts.User>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveLoginUser(CommContracts.User loginUser)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.User, DAL.User>();
                });
                var mapper = config.CreateMapper();

                DAL.User temp = new DAL.User();
                temp = mapper.Map<DAL.User>(loginUser);

                ctx.Users.Add(temp);
                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        public bool DeleteLoginUser(int loginUserID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Users.FirstOrDefault(m => m.ID == loginUserID);
                if (temp != null)
                {
                    ctx.Users.Remove(temp);
                }

                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        public bool UpdateLoginUser(CommContracts.User loginUser)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Users.FirstOrDefault(m => m.ID == loginUser.ID);
                if (temp != null)
                {
                    temp.Username = loginUser.Username;
                    temp.Password = loginUser.Password;
                    temp.Status = (DAL.User.LoginStatus)loginUser.Status;
                    temp.LastLogin = loginUser.LastLogin;
                    temp.EmployeeID = loginUser.EmployeeID;
                }
                else
                {
                    return false;
                }

                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        public CommContracts.User getUser(int UserID)
        {
            CommContracts.User user = new CommContracts.User();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Users.Find(UserID);

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.User, CommContracts.User>();
                });
                var mapper = config.CreateMapper();

                user = mapper.Map<CommContracts.User>(temp);
            }
            return user;
        }
    }
}
