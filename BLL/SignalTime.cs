using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SignalTime
    {
        public List<CommContracts.SignalTime> GetAllClinicVistTime(string strName = "")
        {
            List<CommContracts.SignalTime> list = new List<CommContracts.SignalTime>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.SignalTimes
                            where a.Shift.Name.StartsWith(strName)
                            select a;
                foreach (DAL.SignalTime ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.SignalTime, CommContracts.SignalTime>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.SignalTime temp = mapper.Map<CommContracts.SignalTime>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveClinicVistTime(CommContracts.SignalTime ClinicVistTime)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var replicequery = from u in ctx.SignalTimes
                                   where u.ShiftID == ClinicVistTime.ShiftID
                                   select u;
                if (replicequery.Count() > 0)
                    return false;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.SignalTime, DAL.SignalTime>();
                });
                var mapper = config.CreateMapper();

                DAL.SignalTime temp = new DAL.SignalTime();
                temp = mapper.Map<DAL.SignalTime>(ClinicVistTime);

                ctx.SignalTimes.Add(temp);
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
                var temp = ctx.SignalTimes.FirstOrDefault(m => m.ID == ClinicVistTimeID);
                if (temp != null)
                {
                    ctx.SignalTimes.Remove(temp);
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

        public bool UpdateClinicVistTime(CommContracts.SignalTime ClinicVistTime)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.SignalTimes.FirstOrDefault(m => m.ID == ClinicVistTime.ID);
                if (temp != null)
                {
                    temp.ID = ClinicVistTime.ID;
                    temp.ShiftID = ClinicVistTime.ShiftID;
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
