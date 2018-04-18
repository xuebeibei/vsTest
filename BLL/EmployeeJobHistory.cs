using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeJobHistory
    {
        public List<CommContracts.Employee> GetAllJobEmployee(int JobID)
        {
            List<CommContracts.Employee> list = new List<CommContracts.Employee>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from e in ctx.EmployeeJobHistorys
                            where
                            (JobID == 0 || e.JobID == JobID) &&
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

        public List<CommContracts.EmployeeJobHistory> GetAllEmployeeJobHistory(int EmployeeID)
        {
            List<CommContracts.EmployeeJobHistory> list = new List<CommContracts.EmployeeJobHistory>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.EmployeeJobHistorys
                            where t.EmployeeID == EmployeeID
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.EmployeeJobHistory, CommContracts.EmployeeJobHistory>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.EmployeeJobHistory tem in query)
                {
                    var dto = mapper.Map<CommContracts.EmployeeJobHistory>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveEmployeeJobHistory(CommContracts.EmployeeJobHistory EmployeeJobHistory)
        {
            DateTime nowTime = DateTime.Now;
            EmployeeJobHistory.StartDate = nowTime;
            EmployeeJobHistory.ModifiedDate = nowTime;

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var hisquery = from h in ctx.EmployeeJobHistorys
                               where h.EmployeeID == EmployeeJobHistory.EmployeeID &&
                               h.EndDate == null
                               select h;
                if (hisquery.Count() > 0)
                {
                    foreach (var te in hisquery)
                    {
                        te.EndDate = nowTime;
                        te.ModifiedDate = nowTime;
                    }
                }

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.EmployeeJobHistory, DAL.EmployeeJobHistory>()
                    .ForMember(x => x.Job, opt => opt.Ignore())
                    .ForMember(x => x.Employee, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.EmployeeJobHistory temp = new DAL.EmployeeJobHistory();
                temp = mapper.Map<DAL.EmployeeJobHistory>(EmployeeJobHistory);

                ctx.EmployeeJobHistorys.Add(temp);
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

        public bool DeleteEmployeeJobHistory(int EmployeeJobHistoryID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.EmployeeJobHistorys.FirstOrDefault(m => m.ID == EmployeeJobHistoryID);
                if (temp != null)
                {
                    ctx.EmployeeJobHistorys.Remove(temp);
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

        public bool UpdateEmployeeJobHistory(CommContracts.EmployeeJobHistory EmployeeJobHistory)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.EmployeeJobHistorys.FirstOrDefault(m => m.ID == EmployeeJobHistory.ID);
                if (temp != null)
                {
                    temp.EmployeeID = EmployeeJobHistory.EmployeeID;
                    temp.JobID = EmployeeJobHistory.JobID;
                    temp.StartDate = EmployeeJobHistory.StartDate;
                    temp.EndDate = EmployeeJobHistory.EndDate;
                    temp.ModifiedDate = EmployeeJobHistory.ModifiedDate;
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
