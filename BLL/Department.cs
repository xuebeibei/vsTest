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
using AutoMapper;

namespace BLL
{
    public class Department
    {
        public int getAllDepartmentNum()
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var queryResult = from u in ctx.Departments
                                  select u;

                return queryResult.Count();
            }
        }

        public List<CommContracts.Department> getALLDepartment(string strName = "")
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {

                IEnumerable<DAL.Department> queryResultList = from u in ctx.Departments
                                                              where u.Name.StartsWith(strName) || 
                                                              u.Abbr.StartsWith(strName)
                                                                        select u;
                List<CommContracts.Department> myList = new List<CommContracts.Department>();

                
                foreach(DAL.Department tem in queryResultList)
                {
                    CommContracts.Department temp1 = new CommContracts.Department();
                    temp1.ID = tem.ID;
                    temp1.Name = tem.Name;
                    temp1.Abbr = tem.Abbr;
                    temp1.IsDoctorDepartment = (tem.DepartmentEnum == DAL.DepartmentEnum.临床科室);
                    temp1.DepartmentEnum = (CommContracts.DepartmentEnum)tem.DepartmentEnum;
                    temp1.ParentDepartmentID = tem.ParentID;

                    myList.Add(temp1);
                }
                return myList;
            }
        }

        public bool SaveDepartment(CommContracts.Department department)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Department, DAL.Department>();
                });
                var mapper = config.CreateMapper();

                DAL.Department temp = new DAL.Department();
                temp = mapper.Map<DAL.Department>(department);
                
                ctx.Departments.Add(temp);
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

        public bool DeleteDepartment(int departmentID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Departments.FirstOrDefault(m => m.ID == departmentID);
                if(temp != null)
                {
                    ctx.Departments.Remove(temp);
                }

                try
                {
                    ctx.SaveChanges();
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        public bool UpdateDepartment(CommContracts.Department department)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Departments.FirstOrDefault(m => m.ID == department.ID);
                if (temp != null)
                {
                    //var config = new MapperConfiguration(cfg =>
                    //{
                    //    cfg.CreateMap<CommContracts.Department, DAL.Department>().ForMember(x=>x.ID, opt => opt.Ignore()) ;
                    //});
                    //var mapper = config.CreateMapper();

                    //temp = mapper.Map<DAL.Department>(department);
                    // 这里使用mapper来更新数据之后保存不上，不知为何
                    temp.Name = department.Name;
                    temp.Abbr = department.Abbr;
                    temp.DepartmentEnum = (DAL.DepartmentEnum)department.DepartmentEnum;
                    temp.ParentID = department.ParentDepartmentID;
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
    }
}