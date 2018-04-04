using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClinicVistTime
    {
        public List<CommContracts.ClinicVistTime> GetAllClinicVistTime(string strName = "")
        {
            List<CommContracts.ClinicVistTime> list = new List<CommContracts.ClinicVistTime>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.ClinicVistTimes
                            where a.Name.StartsWith(strName)
                            select a;
                foreach (DAL.ClinicVistTime ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.ClinicVistTime, CommContracts.ClinicVistTime>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.ClinicVistTime temp = mapper.Map<CommContracts.ClinicVistTime>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveClinicVistTime(CommContracts.ClinicVistTime ClinicVistTime)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.ClinicVistTime, DAL.ClinicVistTime>();
                });
                var mapper = config.CreateMapper();

                DAL.ClinicVistTime temp = new DAL.ClinicVistTime();
                temp = mapper.Map<DAL.ClinicVistTime>(ClinicVistTime);

                ctx.ClinicVistTimes.Add(temp);
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

        public bool DeleteClinicVistTime(int ClinicVistTimeID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.ClinicVistTimes.FirstOrDefault(m => m.ID == ClinicVistTimeID);
                if (temp != null)
                {
                    ctx.ClinicVistTimes.Remove(temp);
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

        public bool UpdateClinicVistTime(CommContracts.ClinicVistTime ClinicVistTime)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.ClinicVistTimes.FirstOrDefault(m => m.ID == ClinicVistTime.ID);
                if (temp != null)
                {
                    temp.ID = ClinicVistTime.ID;
                    temp.Name = ClinicVistTime.Name;
                    temp.StartVistTime = ClinicVistTime.StartVistTime;
                    temp.EndVistTime = ClinicVistTime.EndVistTime;
                    temp.StartWaitTime = ClinicVistTime.StartWaitTime;
                    temp.EndWaitTime = ClinicVistTime.EndWaitTime;
                    temp.LastSellTime = ClinicVistTime.LastSellTime;
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
