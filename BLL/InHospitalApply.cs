using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InHospitalApply
    {
        public List<CommContracts.InHospitalApply> GetAllInHospitalApply(CommContracts.InHospitalApplyEnum inHospitalApplyEnum,string strName ="")
        {
            List<CommContracts.InHospitalApply> list = new List<CommContracts.InHospitalApply>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.InHospitalApplys
                            where t.Patient.Name.StartsWith(strName) && 
                            t.InHospitalApplyEnum == (DAL.InHospitalApplyEnum)inHospitalApplyEnum
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.InHospitalApply, CommContracts.InHospitalApply>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.InHospitalApply tem in query)
                {
                    var dto = mapper.Map<CommContracts.InHospitalApply>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveInHospitalApply(CommContracts.InHospitalApply InHospitalApply)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.InHospitalApply, DAL.InHospitalApply>();
                });
                var mapper = config.CreateMapper();

                DAL.InHospitalApply temp = new DAL.InHospitalApply();
                temp = mapper.Map<DAL.InHospitalApply>(InHospitalApply);

                ctx.InHospitalApplys.Add(temp);
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

        public bool DeleteInHospitalApply(int InHospitalApplyID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.InHospitalApplys.FirstOrDefault(m => m.ID == InHospitalApplyID);
                if (temp != null)
                {
                    ctx.InHospitalApplys.Remove(temp);
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

        public bool UpdateInHospitalApply(CommContracts.InHospitalApply InHospitalApply)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.InHospitalApplys.FirstOrDefault(m => m.ID == InHospitalApply.ID);
                if (temp != null)
                {
                    temp.ApplyTime = InHospitalApply.ApplyTime;
                    temp.PatientID = InHospitalApply.PatientID;
                    temp.UserID = InHospitalApply.UserID;
                    temp.InHospitalApplyEnum = (DAL.InHospitalApplyEnum)InHospitalApply.InHospitalApplyEnum;
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
