using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OtherServiceItem
    {
        public List<CommContracts.OtherServiceItem> GetAllOtherServiceItems(string strName)
        {
            List<CommContracts.OtherServiceItem> list = new List<CommContracts.OtherServiceItem>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.OtherServiceItem
                            where t.Name.StartsWith(strName) ||
                            t.AbbrPY.StartsWith(strName) ||
                            t.AbbrWB.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.OtherServiceItem, CommContracts.OtherServiceItem>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.OtherServiceItem tem in query)
                {
                    var dto = mapper.Map<CommContracts.OtherServiceItem>(tem);
                    list.Add(dto);
                }
            }
            return list;
        }

        public bool SaveOtherServiceItem(CommContracts.OtherServiceItem OtherServiceItem)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.OtherServiceItem, DAL.OtherServiceItem>();
                });
                var mapper = config.CreateMapper();

                DAL.OtherServiceItem temp = new DAL.OtherServiceItem();
                temp = mapper.Map<DAL.OtherServiceItem>(OtherServiceItem);

                ctx.OtherServiceItem.Add(temp);
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

        public bool DeleteOtherServiceItem(int OtherServiceItemID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.OtherServiceItem.FirstOrDefault(m => m.ID == OtherServiceItemID);
                if (temp != null)
                {
                    ctx.OtherServiceItem.Remove(temp);
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

        public bool UpdateOtherServiceItem(CommContracts.OtherServiceItem OtherServiceItem)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.OtherServiceItem.FirstOrDefault(m => m.ID == OtherServiceItem.ID);
                if (temp != null)
                {
                    temp.Name = OtherServiceItem.Name;
                    temp.AbbrPY = OtherServiceItem.AbbrPY;
                    temp.AbbrWB = OtherServiceItem.AbbrWB;
                    temp.Unit = OtherServiceItem.Unit;

                    temp.Price = OtherServiceItem.Price;
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
