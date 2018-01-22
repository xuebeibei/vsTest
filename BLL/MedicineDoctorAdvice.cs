﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedicineDoctorAdvice
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

                List<CommContracts.MedicineDoctorAdviceDetail> list1 = recipe.MedicineDoctorAdviceDetails;
                List<DAL.MedicineDoctorAdviceDetail> res = mapperDetail.Map<List<DAL.MedicineDoctorAdviceDetail>>(list1); ;

                temp.MedicineDoctorAdviceDetails = res;
                ctx.MedicineDoctorAdvices.Add(temp);
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

        public List<CommContracts.MedicineDoctorAdvice> getAllXiCheng(int RegistrationID)
        {
            return getAllMedicineDoctorAdvices(RegistrationID, 0, DAL.DoctorAdviceContentEnum.XiChengYao);
        }

        public List<CommContracts.MedicineDoctorAdvice> getAllZhong(int RegistrationID)
        {
            return getAllMedicineDoctorAdvices(RegistrationID, 0, DAL.DoctorAdviceContentEnum.ZhongYao);
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
            return getAllMedicineDoctorAdvices(0, InpatientID, DAL.DoctorAdviceContentEnum.XiChengYao);
        }

        public List<CommContracts.MedicineDoctorAdvice> getAllInHospitalZhong(int InpatientID)
        {
            return getAllMedicineDoctorAdvices(0, InpatientID, DAL.DoctorAdviceContentEnum.ZhongYao);
        }

        public bool UpdateChargeStatus(int MedicineDoctorAdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var tem = context.MedicineDoctorAdvices.Find(MedicineDoctorAdviceID);
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