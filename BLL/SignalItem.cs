using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SignalItem
    {
        public List<CommContracts.SignalItem> GetAllSignalItem(string strName = "")
        {
            List<CommContracts.SignalItem> list = new List<CommContracts.SignalItem>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.SignalItems
                            where a.Name.StartsWith(strName)
                            select a;
                foreach (DAL.SignalItem ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.SignalItem, CommContracts.SignalItem>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.SignalItem temp = mapper.Map<CommContracts.SignalItem>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveSignalItem(CommContracts.SignalItem signalItem)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.SignalItem, DAL.SignalItem>();
                });
                var mapper = config.CreateMapper();

                DAL.SignalItem temp = new DAL.SignalItem();
                temp = mapper.Map<DAL.SignalItem>(signalItem);

                ctx.SignalItems.Add(temp);
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

        public bool DeleteSignalItem(int signalItemID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.SignalItems.FirstOrDefault(m => m.ID == signalItemID);
                if (temp != null)
                {
                    ctx.SignalItems.Remove(temp);
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

        public bool UpdateSignalItem(CommContracts.SignalItem signalItem)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.SignalItems.FirstOrDefault(m => m.ID == signalItem.ID);
                if (temp != null)
                {
                    temp.Name = signalItem.Name;
                    temp.DoctorJob = signalItem.DoctorJob;
                    temp.SellPrice = signalItem.SellPrice;
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
