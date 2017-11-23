using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BLL
{
    public class Registration
    {
        CommContracts.Registration registration;

        public Registration(CommContracts.Registration registration)
        {
            this.registration = registration;
        }

        public bool SaveRegistration()
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                //DAL.Registration aa = new DAL.Registration();
                //aa.Patient = registration.GetPatient;
                //aa.SignalSourceID = 22;
                //aa.DateTime = DateTime.Now;
                //aa.UserID = 1;
                //aa.Fee = 9.0;

                //ctx.Registrations.Add(aa);
                //try
                //{
                //    ctx.SaveChanges();
                //}
                //catch(Exception ex)
                //{


                //}
                
                

                return true;
            }
        }

    }
}
