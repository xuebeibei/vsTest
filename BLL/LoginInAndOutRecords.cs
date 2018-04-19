using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoginInAndOutRecords
    {
        public List<CommContracts.EmployeeLoginHistory> GetAllLoginInAndOutRecords(string strName)
        {
            List<CommContracts.EmployeeLoginHistory> list = new List<CommContracts.EmployeeLoginHistory>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.EmployeeLoginHistorys
                            where t.Employees.LoginName.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.EmployeeLoginHistory, CommContracts.EmployeeLoginHistory>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.EmployeeLoginHistory tem in query)
                {
                    var dto = mapper.Map<CommContracts.EmployeeLoginHistory>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveLoginInAndOutRecords(CommContracts.EmployeeLoginHistory LoginInAndOutRecords)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.EmployeeLoginHistory, DAL.EmployeeLoginHistory>().ForMember(x => x.Employees, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.EmployeeLoginHistory temp = new DAL.EmployeeLoginHistory();
                temp = mapper.Map<DAL.EmployeeLoginHistory>(LoginInAndOutRecords);

                ctx.EmployeeLoginHistorys.Add(temp);
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

        public bool DeleteLoginInAndOutRecords(int LoginInAndOutRecordsID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.EmployeeLoginHistorys.FirstOrDefault(m => m.ID == LoginInAndOutRecordsID);
                if (temp != null)
                {
                    ctx.EmployeeLoginHistorys.Remove(temp);
                }

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

        public bool UpdateLoginInAndOutRecords(CommContracts.EmployeeLoginHistory LoginInAndOutRecords)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.EmployeeLoginHistorys.FirstOrDefault(m => m.ID == LoginInAndOutRecords.ID);
                if (temp != null)
                {
                    temp.EmployeeID = LoginInAndOutRecords.EmployeeID;
                    temp.LoginMachineCode = LoginInAndOutRecords.LoginMachineCode;
                    temp.LoginTime = LoginInAndOutRecords.LoginTime;
                    temp.LoginOutTime = LoginInAndOutRecords.LoginOutTime;
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
                catch (Exception ex)
                {
                    string str = ex.Message;
                    return false;
                }
            }
            return true;
        }
    }
}
