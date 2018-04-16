using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CancelRegistration
    {
        public bool SaveCancelRegistration(CommContracts.CancelRegistration cancelRegistration)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                cancelRegistration.LastUpdateTime = DateTime.Now;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.CancelRegistration, DAL.CancelRegistration>().
                    ForMember(x => x.Registration, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.CancelRegistration temp = new DAL.CancelRegistration();
                temp = mapper.Map<DAL.CancelRegistration>(cancelRegistration);

                ctx.CancelRegistrations.Add(temp);
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
