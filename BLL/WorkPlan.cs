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
    public class WorkPlan
    {
        public List<DateTime> getAllWorkPlanDate(int DepartmentID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = (from u in ctx.WorkPlans
                            where u.DepartmentID == DepartmentID &&
                            (u.VistDate.HasValue && u.VistDate.Value.Date >= DateTime.Now.Date) &&
                            (u.WorkPlanStatus == DAL.WorkPlanStatus.eIsOk || u.WorkPlanStatus == DAL.WorkPlanStatus.eIsTempStop)
                            select DbFunctions.TruncateTime(u.VistDate)).Distinct();

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
                    temp.Price = signalSource.Price;
                    temp.VistDate = signalSource.VistDate;
                    temp.SignalItemID = signalSource.SignalItemID;
                    temp.EmployeeID = signalSource.EmployeeID;
                    temp.DepartmentID = signalSource.DepartmentID;
                    temp.ClinicVistTimeID = signalSource.ClinicVistTimeID;
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

        public List<CommContracts.WorkPlan> GetWorkPlanList(int DepartmentID, int EmployeeID, DateTime startDate, DateTime endDate)
        {
            List<CommContracts.WorkPlan> list = new List<CommContracts.WorkPlan>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.WorkPlans
                            where
                            (DepartmentID <= 0 || a.DepartmentID == DepartmentID) &&
                            (EmployeeID <= 0 || a.EmployeeID == EmployeeID) &&
                            a.VistDate.Value <= endDate &&
                            a.VistDate.Value >= startDate &&
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
    }
}
