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

        public List<CommContracts.Department> getALLDepartment(CommContracts.DepartmentEnum departmentEnum)
        {
            List<CommContracts.Department> list = new List<CommContracts.Department>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from u in ctx.Departments
                            where u.DepartmentEnum == (DAL.DepartmentEnum)departmentEnum
                            select u;
                foreach (DAL.Department ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Department, CommContracts.Department>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Department temp = mapper.Map<CommContracts.Department>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.Department> getALLDepartment(string strName = "")
        {
            List<CommContracts.Department> list = new List<CommContracts.Department>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from u in ctx.Departments
                            where u.Name.StartsWith(strName)
                            select u;
                foreach (DAL.Department ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Department, CommContracts.Department>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Department temp = mapper.Map<CommContracts.Department>(ass);
                    list.Add(temp);
                }
            }
            return list;
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
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
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
                if (temp != null)
                {
                    ctx.Departments.Remove(temp);
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
                    temp.ParentID = department.ParentID;
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