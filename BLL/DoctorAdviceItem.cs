using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DoctorAdviceItem
    {
        public List<CommContracts.DoctorAdviceItem> GetAllDoctorAdviceItem(string strName)
        {
            List<CommContracts.DoctorAdviceItem> list = new List<CommContracts.DoctorAdviceItem>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.DoctorAdviceItems
                            where t.Name.StartsWith(strName) ||
                            t.Abbr.StartsWith(strName) ||
                            t.WuBi.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.DoctorAdviceItem, CommContracts.DoctorAdviceItem>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.DoctorAdviceItem tem in query)
                {
                    var dto = mapper.Map<CommContracts.DoctorAdviceItem>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveDoctorAdviceItem(CommContracts.DoctorAdviceItem DoctorAdviceItem)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.DoctorAdviceItem, DAL.DoctorAdviceItem>();
                });
                var mapper = config.CreateMapper();

                DAL.DoctorAdviceItem temp = new DAL.DoctorAdviceItem();
                temp = mapper.Map<DAL.DoctorAdviceItem>(DoctorAdviceItem);

                ctx.DoctorAdviceItems.Add(temp);
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

        public bool DeleteDoctorAdviceItem(int DoctorAdviceItemID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.DoctorAdviceItems.FirstOrDefault(m => m.ID == DoctorAdviceItemID);
                if (temp != null)
                {
                    ctx.DoctorAdviceItems.Remove(temp);
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

        public bool UpdateDoctorAdviceItem(CommContracts.DoctorAdviceItem DoctorAdviceItem)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.DoctorAdviceItems.FirstOrDefault(m => m.ID == DoctorAdviceItem.ID);
                if (temp != null)
                {
                    temp.Name = DoctorAdviceItem.Name;
                    temp.Specification = DoctorAdviceItem.Specification;
                    temp.Abbr = DoctorAdviceItem.Abbr;
                    temp.WuBi = DoctorAdviceItem.WuBi;
                    temp.doctorAdviceItemType = (DAL.DoctorAdviceItemType)DoctorAdviceItem.doctorAdviceItemType;

                    temp.SellPackageName = DoctorAdviceItem.SellPackageName;

                    temp.MinPackageName = DoctorAdviceItem.MinPackageName;
                    temp.MinPackageNum = DoctorAdviceItem.MinPackageNum;
                    temp.MinPackageUnit = DoctorAdviceItem.MinPackageUnit;
                    temp.ScalingFactor = DoctorAdviceItem.ScalingFactor;
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
