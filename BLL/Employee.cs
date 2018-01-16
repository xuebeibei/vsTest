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
        public List<CommContracts.Employee> getAllDoctor()
        {
            List<CommContracts.Employee> list = new List<CommContracts.Employee>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from e in ctx.Employees 
                            select e;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Employee, CommContracts.Employee>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.Employee tem in query)
                {
                    var dto = mapper.Map<CommContracts.Employee>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public List<CommContracts.Employee> GetAllEmployee(string strName = "")
        {
            List<CommContracts.Employee> list = new List<CommContracts.Employee>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.Employees
                            where a.Name.StartsWith(strName)
                            select a;
                foreach (DAL.Employee ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Employee, CommContracts.Employee>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Employee temp = mapper.Map<CommContracts.Employee>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveEmployee(CommContracts.Employee employee)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Employee, DAL.Employee>().ForMember(x => x.Job, opt => opt.Ignore())
                    .ForMember(x=>x.Department, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.Employee temp = new DAL.Employee();
                temp = mapper.Map<DAL.Employee>(employee);

                ctx.Employees.Add(temp);
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
                catch (Exception ex)
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
                    temp.DepartmentID = employee.DepartmentID;
                    temp.JobID = employee.JobID;
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
