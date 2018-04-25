using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WorkType
    {
        public List<CommContracts.WorkType> GetAllWorkType(string strName)
        {
            List<CommContracts.WorkType> list = new List<CommContracts.WorkType>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.WorkTypes
                            where t.Name.StartsWith(strName) 
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.WorkType, CommContracts.WorkType>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.WorkType tem in query)
                {
                    var dto = mapper.Map<CommContracts.WorkType>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveWorkType(CommContracts.WorkType WorkType)
        {
            WorkType.ModifiedDate = DateTime.Now;
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.WorkType, DAL.WorkType>();
                });
                var mapper = config.CreateMapper();

                DAL.WorkType temp = new DAL.WorkType();
                temp = mapper.Map<DAL.WorkType>(WorkType);

                ctx.WorkTypes.Add(temp);
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

        public bool DeleteWorkType(int WorkTypeID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.WorkTypes.FirstOrDefault(m => m.ID == WorkTypeID);
                if (temp != null)
                {
                    ctx.WorkTypes.Remove(temp);
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

        public bool UpdateWorkType(CommContracts.WorkType WorkType)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.WorkTypes.FirstOrDefault(m => m.ID == WorkType.ID);
                if (temp != null)
                {
                    temp.Name = WorkType.Name;
                    temp.ModifiedDate = DateTime.Now;
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
