using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InjectionBill
    {
        public bool SaveInjectionBill(CommContracts.InjectionBill InjectionBill)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.InjectionBill, DAL.InjectionBill>().ForMember(x => x.MedicineDoctorAdvice, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.InjectionBill temp = new DAL.InjectionBill();
                temp = mapper.Map<DAL.InjectionBill>(InjectionBill);

                ctx.InjectionBills.Add(temp);
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


        public List<CommContracts.InjectionBill> GetAllInjectionBill(int nRegistrationID)
        {
            List<CommContracts.InjectionBill> list = new List<CommContracts.InjectionBill>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from m in context.InjectionBills
                            where m.MedicineDoctorAdvice.RegistrationID == nRegistrationID
                            select m;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.InjectionBill, CommContracts.InjectionBill>().ForMember(x=>x.MedicineDoctorAdvice, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();


                var config1 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.MedicineDoctorAdvice, CommContracts.MedicineDoctorAdvice>();
                });
                var mapper1 = config1.CreateMapper();


                foreach (var tem in query)
                {
                    var advice = mapper1.Map<CommContracts.MedicineDoctorAdvice>(tem.MedicineDoctorAdvice);
                    var injection = mapper.Map<CommContracts.InjectionBill>(tem);
                    injection.MedicineDoctorAdvice = advice;

                    list.Add(injection);
                }

            }
            return list;
        }

        public List<CommContracts.InjectionBill> GetAllInHospitalInjectionBill(int InHospitalID)
        {
            List<CommContracts.InjectionBill> list = new List<CommContracts.InjectionBill>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from m in context.InjectionBills
                            where m.MedicineDoctorAdvice.InpatientID == InHospitalID
                            select m;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.InjectionBill, CommContracts.InjectionBill>().ForMember(x => x.MedicineDoctorAdvice, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();


                var config1 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.MedicineDoctorAdvice, CommContracts.MedicineDoctorAdvice>();
                });
                var mapper1 = config1.CreateMapper();


                foreach (var tem in query)
                {
                    var advice = mapper1.Map<CommContracts.MedicineDoctorAdvice>(tem.MedicineDoctorAdvice);
                    var injection = mapper.Map<CommContracts.InjectionBill>(tem);
                    injection.MedicineDoctorAdvice = advice;

                    list.Add(injection);
                }

            }
            return list;
        }
    }
}
