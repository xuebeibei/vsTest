using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TherapyItem
    {
        public List<CommContracts.TherapyItem> GetAllTherapyItem(string strName = "")
        {
            List<CommContracts.TherapyItem> list = new List<CommContracts.TherapyItem>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.TherapyItems
                            where t.Name.StartsWith(strName) ||
                            t.AbbrPY.StartsWith(strName) || 
                            t.AbbrWB.StartsWith(strName) 
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.TherapyItem, CommContracts.TherapyItem>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.TherapyItem tem in query)
                {
                    var dto = mapper.Map<CommContracts.TherapyItem>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveTherapyItem(CommContracts.TherapyItem TherapyItem)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.TherapyItem, DAL.TherapyItem>();
                });
                var mapper = config.CreateMapper();

                DAL.TherapyItem temp = new DAL.TherapyItem();
                temp = mapper.Map<DAL.TherapyItem>(TherapyItem);

                ctx.TherapyItems.Add(temp);
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

        public bool DeleteTherapyItem(int TherapyItemID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.TherapyItems.FirstOrDefault(m => m.ID == TherapyItemID);
                if (temp != null)
                {
                    ctx.TherapyItems.Remove(temp);
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

        public bool UpdateTherapyItem(CommContracts.TherapyItem TherapyItem)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.TherapyItems.FirstOrDefault(m => m.ID == TherapyItem.ID);
                if (temp != null)
                {
                    temp.Name = TherapyItem.Name;
                    temp.AbbrPY = TherapyItem.AbbrPY;
                    temp.AbbrWB = TherapyItem.AbbrWB;
                    temp.Unit = TherapyItem.Unit;
                    temp.YiBaoEnum = (DAL.YiBaoEnum)TherapyItem.YiBaoEnum;

                    temp.Price = TherapyItem.Price;
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
