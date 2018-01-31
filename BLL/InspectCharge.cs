using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InspectCharge
    {
        public bool SaveInspectCharge(CommContracts.InspectCharge InspectCharge)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.InspectCharge, DAL.InspectCharge>().ForMember(x => x.InspectChargeDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.InspectCharge temp = new DAL.InspectCharge();
                temp = mapper.Map<DAL.InspectCharge>(InspectCharge);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.InspectChargeDetail, DAL.InspectChargeDetail>().ForMember(x => x.InspectCharge, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.InspectChargeDetail> list1 = InspectCharge.InspectChargeDetails;
                List<DAL.InspectChargeDetail> res = mapperDetail.Map<List<DAL.InspectChargeDetail>>(list1); ;

                temp.InspectChargeDetails = res;
                ctx.InspectCharges.Add(temp);
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

        public List<CommContracts.InspectCharge> GetAllChargeFromInspectAdvice(int AdviceID)
        {
            List<CommContracts.InspectCharge> list = new List<CommContracts.InspectCharge>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.InspectCharges
                            where a.InspectDoctorAdviceID == AdviceID
                            select a;
                foreach (DAL.InspectCharge ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.InspectCharge, CommContracts.InspectCharge>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.InspectCharge temp = mapper.Map<CommContracts.InspectCharge>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.InspectCharge> GetAllClinicInspectCharge(int RegistrationID)
        {
            List<CommContracts.InspectCharge> list = new List<CommContracts.InspectCharge>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from m in context.InspectCharges
                            where m.InspectDoctorAdvice.RegistrationID == RegistrationID
                            select m;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.InspectCharge, CommContracts.InspectCharge>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    var charge = mapper.Map<CommContracts.InspectCharge>(tem);

                    list.Add(charge);
                }

            }
            return list;
        }

        public List<CommContracts.InspectCharge> GetAllInHospitalInspectCharge(int InpatientID)
        {
            List<CommContracts.InspectCharge> list = new List<CommContracts.InspectCharge>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from m in context.InspectCharges
                            where m.InspectDoctorAdvice.InpatientID == InpatientID
                            select m;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.InspectCharge, CommContracts.InspectCharge>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    var charge = mapper.Map<CommContracts.InspectCharge>(tem);

                    list.Add(charge);
                }

            }
            return list;
        }
    }
}
