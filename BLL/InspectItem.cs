using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InspectItem
    {
        public List<CommContracts.InspectItem> GetAllInspectItem(string strName = "")
        {
            List<CommContracts.InspectItem> list = new List<CommContracts.InspectItem>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.InspectItems
                            where t.Name.StartsWith(strName) ||
                            t.AbbrPY.StartsWith(strName) ||
                            t.AbbrWB.StartsWith(strName)
                            select t;

                foreach (DAL.InspectItem ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.InspectItem, CommContracts.InspectItem>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.InspectItem temp = mapper.Map<CommContracts.InspectItem>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveInspectItem(CommContracts.InspectItem inspectItem)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.InspectItem, DAL.InspectItem>();
                });
                var mapper = config.CreateMapper();

                DAL.InspectItem temp = new DAL.InspectItem();
                temp = mapper.Map<DAL.InspectItem>(inspectItem);

                ctx.InspectItems.Add(temp);
                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        public bool DeleteInspectItem(int MaterialID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.InspectItems.FirstOrDefault(m => m.ID == MaterialID);
                if (temp != null)
                {
                    ctx.InspectItems.Remove(temp);
                }

                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        public bool UpdateInspectItem(CommContracts.InspectItem inspectItem)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.InspectItems.FirstOrDefault(m => m.ID == inspectItem.ID);
                if (temp != null)
                {
                    temp.Name = inspectItem.Name;
                    temp.AbbrPY = inspectItem.AbbrPY;
                    temp.AbbrWB = inspectItem.AbbrWB;
                    temp.Unit = inspectItem.Unit;
                    //temp.YiBaoEnum = (DAL.YiBaoEnum)inspectItem.YiBaoEnum;

                    temp.Price = inspectItem.Price;
                }
                else
                {
                    return false;
                }

                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
