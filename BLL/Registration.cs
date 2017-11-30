using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoMapper;

namespace BLL
{
    public class Registration
    {
        CommContracts.Registration registration;

        public Registration(CommContracts.Registration registration)
        {
            this.registration = registration;
        }

        public Registration()
        {

        }

        public Dictionary<int ,string> getAllRegistration()
        {
            Dictionary<int, string> list = new Dictionary<int, string>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = ctx.Registrations.Include("Patient").Include("SignalSource").Include("User").ToList();

                foreach (DAL.Registration tem in query)
                {
                    string str = tem.ToString(); 
                    list.Add(tem.ID, str);
                }
            }

            return list;
        }

        public bool SaveRegistration()
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var aa = ctx.Registrations.FirstOrDefault();
                if (aa == null)
                {
                    aa = new DAL.Registration();
                }
                var dd = ctx.Departments.FirstOrDefault();

                var ss = ctx.SignalSources.FirstOrDefault();

                var pp = ctx.Patients.FirstOrDefault();

                var uu = ctx.Users.FirstOrDefault();
                if (uu == null)
                {
                    uu = new DAL.User();
                    uu.Username = "uu";
                    uu.Password = "uu";
                    uu.Status = DAL.User.LoginStatus.login;
                    uu.LastLogin = DateTime.Now;
                    ctx.Users.Add(uu);
                    ctx.SaveChanges();
                }

                aa.SignalSource = ss;
                aa.Patient = pp;

                aa.Fee = 20;
                aa.User = uu;
                aa.DateTime = DateTime.Now;
                ctx.Registrations.Add(aa);
                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                }

                return true;
            }
        }

    }
}
