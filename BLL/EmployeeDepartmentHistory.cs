using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeDepartmentHistory
    {
        public List<CommContracts.Employee> GetAllDepartmentEmployee(int DepartmentID)
        {
            List<CommContracts.Employee> list = new List<CommContracts.Employee>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from e in ctx.EmployeeDepartmentHistorys
                            where (DepartmentID == 0 || e.DepartmentID == DepartmentID) &&
                            !e.EndDate.HasValue
                            select e.Employee;
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

        public List<CommContracts.Employee> GetAllDepartmentDoctor(int DepartmentID)
        {
            List<CommContracts.Employee> list = new List<CommContracts.Employee>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from ed in ctx.EmployeeDepartmentHistorys
                            from ej in ctx.EmployeeJobHistorys
                            from j in ctx.Jobs
                            where (ed.DepartmentID == 0 || ed.DepartmentID == DepartmentID) &&
                            !ed.EndDate.HasValue &&
                            ed.EmployeeID == ej.EmployeeID &&
                            ej.JobID == j.ID &&
                            j.JobType == DAL.JobTypeEnum.医师 &&
                            !ej.EndDate.HasValue
                            select ed.Employee;

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

        public List<CommContracts.EmployeeDepartmentHistory> GetAllEmployeeDepartmentHistory(int EmployeeID)
        {
            List<CommContracts.EmployeeDepartmentHistory> list = new List<CommContracts.EmployeeDepartmentHistory>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.EmployeeDepartmentHistorys
                            where t.EmployeeID == EmployeeID 
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.EmployeeDepartmentHistory, CommContracts.EmployeeDepartmentHistory>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.EmployeeDepartmentHistory tem in query)
                {
                    var dto = mapper.Map<CommContracts.EmployeeDepartmentHistory>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveEmployeeDepartmentHistory(CommContracts.EmployeeDepartmentHistory EmployeeDepartmentHistory)
        {
            DateTime nowTime = DateTime.Now;
            EmployeeDepartmentHistory.StartDate = nowTime;
            EmployeeDepartmentHistory.ModifiedDate = nowTime;

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var hisquery = from h in ctx.EmployeeDepartmentHistorys
                               where h.EmployeeID == EmployeeDepartmentHistory.EmployeeID &&
                               h.EndDate == null
                               select h;
                if(hisquery.Count() > 0)
                {
                    foreach(var te in hisquery)
                    {
                        te.EndDate = nowTime;
                        te.ModifiedDate = nowTime;
                    }
                }

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.EmployeeDepartmentHistory, DAL.EmployeeDepartmentHistory>()
                    .ForMember(x => x.Department, opt => opt.Ignore())
                    .ForMember(x => x.Employee, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.EmployeeDepartmentHistory temp = new DAL.EmployeeDepartmentHistory();
                temp = mapper.Map<DAL.EmployeeDepartmentHistory>(EmployeeDepartmentHistory);

                ctx.EmployeeDepartmentHistorys.Add(temp);
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

        public bool DeleteEmployeeDepartmentHistory(int EmployeeDepartmentHistoryID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.EmployeeDepartmentHistorys.FirstOrDefault(m => m.ID == EmployeeDepartmentHistoryID);
                if (temp != null)
                {
                    ctx.EmployeeDepartmentHistorys.Remove(temp);
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

        public bool UpdateEmployeeDepartmentHistory(CommContracts.EmployeeDepartmentHistory EmployeeDepartmentHistory)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.EmployeeDepartmentHistorys.FirstOrDefault(m => m.ID == EmployeeDepartmentHistory.ID);
                if (temp != null)
                {
                    temp.EmployeeID = EmployeeDepartmentHistory.EmployeeID;
                    temp.DepartmentID = EmployeeDepartmentHistory.DepartmentID;
                    temp.StartDate = EmployeeDepartmentHistory.StartDate;
                    temp.EndDate = EmployeeDepartmentHistory.EndDate;
                    temp.ModifiedDate = EmployeeDepartmentHistory.ModifiedDate;
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
