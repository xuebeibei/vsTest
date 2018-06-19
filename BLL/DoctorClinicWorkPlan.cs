using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DoctorClinicWorkPlan
    {
        public List<CommContracts.DoctorClinicWorkPlan> GetAllDoctorClinicWorkPlan(string strName)
        {
            List<CommContracts.DoctorClinicWorkPlan> list = new List<CommContracts.DoctorClinicWorkPlan>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.DoctorClinicWorkPlans
                            where t.Doctor.StartsWith(strName) ||
                            t.SourceType.StartsWith(strName) 
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.DoctorClinicWorkPlan, CommContracts.DoctorClinicWorkPlan>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.DoctorClinicWorkPlan tem in query)
                {
                    var dto = mapper.Map<CommContracts.DoctorClinicWorkPlan>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveDoctorClinicWorkPlan(CommContracts.DoctorClinicWorkPlan DoctorClinicWorkPlan)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.DoctorClinicWorkPlan, DAL.DoctorClinicWorkPlan>();
                });
                var mapper = config.CreateMapper();

                DAL.DoctorClinicWorkPlan temp = new DAL.DoctorClinicWorkPlan();
                temp = mapper.Map<DAL.DoctorClinicWorkPlan>(DoctorClinicWorkPlan);

                ctx.DoctorClinicWorkPlans.Add(temp);
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

        public bool DeleteDoctorClinicWorkPlan(int DoctorClinicWorkPlanID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.DoctorClinicWorkPlans.FirstOrDefault(m => m.ID == DoctorClinicWorkPlanID);
                if (temp != null)
                {
                    ctx.DoctorClinicWorkPlans.Remove(temp);
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

        public bool UpdateDoctorClinicWorkPlan(CommContracts.DoctorClinicWorkPlan DoctorClinicWorkPlan)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.DoctorClinicWorkPlans.FirstOrDefault(m => m.ID == DoctorClinicWorkPlan.ID);
                if (temp != null)
                {
                    temp.LevelTwoDepartmentID = DoctorClinicWorkPlan.LevelTwoDepartmentID;
                    temp.Doctor = DoctorClinicWorkPlan.Doctor;
                    temp.SourceType = DoctorClinicWorkPlan.SourceType;
                    temp.TimeBucket = DoctorClinicWorkPlan.TimeBucket;
                    temp.Fee = DoctorClinicWorkPlan.Fee;
                    temp.MaxNum = DoctorClinicWorkPlan.MaxNum;
                    temp.Zhou = DoctorClinicWorkPlan.Zhou;
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
