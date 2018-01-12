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
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from r in ctx.Registrations
                            select r;

                foreach (DAL.Registration tem in query)
                {
                    string str = tem.ToString();
                    dictionary.Add(tem.ID, str);
                }
            }

            return dictionary;
        }

        public Dictionary<int, string> GetAllClinicPatients(DateTime startDate, DateTime endDate, string strFindName = "", bool HavePay = false)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from r in ctx.Registrations
                            select r;

                foreach (DAL.Registration tem in query)
                {
                    string str = tem.ToString();
                    dictionary.Add(tem.ID, str);
                }
            }

            return dictionary;
        }

        public string getPatientBMIMsg(int RegistrationID)
        {
            string strBMIMsg = "";
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = ctx.Registrations.Find(RegistrationID); 
                var temp = query as DAL.Registration;
                if (temp == null)
                    return strBMIMsg;

                int PatientID = temp.PatientID;
                var patient = ctx.Patients.Find(PatientID);
                strBMIMsg = patient.ToBMIMsg();
            }

            return strBMIMsg;
        }

        public bool SaveRegistration()
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Registration, DAL.Registration>();
                });
                var mapper = config.CreateMapper();

                DAL.Registration temp = new DAL.Registration();
                temp = mapper.Map<DAL.Registration>(registration);

                ctx.Registrations.Add(temp);
                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                }
            }
            return true;
        }

    }
}
