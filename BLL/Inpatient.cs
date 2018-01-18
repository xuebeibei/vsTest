using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Inpatient
    {
        public Dictionary<int, string> GetAllInPatient()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from r in ctx.Inpatients
                            select r;

                foreach (DAL.Inpatient tem in query)
                {
                    string str = tem.ToString();
                    dictionary.Add(tem.ID, str);
                }
            }

            return dictionary;
        }

        public List<CommContracts.Inpatient> GetAllInPatient(CommContracts.InHospitalStatusEnum inHospitalStatusEnum, string strName = "")
        {
            List<CommContracts.Inpatient> list = new List<CommContracts.Inpatient>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.Inpatients
                            where a.InHospitalStatusEnum == (DAL.InHospitalStatusEnum)inHospitalStatusEnum && 
                            a.Patient.Name.StartsWith(strName) 
                            select a;
                foreach (DAL.Inpatient ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Inpatient, CommContracts.Inpatient>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Inpatient temp = mapper.Map<CommContracts.Inpatient>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public Dictionary<int, string> GetAllInHospitalChargePatient(DateTime startDate, DateTime endDate, string strFindName = "", bool HavePay = false)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from r in ctx.Inpatients
                            select r;

                foreach (DAL.Inpatient tem in query)
                {
                    string str = tem.ToString();
                    dictionary.Add(tem.ID, str);
                }
            }

            return dictionary;
        }

        public string getInPatientBMIMsg(int InpatientID)
        {
            string strMsg = "";
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from i in ctx.Inpatients
                            where i.ID == InpatientID
                            select i;
                foreach(var tem in query)
                {
                    if (tem == null)
                        continue;

                    int PatientID = tem.PatientID;
                    var patient = ctx.Patients.Find(PatientID);
                    strMsg = patient.ToBMIMsg();

                    break;
                }
            }

            return strMsg;
        }

        public bool SaveInPatient(CommContracts.Inpatient inpatient)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Inpatient, DAL.Inpatient>();
                });
                var mapper = config.CreateMapper();

                DAL.Inpatient temp = new DAL.Inpatient();
                temp = mapper.Map<DAL.Inpatient>(inpatient);

                ctx.Inpatients.Add(temp);
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
    }
}
