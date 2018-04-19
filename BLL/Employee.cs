using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Employee
    {
        public CommContracts.Employee Authenticate(string LoginName, string Password, string MachineCode)
        {
            CommContracts.Employee temp = new CommContracts.Employee();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var queryResult = from u in ctx.Employees
                                  where u.LoginName == LoginName &&
                                        u.Password == Password
                                  select u;

                if (queryResult.Count() == 1)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Employee, CommContracts.Employee>();
                    });
                    var mapper = config.CreateMapper();

                    temp = mapper.Map<CommContracts.Employee>(queryResult.First());


                    //检查重复登录的，暂时隐藏，以便开发调试
                    //var queryLoginHistory = from h in ctx.EmployeeLoginHistorys
                    //                        where h.EmployeeID == temp.ID &&
                    //                        !h.LoginOutTime.HasValue
                    //                        select h;
                    //if (queryLoginHistory.Count() == 0)
                    //{
                    //    DAL.EmployeeLoginHistory employeeLogin = new DAL.EmployeeLoginHistory();
                    //    employeeLogin.EmployeeID = temp.ID;
                    //    employeeLogin.LoginTime = DateTime.Now;
                    //    employeeLogin.ModifiedDate = DateTime.Now;
                    //    employeeLogin.LoginMachineCode = MachineCode;
                    //    ctx.EmployeeLoginHistorys.Add(employeeLogin);
                    //}
                    //else
                    //{
                    //    return null;
                    //}


                    try
                    {
                        ctx.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        string str = ex.Message;
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            if (temp.ID == 0)
                return null;
            return temp;
        }

        public bool Logout(CommContracts.Employee employee)
        {
            //配合检查重复登录的，编码期间暂时不用，等上线时候再开通
            //using (DAL.HisContext ctx = new DAL.HisContext())
            //{
            //    var queryResult = from u in ctx.EmployeeLoginHistorys
            //                      where u.EmployeeID == employee.ID &&
            //                            !u.LoginOutTime.HasValue
            //                      select u;
            //    if (queryResult.Count() == 1)
            //    {
            //        var u = queryResult.First();
            //        u.LoginOutTime = DateTime.Now;
            //        u.ModifiedDate = DateTime.Now;
            //        ctx.SaveChanges();
            //        return true;
            //    }
            //    return false;
            //}
            return true;
        }

        public List<CommContracts.Employee> GetAllEmployee(string strName = "")
        {
            List<CommContracts.Employee> list = new List<CommContracts.Employee>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.Employees
                            join b in ctx.EmployeeDepartmentHistorys
                            on a.ID equals b.EmployeeID into tt
                            from b in tt.DefaultIfEmpty()
                            where !b.EndDate.HasValue
                            && a.Name.StartsWith(strName)
                            select new { a, b.Department };
                foreach (var ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Employee, CommContracts.Employee>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Employee temp = mapper.Map<CommContracts.Employee>(ass.a);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveEmployee(CommContracts.Employee employee, ref int employeeID)
        {
            employee.ModifiedDate = DateTime.Now;

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Employee, DAL.Employee>();
                });
                var mapper = config.CreateMapper();

                DAL.Employee temp = new DAL.Employee();
                temp = mapper.Map<DAL.Employee>(employee);

                ctx.Employees.Add(temp);
                try
                {
                    ctx.SaveChanges();
                    employeeID = temp.ID;
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                    return false;
                }
            }
            return true;
        }

        public bool DeleteEmployee(int employeeID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Employees.FirstOrDefault(m => m.ID == employeeID);
                if (temp != null)
                {
                    ctx.Employees.Remove(temp);
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

        public bool UpdateEmployee(CommContracts.Employee employee)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Employees.FirstOrDefault(m => m.ID == employee.ID);
                if (temp != null)
                {
                    temp.Name = employee.Name;
                    temp.Gender = (DAL.GenderEnum)employee.Gender;
                    temp.LoginName = employee.LoginName;
                    temp.Password = employee.Password;
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

        public CommContracts.Department GetCurrentDepartment(int employeeID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from u in ctx.EmployeeDepartmentHistorys
                            where u.EmployeeID == employeeID &&
                            !u.EndDate.HasValue
                            select u.Department;

                if (query.Count() == 1)
                {
                    DAL.Department department = query.First() as DAL.Department;

                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Department, CommContracts.Department>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Department temp = new CommContracts.Department();
                    temp = mapper.Map<CommContracts.Department>(department);

                    return temp;
                }

                return null;
            }
        }

        public CommContracts.Job GetCurrentJob(int employeeID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from u in ctx.EmployeeJobHistorys
                            where u.EmployeeID == employeeID &&
                            !u.EndDate.HasValue
                            select u.Job;

                if (query.Count() == 1)
                {
                    DAL.Job Job = query.First() as DAL.Job;

                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Job, CommContracts.Job>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Job temp = new CommContracts.Job();
                    temp = mapper.Map<CommContracts.Job>(Job);

                    return temp;
                }

                return null;
            }
        }
    }
}
