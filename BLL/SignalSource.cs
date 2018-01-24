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

namespace BLL
{
    public class SignalSource
    {
        public List<CommContracts.SignalSource> getALLSignalSource(int DepartmentID, DateTime dateTime, int timeInterval)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                IEnumerable<DAL.SignalSource> queryResultList = from u in ctx.SignalSources
                                                                    //where u.DepartmentID == DepartmentID &&
                                                                    //u.TimeIntival == timeInterval &&
                                                                where
                                                                SqlFunctions.DateDiff("day", dateTime, u.VistTime) == 0
                                                                select u;
     

                List<CommContracts.SignalSource> myList = new List<CommContracts.SignalSource>();
                foreach (DAL.SignalSource tem in queryResultList)
                {
                    CommContracts.SignalSource temp1 = new CommContracts.SignalSource();

                    temp1.ID = tem.ID;
                    temp1.Price = tem.Price;                 // 号源单价
                    temp1.VistTime = tem.VistTime;           // 看诊日期
                    //temp1.TimeIntival = tem.TimeIntival;     // 看诊时段ID
                    CommContracts.Department department = new CommContracts.Department();
                    department.ID = DepartmentID;

                    //temp1.GetDepartment = department;   // 科室
                    //temp1.SignalType = tem.SignalType;       // 号别
                    temp1.MaxNum = tem.MaxNum;               // 最大号源
                    //temp1.AddMaxNum = tem.AddMaxNum;         // 临时加号号源
                    //temp1.HasUsedNum = tem.HasUsedNum;       // 已挂号源
                    //temp1.Specialist = tem.Specialist;       // 专家ID
                    //temp1.Explain = tem.Explain;             // 说明


                    myList.Add(temp1);
                }
                return myList;
            }
        }

        public List<DateTime> getAllSignalDate(int DepartmentID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = (from u in ctx.SignalSources
                            //where u.DepartmentID == DepartmentID &&
                            where
                            SqlFunctions.DateDiff("day", DateTime.Now, u.VistTime) > 0
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
    }
}
