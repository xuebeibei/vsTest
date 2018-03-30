using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TherapyCharge
    {
        public bool SaveTherapyCharge(CommContracts.TherapyCharge therapyCharge)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.TherapyCharge, DAL.TherapyCharge>().ForMember(x => x.TherapyChargeDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.TherapyCharge temp = new DAL.TherapyCharge();
                temp = mapper.Map<DAL.TherapyCharge>(therapyCharge);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.TherapyChargeDetail, DAL.TherapyChargeDetail>().ForMember(x => x.TherapyCharge, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.TherapyChargeDetail> list1 = therapyCharge.TherapyChargeDetails;
                List<DAL.TherapyChargeDetail> res = mapperDetail.Map<List<DAL.TherapyChargeDetail>>(list1); ;

                temp.TherapyChargeDetails = res;
                ctx.TherapyCharges.Add(temp);
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

        public List<CommContracts.TherapyCharge> GetAllChargeFromTherapyAdvice(int AdviceID)
        {
            List<CommContracts.TherapyCharge> list = new List<CommContracts.TherapyCharge>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.TherapyCharges
                            where a.TherapyDoctorAdviceID == AdviceID
                            select a;
                foreach (DAL.TherapyCharge ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.TherapyCharge, CommContracts.TherapyCharge>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.TherapyCharge temp = mapper.Map<CommContracts.TherapyCharge>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.TherapyCharge> GetAllClinicTherapyCharge(int RegistrationID)
        {
            List<CommContracts.TherapyCharge> list = new List<CommContracts.TherapyCharge>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from m in context.TherapyCharges
                            where m.TherapyDoctorAdvice.RegistrationID == RegistrationID
                            select m;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.TherapyCharge, CommContracts.TherapyCharge>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    var charge = mapper.Map<CommContracts.TherapyCharge>(tem);

                    list.Add(charge);
                }

            }
            return list;
        }

        public List<CommContracts.TherapyCharge> GetAllInHospitalTherapyCharge(int InpatientID)
        {
            List<CommContracts.TherapyCharge> list = new List<CommContracts.TherapyCharge>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from m in context.TherapyCharges
                            where m.TherapyDoctorAdvice.InpatientID == InpatientID
                            select m;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.TherapyCharge, CommContracts.TherapyCharge>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    var charge = mapper.Map<CommContracts.TherapyCharge>(tem);

                    list.Add(charge);
                }

            }
            return list;
        }
    }
}
