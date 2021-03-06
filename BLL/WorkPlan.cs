﻿using System;
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
    public class WorkPlan
    {
        public List<DateTime> getAllWorkPlanDate(int DepartmentID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = (from u in ctx.WorkPlans
                            where u.DepartmentID == DepartmentID &&
                            (u.WorkPlanDate.HasValue && u.WorkPlanDate.Value.Date >= DateTime.Now.Date) &&
                            (u.WorkPlanStatus == DAL.WorkPlanStatus.eIsOk || u.WorkPlanStatus == DAL.WorkPlanStatus.eIsTempStop)
                            select DbFunctions.TruncateTime(u.WorkPlanDate)).Distinct();

                List<DateTime> myList = new List<DateTime>();

                try
                {
                    foreach (var item in temp)
                    {

                        var time = item.ToString();

                        myList.Add(Convert.ToDateTime(time));


                    }
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    return null;
                }
                return myList;
            }
        }

        public List<int> getAllWorkPlanIntival(int DepartmentID)
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

        public string getWorkPlanTip(int DepartmentID, DateTime dateTime, int TimeIntival)
        {
#pragma warning disable CS0219 // 变量“temp”已被赋值，但从未使用过它的值
            string temp = "";
#pragma warning restore CS0219 // 变量“temp”已被赋值，但从未使用过它的值
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

        public bool UpdateWorkPlanHasUsedNum(int nSignalSourceID)
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

        public List<CommContracts.WorkPlan> GetAllWorkPlan()
        {
            List<CommContracts.WorkPlan> list = new List<CommContracts.WorkPlan>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.WorkPlans
                            select a;
                foreach (DAL.WorkPlan ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.WorkPlan, CommContracts.WorkPlan>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.WorkPlan temp = mapper.Map<CommContracts.WorkPlan>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveWorkPlan(CommContracts.WorkPlan signalSource)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.WorkPlan, DAL.WorkPlan>();
                });
                var mapper = config.CreateMapper();

                DAL.WorkPlan temp = new DAL.WorkPlan();
                temp = mapper.Map<DAL.WorkPlan>(signalSource);

                ctx.WorkPlans.Add(temp);
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

        public bool DeleteWorkPlan(int signalSourceID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.WorkPlans.FirstOrDefault(m => m.ID == signalSourceID);
                if (temp != null)
                {
                    ctx.WorkPlans.Remove(temp);
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

        public bool UpdateWorkPlan(CommContracts.WorkPlan signalSource)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.WorkPlans.FirstOrDefault(m => m.ID == signalSource.ID);
                if (temp != null)
                {
                    temp.WorkPlanDate = signalSource.WorkPlanDate;
                    temp.WorkTypeID = signalSource.WorkTypeID;
                    temp.EmployeeID = signalSource.EmployeeID;
                    temp.DepartmentID = signalSource.DepartmentID;
                    temp.ShiftID = signalSource.ShiftID;
                    temp.WorkPlanStatus = (DAL.WorkPlanStatus)signalSource.WorkPlanStatus;
                    temp.MaxNum = signalSource.MaxNum;
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

        public bool UpdateWorkPlanStatus(int workPlanID, CommContracts.WorkPlanStatus workPlanStatus)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.WorkPlans.Find(workPlanID);
                if (temp == null)
                    return false;

                temp.WorkPlanStatus = (DAL.WorkPlanStatus)workPlanStatus;
                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                    return false;
                }
            }

            return true;
        }

        public bool SaveWorkPlanList(List<CommContracts.WorkPlan> list)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                foreach (var signalSource in list)
                {
                    if (signalSource.ID != 0)
                    {
                        UpdateWorkPlan(signalSource);
                        continue;
                    }


                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<CommContracts.WorkPlan, DAL.WorkPlan>();
                    });
                    var mapper = config.CreateMapper();

                    DAL.WorkPlan temp = new DAL.WorkPlan();
                    temp = mapper.Map<DAL.WorkPlan>(signalSource);

                    ctx.WorkPlans.Add(temp);
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

        public List<CommContracts.WorkPlan> GetWorkPlanList(int DepartmentID, int EmployeeID, DateTime startDate, DateTime endDate, int ClinicVistTimeID)
        {
            List<CommContracts.WorkPlan> list = new List<CommContracts.WorkPlan>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.WorkPlans
                            from b in ctx.SignalTypes
                            where
                            (DepartmentID <= 0 || a.DepartmentID == DepartmentID) &&
                            (EmployeeID <= 0 || a.EmployeeID == EmployeeID) &&
                            (ClinicVistTimeID <= 0 || a.ShiftID == ClinicVistTimeID) &&
                            a.WorkTypeID == b.WorkTypeID &&
                            a.WorkPlanDate.Value <= endDate &&
                            a.WorkPlanDate.Value >= startDate &&
                            (a.WorkPlanStatus == DAL.WorkPlanStatus.eIsOk || a.WorkPlanStatus == DAL.WorkPlanStatus.eIsTempStop)
                            select a;
                foreach (DAL.WorkPlan ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.WorkPlan, CommContracts.WorkPlan>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.WorkPlan temp = mapper.Map<CommContracts.WorkPlan>(ass);

                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.WorkPlanToSignalSource> GetAllWorkPlan111(int DepartmentID, DateTime startDate, DateTime endDate)
        {
            List<CommContracts.WorkPlanToSignalSource> list = new List<CommContracts.WorkPlanToSignalSource>();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                //var query = from a in ctx.WorkPlans
                //            from b in ctx.SignalTypes
                //            where
                //            (DepartmentID <= 0 || a.DepartmentID == DepartmentID) &&
                //            a.WorkTypeID == b.WorkTypeID &&
                //            a.WorkPlanDate.Value <= endDate &&
                //            a.WorkPlanDate.Value >= startDate &&
                //            (a.WorkPlanStatus == DAL.WorkPlanStatus.eIsOk || a.WorkPlanStatus == DAL.WorkPlanStatus.eIsTempStop)
                //            select a;

                var query = from w in ctx.WorkPlans
                            from s in ctx.SignalTypes
                            from j in ctx.EmployeeJobHistorys 
                            where w.DepartmentID == DepartmentID &&
                            w.WorkPlanDate.Value <= endDate &&
                            w.WorkPlanDate.Value >= startDate &&
                            w.WorkPlanStatus == DAL.WorkPlanStatus.eIsOk && 
                            s.WorkTypeID == w.WorkTypeID && 
                            w.Employee.ID == j.EmployeeID && 
                            !j.EndDate.HasValue && 
                            j.JobID == s.JobID


                            select new { w, s };

                int n = query.Count();

                
                foreach(var temp in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.WorkPlan, CommContracts.WorkPlan>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.WorkPlan w = mapper.Map<CommContracts.WorkPlan>(temp.w);

                    var config1 = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.SignalType, CommContracts.SignalType>();
                    });
                    var mapper1 = config1.CreateMapper();

                    CommContracts.SignalType s = mapper1.Map<CommContracts.SignalType>(temp.s);

                    CommContracts.WorkPlanToSignalSource ws = new CommContracts.WorkPlanToSignalSource();
                    ws.WorkPlan = w;
                    ws.SignalType = s;
                    list.Add(ws);

                    
                }
            }
            return list;
        }
    }
}
