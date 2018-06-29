using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DiagnoseItem
    {
        public List<CommContracts.DiagnoseItem> GetAllDiagnoseItem(string strName)
        {
            List<CommContracts.DiagnoseItem> list = new List<CommContracts.DiagnoseItem>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.DiagnoseItems
                            where t.Name.StartsWith(strName) ||
                            t.Abbr.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.DiagnoseItem, CommContracts.DiagnoseItem>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.DiagnoseItem tem in query)
                {
                    var dto = mapper.Map<CommContracts.DiagnoseItem>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveDiagnoseItem(CommContracts.DiagnoseItem DiagnoseItem)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.DiagnoseItem, DAL.DiagnoseItem>();
                });
                var mapper = config.CreateMapper();

                DAL.DiagnoseItem temp = new DAL.DiagnoseItem();
                temp = mapper.Map<DAL.DiagnoseItem>(DiagnoseItem);

                ctx.DiagnoseItems.Add(temp);
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

        public bool DeleteDiagnoseItem(int DiagnoseItemID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.DiagnoseItems.FirstOrDefault(m => m.ID == DiagnoseItemID);
                if (temp != null)
                {
                    ctx.DiagnoseItems.Remove(temp);
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

        public bool UpdateDiagnoseItem(CommContracts.DiagnoseItem DiagnoseItem)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.DiagnoseItems.FirstOrDefault(m => m.ID == DiagnoseItem.ID);
                if (temp != null)
                {
                    temp.Name = DiagnoseItem.Name;
                    temp.Abbr = DiagnoseItem.Abbr;
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
