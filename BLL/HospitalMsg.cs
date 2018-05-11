using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HospitalMsg
    {
        public List<CommContracts.HospitalMsg> GetAllHospitalMsg(string strName)
        {
            List<CommContracts.HospitalMsg> list = new List<CommContracts.HospitalMsg>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.HospitalMsgs
                            where t.HospitalName.StartsWith(strName) 
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.HospitalMsg, CommContracts.HospitalMsg>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.HospitalMsg tem in query)
                {
                    var dto = mapper.Map<CommContracts.HospitalMsg>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveHospitalMsg(CommContracts.HospitalMsg HospitalMsg)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.HospitalMsg, DAL.HospitalMsg>();
                });
                var mapper = config.CreateMapper();

                DAL.HospitalMsg temp = new DAL.HospitalMsg();
                temp = mapper.Map<DAL.HospitalMsg>(HospitalMsg);

                ctx.HospitalMsgs.Add(temp);
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

        public bool DeleteHospitalMsg(int HospitalMsgID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.HospitalMsgs.FirstOrDefault(m => m.ID == HospitalMsgID);
                if (temp != null)
                {
                    ctx.HospitalMsgs.Remove(temp);
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

        public bool UpdateHospitalMsg(CommContracts.HospitalMsg HospitalMsg)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.HospitalMsgs.FirstOrDefault(m => m.ID == HospitalMsg.ID);
                if (temp != null)
                {
                    temp.HospitalName = HospitalMsg.HospitalName;
                    temp.YiBaoNo = HospitalMsg.YiBaoNo;
                    temp.bIsYiBao = HospitalMsg.bIsYiBao;
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
