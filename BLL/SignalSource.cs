using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.Entity;
using System.Data;
using System.Globalization;
using System.Collections;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using AutoMapper;

namespace BLL
{
    public class SignalSource
    {
        public List<DateTime> getAllSignalDate(int DepartmentID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = (from u in ctx.SignalSources
                            where u.DepartmentID == DepartmentID &&
                            (u.VistTime.HasValue && u.VistTime.Value.Date >= DateTime.Now.Date)
                            select DbFunctions.TruncateTime(u.VistTime)).Distinct();

                List<DateTime> myList = new List<DateTime>();

                try
                {
                    foreach (var item in temp)
                    {

                        var time = item.ToString();

                        myList.Add(Convert.ToDateTime(time));


                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
                return myList;
            }
        }

        public List<int> getAllSignalTimeIntival(int DepartmentID)
        {
            //using (DAL.HisContext ctx = new DAL.HisContext())
            //{
            //    var temp = (from u in ctx.SignalSources
            //                where u.DepartmentID == DepartmentID &&
            //                SqlFunctions.DateDiff("day", DateTime.Now, u.VistTime) > 0
            //                select u.TimeIntival).Distinct();

            //    List<int> myList = new List<int>();

            //    try
            //    {
            //        foreach (var item in temp)
            //        {

            //            var time = item.ToString();

            //            myList.Add(Convert.ToInt32(time));


            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //    return myList;
            //}
            return null;
        }

        public string getSignalSourceTip(int DepartmentID, DateTime dateTime, int TimeIntival)
        {
            string temp = "";
            //using (DAL.HisContext ctx = new DAL.HisContext())
            //{
            //    IEnumerable<DAL.SignalSource> queryResultList = from u in ctx.SignalSources
            //                                                    where SqlFunctions.DateDiff("day", dateTime, u.VistTime) == 0 && u.TimeIntival == TimeIntival && u.DepartmentID == DepartmentID
            //                                                    select u;

            //    int PuTong = 0;
            //    int ZhuanJia = 0;

            //    int PuTongShengYu = 0;
            //    int ZhuanJiaShengYu = 0;

            //    int nAll = 0;

            //    try
            //    {
            //        foreach (DAL.SignalSource tem in queryResultList)
            //        {
            //            if (tem.SignalType == 0)
            //            {
            //                PuTong += tem.MaxNum;
            //                PuTongShengYu += (tem.MaxNum - tem.HasUsedNum);
            //            }
            //            else if (tem.SignalType == 1)
            //            {
            //                ZhuanJia += tem.MaxNum;
            //                ZhuanJiaShengYu += (tem.MaxNum - tem.HasUsedNum);
            //            }
            //            nAll++;

            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        return "";
            //    }

            //    if (nAll > 0)
            //    {
            //        temp = "普通号：" + PuTongShengYu.ToString() + "/" + PuTong.ToString() +
            //        "\n专家号：" + ZhuanJiaShengYu.ToString() + "/" + ZhuanJia.ToString();
            //    }

            //    return temp;
            //}
            return "";
        }

        public bool UpdateSignalSource(int nSignalSourceID)
        {
            //using (DAL.HisContext ctx = new DAL.HisContext())
            //{
            //    var temp = ctx.SignalSources.Find(nSignalSourceID);
            //    if (temp == null)
            //        return false;

            //    temp.HasUsedNum = temp.HasUsedNum + 1;
            //    try
            //    {
            //        ctx.SaveChanges();
            //    }
            //    catch(Exception ex)
            //    {
            //        return false;
            //    }
            //}
            return true;
        }

        public List<CommContracts.SignalSource> GetAllSignalSource()
        {
            List<CommContracts.SignalSource> list = new List<CommContracts.SignalSource>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.SignalSources
                            select a;
                foreach (DAL.SignalSource ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.SignalSource, CommContracts.SignalSource>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.SignalSource temp = mapper.Map<CommContracts.SignalSource>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveSignalSource(CommContracts.SignalSource signalSource)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.SignalSource, DAL.SignalSource>();
                });
                var mapper = config.CreateMapper();

                DAL.SignalSource temp = new DAL.SignalSource();
                temp = mapper.Map<DAL.SignalSource>(signalSource);

                ctx.SignalSources.Add(temp);
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

        public bool DeleteSignalSource(int signalSourceID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.SignalSources.FirstOrDefault(m => m.ID == signalSourceID);
                if (temp != null)
                {
                    ctx.SignalSources.Remove(temp);
                }

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

        public bool UpdateSignalSource(CommContracts.SignalSource signalSource)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.SignalSources.FirstOrDefault(m => m.ID == signalSource.ID);
                if (temp != null)
                {
                    temp.Price = signalSource.Price;
                    temp.VistTime = signalSource.VistTime;
                    temp.SignalItemID = signalSource.SignalItemID;
                    temp.EmployeeID = signalSource.EmployeeID;
                    temp.DepartmentID = signalSource.DepartmentID;
                }
                else
                {
                    return false;
                }

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

        public bool SaveSignalSourceList(List<CommContracts.SignalSource> list)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                foreach (var signalSource in list)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<CommContracts.SignalSource, DAL.SignalSource>();
                    });
                    var mapper = config.CreateMapper();

                    DAL.SignalSource temp = new DAL.SignalSource();
                    temp = mapper.Map<DAL.SignalSource>(signalSource);

                    ctx.SignalSources.Add(temp);
                }
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

        public List<CommContracts.SignalSource> GetSignalSourceList(int DepartmentID, int EmployeeID, DateTime startDate, DateTime endDate)
        {
            List<CommContracts.SignalSource> list = new List<CommContracts.SignalSource>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.SignalSources
                            where
                            (DepartmentID > 0 && a.DepartmentID == DepartmentID) &&
                            (EmployeeID <= 0 || a.EmployeeID == EmployeeID) &&
                            a.VistTime.Value <= endDate &&
                            a.VistTime.Value >= startDate
                            select a;
                foreach (DAL.SignalSource ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.SignalSource, CommContracts.SignalSource>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.SignalSource temp = mapper.Map<CommContracts.SignalSource>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
