using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AdministrationRoute
    {
        public List<CommContracts.AdministrationRoute> GetAllAdministrationRoute(string strName)
        {
            List<CommContracts.AdministrationRoute> list = new List<CommContracts.AdministrationRoute>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.AdministrationRoutes
                            where t.Name.StartsWith(strName) ||
                            t.Abbr.StartsWith(strName) ||
                            t.WuBi.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.AdministrationRoute, CommContracts.AdministrationRoute>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.AdministrationRoute tem in query)
                {
                    var dto = mapper.Map<CommContracts.AdministrationRoute>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveAdministrationRoute(CommContracts.AdministrationRoute AdministrationRoute)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.AdministrationRoute, DAL.AdministrationRoute>();
                });
                var mapper = config.CreateMapper();

                DAL.AdministrationRoute temp = new DAL.AdministrationRoute();
                temp = mapper.Map<DAL.AdministrationRoute>(AdministrationRoute);

                ctx.AdministrationRoutes.Add(temp);
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

        public bool DeleteAdministrationRoute(int AdministrationRouteID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.AdministrationRoutes.FirstOrDefault(m => m.ID == AdministrationRouteID);
                if (temp != null)
                {
                    ctx.AdministrationRoutes.Remove(temp);
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

        public bool UpdateAdministrationRoute(CommContracts.AdministrationRoute AdministrationRoute)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.AdministrationRoutes.FirstOrDefault(m => m.ID == AdministrationRoute.ID);
                if (temp != null)
                {
                    temp.Name = AdministrationRoute.Name;
                    temp.Abbr = AdministrationRoute.Abbr;
                    temp.WuBi = AdministrationRoute.WuBi;
                    temp.Remarks = AdministrationRoute.Remarks;
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
