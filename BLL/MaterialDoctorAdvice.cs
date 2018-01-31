using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MaterialDoctorAdvice
    {
        public CommContracts.MaterialDoctorAdvice GetMaterialDoctorAdvice(int Id)
        {
            CommContracts.MaterialDoctorAdvice materialDoctorAdvice = new CommContracts.MaterialDoctorAdvice();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.MaterialDoctorAdvices
                            where t.ID == Id
                            select t;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.MaterialDoctorAdvice, CommContracts.MaterialDoctorAdvice>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    materialDoctorAdvice = mapper.Map<CommContracts.MaterialDoctorAdvice>(tem);
                    break;
                }
            }
            return materialDoctorAdvice;
        }

        public bool SaveMaterialDoctorAdvice(CommContracts.MaterialDoctorAdvice materialDoctorAdvice)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.MaterialDoctorAdvice, DAL.MaterialDoctorAdvice>().ForMember(x => x.MaterialDoctorAdviceDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.MaterialDoctorAdvice temp = new DAL.MaterialDoctorAdvice();
                temp = mapper.Map<DAL.MaterialDoctorAdvice>(materialDoctorAdvice);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.MaterialDoctorAdviceDetail, DAL.MaterialDoctorAdviceDetail>().ForMember(x => x.MaterialDoctorAdvice, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.MaterialDoctorAdviceDetail> list1 = materialDoctorAdvice.MaterialDoctorAdviceDetails;
                List<DAL.MaterialDoctorAdviceDetail> res = mapperDetail.Map<List<DAL.MaterialDoctorAdviceDetail>>(list1); ;

                temp.MaterialDoctorAdviceDetails = res;
                ctx.MaterialDoctorAdvices.Add(temp);
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

        public List<CommContracts.MaterialDoctorAdvice> getAllMaterialDoctorAdvice(int RegistrationID)
        {
            List<CommContracts.MaterialDoctorAdvice> list = new List<CommContracts.MaterialDoctorAdvice>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.MaterialDoctorAdvices
                            where a.RegistrationID == RegistrationID
                            select a;
                foreach (DAL.MaterialDoctorAdvice ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.MaterialDoctorAdvice, CommContracts.MaterialDoctorAdvice>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.MaterialDoctorAdvice temp = mapper.Map<CommContracts.MaterialDoctorAdvice>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.MaterialDoctorAdvice> getAllInHospitalMaterialDoctorAdvice(int InpatientID)
        {
            List<CommContracts.MaterialDoctorAdvice> list = new List<CommContracts.MaterialDoctorAdvice>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.MaterialDoctorAdvices
                            where a.InpatientID == InpatientID
                            select a;
                foreach (DAL.MaterialDoctorAdvice ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.MaterialDoctorAdvice, CommContracts.MaterialDoctorAdvice>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.MaterialDoctorAdvice temp = mapper.Map<CommContracts.MaterialDoctorAdvice>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool UpdateMaterialChargeStatus(int MaterialDoctorAdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var tem = context.MaterialDoctorAdvices.Find(MaterialDoctorAdviceID);
                if (tem == null)
                    return false;

                tem.ChargeStatusEnum = (DAL.ChargeStatusEnum)chargeStatusEnum;
                try
                {
                    context.SaveChanges();
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
