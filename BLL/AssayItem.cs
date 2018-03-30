using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AssayItem
    {
        public List<CommContracts.AssayItem> GetAllAssayItem(string strName)
        {
            List<CommContracts.AssayItem> list = new List<CommContracts.AssayItem>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.AssayItems
                            where t.Name.StartsWith(strName) ||
                            t.AbbrPY.StartsWith(strName) ||
                            t.AbbrWB.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.AssayItem, CommContracts.AssayItem>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.AssayItem tem in query)
                {
                    var dto = mapper.Map<CommContracts.AssayItem>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveAssayItem(CommContracts.AssayItem AssayItem)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.AssayItem, DAL.AssayItem>();
                });
                var mapper = config.CreateMapper();

                DAL.AssayItem temp = new DAL.AssayItem();
                temp = mapper.Map<DAL.AssayItem>(AssayItem);

                ctx.AssayItems.Add(temp);
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

        public bool DeleteAssayItem(int AssayItemID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.AssayItems.FirstOrDefault(m => m.ID == AssayItemID);
                if (temp != null)
                {
                    ctx.AssayItems.Remove(temp);
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

        public bool UpdateAssayItem(CommContracts.AssayItem AssayItem)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.AssayItems.FirstOrDefault(m => m.ID == AssayItem.ID);
                if (temp != null)
                {
                    temp.Name = AssayItem.Name;
                    temp.AbbrPY = AssayItem.AbbrPY;
                    temp.AbbrWB = AssayItem.AbbrWB;
                    temp.Unit = AssayItem.Unit;
                    temp.YiBaoEnum = (DAL.YiBaoEnum)AssayItem.YiBaoEnum;

                    temp.Price = AssayItem.Price;
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
