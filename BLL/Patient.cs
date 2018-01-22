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

                var prePayBalance = ctx.PrePays.Where(s => (s.PatientID == PatientID)).Select(o => o.PrePayMoney).Sum();
                balance = prePayBalance;


                return balance;

            }
        }
    }
}
