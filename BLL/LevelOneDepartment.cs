using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LevelOneDepartment
    {
        public List<CommContracts.LevelOneDepartment> GetAllLevelOneDepartment(string strName)
        {
            List<CommContracts.LevelOneDepartment> list = new List<CommContracts.LevelOneDepartment>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.LevelOneDepartments
                            where t.Name.StartsWith(strName) ||
                            t.Name.StartsWith(strName) ||
                            t.Abbr.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.LevelOneDepartment, CommContracts.LevelOneDepartment>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.LevelOneDepartment tem in query)
                {
                    var dto = mapper.Map<CommContracts.LevelOneDepartment>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveLevelOneDepartment(CommContracts.LevelOneDepartment LevelOneDepartment)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.LevelOneDepartment, DAL.LevelOneDepartment>();
                });
                var mapper = config.CreateMapper();

                DAL.LevelOneDepartment temp = new DAL.LevelOneDepartment();
                temp = mapper.Map<DAL.LevelOneDepartment>(LevelOneDepartment);

                ctx.LevelOneDepartments.Add(temp);
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

        public bool DeleteLevelOneDepartment(int LevelOneDepartmentID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.LevelOneDepartments.FirstOrDefault(m => m.ID == LevelOneDepartmentID);
                if (temp != null)
                {
                    ctx.LevelOneDepartments.Remove(temp);
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

        public bool UpdateLevelOneDepartment(CommContracts.LevelOneDepartment LevelOneDepartment)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.LevelOneDepartments.FirstOrDefault(m => m.ID == LevelOneDepartment.ID);
                if (temp != null)
                {
                    temp.Name = LevelOneDepartment.Name;
                    temp.Abbr = LevelOneDepartment.Abbr;
                    temp.UpdateTime = LevelOneDepartment.UpdateTime;
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
