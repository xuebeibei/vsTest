using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClinicRegistration
    {
        public List<CommContracts.ClinicRegistration> GetAllClinicRegistration(string strName)
        {
            List<CommContracts.ClinicRegistration> list = new List<CommContracts.ClinicRegistration>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.ClinicRegistrations
                            where t.Patient.Name.StartsWith(strName) 
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.ClinicRegistration, CommContracts.ClinicRegistration>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.ClinicRegistration tem in query)
                {
                    var dto = mapper.Map<CommContracts.ClinicRegistration>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveClinicRegistration(CommContracts.ClinicRegistration ClinicRegistration)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.ClinicRegistration, DAL.ClinicRegistration>().ForMember(x => x.Patient, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.ClinicRegistration temp = new DAL.ClinicRegistration();
                temp = mapper.Map<DAL.ClinicRegistration>(ClinicRegistration);

                ctx.ClinicRegistrations.Add(temp);
                try
                {
                    ctx.SaveChanges();
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    return false;
                }
            }
            return true;
        }

        public bool DeleteClinicRegistration(int ClinicRegistrationID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.ClinicRegistrations.FirstOrDefault(m => m.ID == ClinicRegistrationID);
                if (temp != null)
                {
                    ctx.ClinicRegistrations.Remove(temp);
                }

                try
                {
                    ctx.SaveChanges();
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    return false;
                }
            }
            return true;
        }

        public bool UpdateClinicRegistration(CommContracts.ClinicRegistration ClinicRegistration)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.ClinicRegistrations.FirstOrDefault(m => m.ID == ClinicRegistration.ID);
                if (temp != null)
                {
                    temp.VistDoctorDate = ClinicRegistration.VistDoctorDate;
                    temp.RegistrationTime = ClinicRegistration.RegistrationTime;
                    temp.DoctorClinicWorkPlanID = ClinicRegistration.DoctorClinicWorkPlanID;
                    temp.PatientID = ClinicRegistration.PatientID;
                }
                else
                {
                    return false;
                }

                try
                {
                    ctx.SaveChanges();
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    return false;
                }
            }
            return true;
        }
    }
}
