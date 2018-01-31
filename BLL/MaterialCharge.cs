using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MaterialCharge
    {
        public bool SaveMaterialCharge(CommContracts.MaterialCharge assay)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.MaterialCharge, DAL.MaterialCharge>().ForMember(x => x.MaterialChargeDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.MaterialCharge temp = new DAL.MaterialCharge();
                temp = mapper.Map<DAL.MaterialCharge>(assay);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.MaterialChargeDetail, DAL.MaterialChargeDetail>().ForMember(x => x.MaterialCharge, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.MaterialChargeDetail> list1 = assay.MaterialChargeDetails;
                List<DAL.MaterialChargeDetail> res = mapperDetail.Map<List<DAL.MaterialChargeDetail>>(list1); ;

                temp.MaterialChargeDetails = res;
                ctx.MaterialCharges.Add(temp);
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

        public List<CommContracts.MaterialCharge> GetAllChargeFromMaterialAdvice(int AdviceID)
        {
            List<CommContracts.MaterialCharge> list = new List<CommContracts.MaterialCharge>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.MaterialCharges
                            where a.MaterialDoctorAdviceID == AdviceID
                            select a;
                foreach (DAL.MaterialCharge ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.MaterialCharge, CommContracts.MaterialCharge>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.MaterialCharge temp = mapper.Map<CommContracts.MaterialCharge>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.MaterialCharge> GetAllClinicMaterialCharge(int RegistrationID)
        {
            List<CommContracts.MaterialCharge> list = new List<CommContracts.MaterialCharge>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from m in context.MaterialCharges
                            where m.MaterialDoctorAdvice.RegistrationID == RegistrationID
                            select m;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.MaterialCharge, CommContracts.MaterialCharge>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    var charge = mapper.Map<CommContracts.MaterialCharge>(tem);

                    list.Add(charge);
                }

            }
            return list;
        }

        public List<CommContracts.MaterialCharge> GetAllInHospitalMaterialCharge(int InpatientID)
        {
            List<CommContracts.MaterialCharge> list = new List<CommContracts.MaterialCharge>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from m in context.MaterialCharges
                            where m.MaterialDoctorAdvice.InpatientID == InpatientID
                            select m;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.MaterialCharge, CommContracts.MaterialCharge>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    var charge = mapper.Map<CommContracts.MaterialCharge>(tem);

                    list.Add(charge);
                }

            }
            return list;
        }
    }
}
