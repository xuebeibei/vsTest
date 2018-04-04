using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RegistrationDitch
    {
        public List<CommContracts.RegistrationDitch> GetAllRegistrationDitch(string strName)
        {
            List<CommContracts.RegistrationDitch> list = new List<CommContracts.RegistrationDitch>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.RegistrationDitchs
                            where t.Name.StartsWith(strName) 
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.RegistrationDitch, CommContracts.RegistrationDitch>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.RegistrationDitch tem in query)
                {
                    var dto = mapper.Map<CommContracts.RegistrationDitch>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveRegistrationDitch(CommContracts.RegistrationDitch RegistrationDitch)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.RegistrationDitch, DAL.RegistrationDitch>();
                });
                var mapper = config.CreateMapper();

                DAL.RegistrationDitch temp = new DAL.RegistrationDitch();
                temp = mapper.Map<DAL.RegistrationDitch>(RegistrationDitch);

                ctx.RegistrationDitchs.Add(temp);
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

        public bool DeleteRegistrationDitch(int RegistrationDitchID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.RegistrationDitchs.FirstOrDefault(m => m.ID == RegistrationDitchID);
                if (temp != null)
                {
                    ctx.RegistrationDitchs.Remove(temp);
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

        public bool UpdateRegistrationDitch(CommContracts.RegistrationDitch RegistrationDitch)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.RegistrationDitchs.FirstOrDefault(m => m.ID == RegistrationDitch.ID);
                if (temp != null)
                {
                    temp.Name = RegistrationDitch.Name;
                    temp.Priority = RegistrationDitch.Priority;
                    temp.Proportion = RegistrationDitch.Proportion;
                    temp.Status = RegistrationDitch.Status;
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
