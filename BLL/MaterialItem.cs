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
        public List<CommContracts.MaterialItem> GetAllMaterialItem(string strName = "")
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

        public bool SaveMaterialItem(CommContracts.MaterialItem MaterialItem)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.MaterialItem, DAL.MaterialItem>();
                });
                var mapper = config.CreateMapper();

                DAL.MaterialItem temp = new DAL.MaterialItem();
                temp = mapper.Map<DAL.MaterialItem>(MaterialItem);

                ctx.MaterialItems.Add(temp);
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

        public bool DeleteMaterialItem(int MaterialID)
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
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    return false;
                }
            }
            return true;
        }

        public bool UpdateMaterialItem(CommContracts.MaterialItem MaterialItem)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.MaterialItems.FirstOrDefault(m => m.ID == MaterialItem.ID);
                if (temp != null)
                {
                    temp.Name = MaterialItem.Name;
                    temp.AbbrPY = MaterialItem.AbbrPY;
                    temp.AbbrWB = MaterialItem.AbbrWB;
                    temp.Unit = MaterialItem.Unit;
                    temp.Specifications = MaterialItem.Specifications;
                    temp.Manufacturer = MaterialItem.Manufacturer;
                    temp.Valuable = MaterialItem.Valuable;
                    temp.YiBaoEnum = (DAL.YiBaoEnum)MaterialItem.YiBaoEnum;
                    temp.MaxNum = MaterialItem.MaxNum;
                    temp.MinNum = MaterialItem.MinNum;

                    temp.SellPrice = MaterialItem.SellPrice;
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
