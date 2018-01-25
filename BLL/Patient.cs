using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Patient
    {
        public CommContracts.Patient ReadCurrentPatient(int PatientID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                CommContracts.Patient patient = new CommContracts.Patient();
                var temp = ctx.Patients.Find(PatientID);
                if (temp == null)
                    return patient;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Patient, CommContracts.Patient>();
                });
                var mapper = config.CreateMapper();

                patient = mapper.Map<CommContracts.Patient>(temp);

                return patient;

            }
        }

        public decimal GetCurrentPatientBalance(int PatientID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                decimal balance = 0.0m;
                var temp = ctx.PrePays.Where(x => x.PatientID == PatientID).Count();
                if (temp > 0)
                {
                    var prePayBalance = ctx.PrePays.Where(s => (s.PatientID == PatientID)).Select(o => o.PrePayMoney).Sum();
                    balance += prePayBalance;
                }

                var temp1 = ctx.MedicineDoctorAdvices.Where(x => x.PatientID == PatientID).Count();
                if(temp1 > 0)
                {
                    var recipeCharge = ctx.RecipeChargeBills.Where(s => (s.MedicineDoctorAdvice != null && s.MedicineDoctorAdvice.PatientID == PatientID)).Select(o => o.SumOfMoney).Sum();
                    balance -= recipeCharge;
                }
                

                return balance;

            }
        }

        public List<CommContracts.Patient> GetAllPatient(string strName)
        {
            List<CommContracts.Patient> list = new List<CommContracts.Patient>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.Patients
                            where t.Name.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Patient, CommContracts.Patient>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.Patient tem in query)
                {
                    var dto = mapper.Map<CommContracts.Patient>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SavePatient(CommContracts.Patient Patient)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Patient, DAL.Patient>();
                });
                var mapper = config.CreateMapper();

                DAL.Patient temp = new DAL.Patient();
                temp = mapper.Map<DAL.Patient>(Patient);

                ctx.Patients.Add(temp);
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

        public bool DeletePatient(int PatientID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Patients.FirstOrDefault(m => m.ID == PatientID);
                if (temp != null)
                {
                    ctx.Patients.Remove(temp);
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

        public bool UpdatePatient(CommContracts.Patient Patient)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Patients.FirstOrDefault(m => m.ID == Patient.ID);
                if (temp != null)
                {
                    temp.Name = Patient.Name;
                    temp.Gender = (DAL.GenderEnum)Patient.Gender;
                    temp.BirthDay = Patient.BirthDay;
                    temp.IDCardNo = Patient.IDCardNo;
                    temp.Volk = (DAL.VolkEnum)Patient.Volk;
                    temp.Tel = Patient.Tel;
                    temp.JiGuan = Patient.JiGuan;
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
    }
}
