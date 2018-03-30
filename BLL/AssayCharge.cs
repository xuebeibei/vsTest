using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AssayCharge
    {
        public bool SaveAssayCharge(CommContracts.AssayCharge AssayCharge)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.AssayCharge, DAL.AssayCharge>().ForMember(x => x.AssayChargeDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.AssayCharge temp = new DAL.AssayCharge();
                temp = mapper.Map<DAL.AssayCharge>(AssayCharge);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.AssayChargeDetail, DAL.AssayChargeDetail>().ForMember(x => x.AssayCharge, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.AssayChargeDetail> list1 = AssayCharge.AssayChargeDetails;
                List<DAL.AssayChargeDetail> res = mapperDetail.Map<List<DAL.AssayChargeDetail>>(list1); ;

                temp.AssayChargeDetails = res;
                ctx.AssayCharges.Add(temp);
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

        public List<CommContracts.AssayCharge> GetAllChargeFromAssayAdvice(int AdviceID)
        {
            List<CommContracts.AssayCharge> list = new List<CommContracts.AssayCharge>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.AssayCharges
                            where a.AssayDoctorAdviceID == AdviceID
                            select a;
                foreach (DAL.AssayCharge ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.AssayCharge, CommContracts.AssayCharge>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.AssayCharge temp = mapper.Map<CommContracts.AssayCharge>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.AssayCharge> GetAllClinicAssayCharge(int RegistrationID)
        {
            List<CommContracts.AssayCharge> list = new List<CommContracts.AssayCharge>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from m in context.AssayCharges
                            where m.AssayDoctorAdvice.RegistrationID == RegistrationID
                            select m;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.AssayCharge, CommContracts.AssayCharge>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    var charge = mapper.Map<CommContracts.AssayCharge>(tem);

                    list.Add(charge);
                }

            }
            return list;
        }

        public List<CommContracts.AssayCharge> GetAllInHospitalAssayCharge(int InpatientID)
        {
            List<CommContracts.AssayCharge> list = new List<CommContracts.AssayCharge>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from m in context.AssayCharges
                            where m.AssayDoctorAdvice.InpatientID == InpatientID
                            select m;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.AssayCharge, CommContracts.AssayCharge>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    var charge = mapper.Map<CommContracts.AssayCharge>(tem);

                    list.Add(charge);
                }

            }
            return list;
        }
    }
}
