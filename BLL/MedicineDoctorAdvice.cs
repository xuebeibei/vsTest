using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedicineDoctorAdvice : DoctorAdviceBase
    {
        public void ReadMedicineDoctorAdvice()
        {
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var recipe = context.MedicineDoctorAdvices.Find(3);
            }
        }

        public bool SaveMedicineDoctorAdvice(CommContracts.MedicineDoctorAdvice recipe)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.MedicineDoctorAdvice, DAL.MedicineDoctorAdvice>().ForMember(x => x.MedicineDoctorAdviceDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.MedicineDoctorAdvice temp = new DAL.MedicineDoctorAdvice();
                temp = mapper.Map<DAL.MedicineDoctorAdvice>(recipe);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.MedicineDoctorAdviceDetail, DAL.MedicineDoctorAdviceDetail>().ForMember(x => x.MedicineDoctorAdvice, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.MedicineDoctorAdviceDetail> details = recipe.MedicineDoctorAdviceDetails;
                List<DAL.MedicineDoctorAdviceDetail> res = mapperDetail.Map<List<DAL.MedicineDoctorAdviceDetail>>(details); ;

                temp.MedicineDoctorAdviceDetails = res;
                ctx.MedicineDoctorAdvices.Add(temp);
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

        public List<CommContracts.MedicineDoctorAdvice> getAllXiCheng(int RegistrationID)
        {
            return getAllMedicineDoctorAdvices(RegistrationID, 0, DAL.DoctorAdviceContentEnum.西药和中成药处方);
        }

        public List<CommContracts.MedicineDoctorAdvice> getAllZhong(int RegistrationID)
        {
            return getAllMedicineDoctorAdvices(RegistrationID, 0, DAL.DoctorAdviceContentEnum.中药处方);
        }

        private List<CommContracts.MedicineDoctorAdvice> getAllMedicineDoctorAdvices(int RegistrationID, int InpatientID, DAL.DoctorAdviceContentEnum recipeContentEnum)
        {
            List<CommContracts.MedicineDoctorAdvice> list = new List<CommContracts.MedicineDoctorAdvice>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from r in context.MedicineDoctorAdvices
                            where r.RegistrationID == RegistrationID &&
                            r.InpatientID == InpatientID &&
                            r.RecipeContentEnum == recipeContentEnum
                            select r;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.MedicineDoctorAdvice, CommContracts.MedicineDoctorAdvice>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    var recipe = mapper.Map<CommContracts.MedicineDoctorAdvice>(tem);

                    list.Add(recipe);
                }

            }
            return list;
        }


        public List<CommContracts.MedicineDoctorAdvice> getAllInHospitalXiCheng(int InpatientID)
        {
            return getAllMedicineDoctorAdvices(0, InpatientID, DAL.DoctorAdviceContentEnum.西药和中成药处方);
        }

        public List<CommContracts.MedicineDoctorAdvice> getAllInHospitalZhong(int InpatientID)
        {
            return getAllMedicineDoctorAdvices(0, InpatientID, DAL.DoctorAdviceContentEnum.中药处方);
        }
    }
}
