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
        public List<CommContracts.LoginInAndOutRecords> GetAllLoginInAndOutRecords(string strName)
        {
            List<CommContracts.LoginInAndOutRecords> list = new List<CommContracts.LoginInAndOutRecords>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.LoginInAndOutRecords
                            where t.User.Username.StartsWith(strName) 
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.LoginInAndOutRecords, CommContracts.LoginInAndOutRecords>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.LoginInAndOutRecords tem in query)
                {
                    var dto = mapper.Map<CommContracts.LoginInAndOutRecords>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveLoginInAndOutRecords(CommContracts.LoginInAndOutRecords LoginInAndOutRecords)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.LoginInAndOutRecords, DAL.LoginInAndOutRecords>().ForMember(x => x.User, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.LoginInAndOutRecords temp = new DAL.LoginInAndOutRecords();
                temp = mapper.Map<DAL.LoginInAndOutRecords>(LoginInAndOutRecords);

                ctx.LoginInAndOutRecords.Add(temp);
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

        public bool DeleteLoginInAndOutRecords(int LoginInAndOutRecordsID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.LoginInAndOutRecords.FirstOrDefault(m => m.ID == LoginInAndOutRecordsID);
                if (temp != null)
                {
                    ctx.LoginInAndOutRecords.Remove(temp);
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

        public bool UpdateLoginInAndOutRecords(CommContracts.LoginInAndOutRecords LoginInAndOutRecords)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.LoginInAndOutRecords.FirstOrDefault(m => m.ID == LoginInAndOutRecords.ID);
                if (temp != null)
                {
                    temp.UserID = LoginInAndOutRecords.UserID;
                    temp.LoginMachineCode = LoginInAndOutRecords.LoginMachineCode;
                    temp.LoginInOrLoginOut = LoginInAndOutRecords.LoginInOrLoginOut;
                    temp.CurrentTime = LoginInAndOutRecords.CurrentTime;
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
