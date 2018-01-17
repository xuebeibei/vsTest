using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MaterialItem
    {
        public List<CommContracts.MaterialItem> GetAllMaterial(string strName = "")
        {
            List<CommContracts.MaterialItem> list = new List<CommContracts.MaterialItem>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.MaterialItems
                            where t.Name.StartsWith(strName) ||
                            t.AbbrPY.StartsWith(strName) ||
                            t.AbbrWB.StartsWith(strName)
                            select t;

                foreach (DAL.MaterialItem ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.MaterialItem, CommContracts.MaterialItem>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.MaterialItem temp = mapper.Map<CommContracts.MaterialItem>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveMaterial(CommContracts.MaterialItem Material)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.MaterialItem, DAL.MaterialItem>();
                });
                var mapper = config.CreateMapper();

                DAL.MaterialItem temp = new DAL.MaterialItem();
                temp = mapper.Map<DAL.MaterialItem>(Material);

                ctx.MaterialItems.Add(temp);
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

        public bool DeleteMaterial(int MaterialID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.MaterialItems.FirstOrDefault(m => m.ID == MaterialID);
                if (temp != null)
                {
                    ctx.MaterialItems.Remove(temp);
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

        public bool UpdateMaterial(CommContracts.MaterialItem Material)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.MaterialItems.FirstOrDefault(m => m.ID == Material.ID);
                if (temp != null)
                {
                    temp.Name = Material.Name;
                    temp.AbbrPY = Material.AbbrPY;
                    temp.AbbrWB = Material.AbbrWB;
                    temp.Unit = Material.Unit;
                    temp.Specifications = Material.Specifications;
                    temp.Manufacturer = Material.Manufacturer;
                    temp.Valuable = Material.Valuable;
                    temp.YiBaoEnum = (DAL.YiBaoEnum)Material.YiBaoEnum;
                    temp.MaxNum = Material.MaxNum;
                    temp.MinNum = Material.MinNum;

                    temp.SellPrice = Material.SellPrice;
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
