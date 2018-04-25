using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SignalType
    {
        public List<CommContracts.SignalType> GetAllSignalType(string strName = "")
        {
            List<CommContracts.SignalType> list = new List<CommContracts.SignalType>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.SignalTypes
                            where a.WorkType.Name.StartsWith(strName)
                            select a;
                foreach (DAL.SignalType ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.SignalType, CommContracts.SignalType>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.SignalType temp = mapper.Map<CommContracts.SignalType>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveSignalType(CommContracts.SignalType SignalType)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.SignalType, DAL.SignalType>();
                });
                var mapper = config.CreateMapper();

                DAL.SignalType temp = new DAL.SignalType();
                temp = mapper.Map<DAL.SignalType>(SignalType);

                ctx.SignalTypes.Add(temp);
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

        public bool DeleteSignalType(int SignalTypeID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.SignalTypes.FirstOrDefault(m => m.ID == SignalTypeID);
                if (temp != null)
                {
                    ctx.SignalTypes.Remove(temp);
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

        public bool UpdateSignalType(CommContracts.SignalType SignalType)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.SignalTypes.FirstOrDefault(m => m.ID == SignalType.ID);
                if (temp != null)
                {
                    temp.WorkTypeID = SignalType.WorkTypeID;
                    temp.Name = SignalType.Name;
                    temp.JobID = SignalType.JobID;
                    temp.WorkTypeID = SignalType.WorkTypeID;
                    temp.DoctorClinicFee = SignalType.DoctorClinicFee;
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
