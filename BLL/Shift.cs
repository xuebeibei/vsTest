using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Shift
    {
        public List<CommContracts.Shift> GetAllShift(string strName)
        {
            List<CommContracts.Shift> list = new List<CommContracts.Shift>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.Shifts
                            where t.Name.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Shift, CommContracts.Shift>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.Shift tem in query)
                {
                    var dto = mapper.Map<CommContracts.Shift>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveShift(CommContracts.Shift Shift)
        {
            Shift.ModifiedDate = DateTime.Now;
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Shift, DAL.Shift>();
                });
                var mapper = config.CreateMapper();

                DAL.Shift temp = new DAL.Shift();
                temp = mapper.Map<DAL.Shift>(Shift);

                ctx.Shifts.Add(temp);
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

        public bool DeleteShift(int ShiftID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Shifts.FirstOrDefault(m => m.ID == ShiftID);
                if (temp != null)
                {
                    ctx.Shifts.Remove(temp);
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

        public bool UpdateShift(CommContracts.Shift Shift)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Shifts.FirstOrDefault(m => m.ID == Shift.ID);
                if (temp != null)
                {
                    temp.Name = Shift.Name;
                    temp.StartTime = Shift.StartTime;
                    temp.EndTime = Shift.EndTime;
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
