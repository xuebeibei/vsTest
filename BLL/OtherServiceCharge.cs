using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OtherServiceCharge
    {
        public bool SaveOtherServiceCharge(CommContracts.OtherServiceCharge OtherServiceCharge)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.OtherServiceCharge, DAL.OtherServiceCharge>().ForMember(x => x.OtherServiceChargeDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.OtherServiceCharge temp = new DAL.OtherServiceCharge();
                temp = mapper.Map<DAL.OtherServiceCharge>(OtherServiceCharge);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.OtherServiceChargeDetail, DAL.OtherServiceChargeDetail>().ForMember(x => x.OtherServiceCharge, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.OtherServiceChargeDetail> list1 = OtherServiceCharge.OtherServiceChargeDetails;
                List<DAL.OtherServiceChargeDetail> res = mapperDetail.Map<List<DAL.OtherServiceChargeDetail>>(list1); ;

                temp.OtherServiceChargeDetails = res;
                ctx.OtherServiceCharges.Add(temp);
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

        public List<CommContracts.OtherServiceCharge> GetAllChargeFromOtherServiceAdvice(int AdviceID)
        {
            List<CommContracts.OtherServiceCharge> list = new List<CommContracts.OtherServiceCharge>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.OtherServiceCharges
                            where a.OtherServiceDoctorAdviceID == AdviceID
                            select a;
                foreach (DAL.OtherServiceCharge ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.OtherServiceCharge, CommContracts.OtherServiceCharge>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.OtherServiceCharge temp = mapper.Map<CommContracts.OtherServiceCharge>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.OtherServiceCharge> GetAllClinicOtherServiceCharge(int RegistrationID)
        {
            List<CommContracts.OtherServiceCharge> list = new List<CommContracts.OtherServiceCharge>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from m in context.OtherServiceCharges
                            where m.OtherServiceDoctorAdvice.RegistrationID == RegistrationID
                            select m;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.OtherServiceCharge, CommContracts.OtherServiceCharge>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    var charge = mapper.Map<CommContracts.OtherServiceCharge>(tem);

                    list.Add(charge);
                }

            }
            return list;
        }

        public List<CommContracts.OtherServiceCharge> GetAllInHospitalOtherServiceCharge(int InpatientID)
        {
            List<CommContracts.OtherServiceCharge> list = new List<CommContracts.OtherServiceCharge>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from m in context.OtherServiceCharges
                            where m.OtherServiceDoctorAdvice.InpatientID == InpatientID
                            select m;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.OtherServiceCharge, CommContracts.OtherServiceCharge>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    var charge = mapper.Map<CommContracts.OtherServiceCharge>(tem);

                    list.Add(charge);
                }

            }
            return list;
        }
    }
}
