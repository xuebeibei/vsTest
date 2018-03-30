using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SickBed
    {
        public List<CommContracts.SickBed> GetAllSickBed(string strName = "")
        {
            List<CommContracts.SickBed> list = new List<CommContracts.SickBed>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.SickBeds
                            where a.Name.StartsWith(strName)
                            select a;
                foreach (DAL.SickBed ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.SickBed, CommContracts.SickBed>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.SickBed temp = mapper.Map<CommContracts.SickBed>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveSickBed(CommContracts.SickBed sickBed)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.SickBed, DAL.SickBed>();
                });
                var mapper = config.CreateMapper();

                DAL.SickBed temp = new DAL.SickBed();
                temp = mapper.Map<DAL.SickBed>(sickBed);

                ctx.SickBeds.Add(temp);
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

        public bool DeleteSickBed(int sickBedID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.SickBeds.FirstOrDefault(m => m.ID == sickBedID);
                if (temp != null)
                {
                    ctx.SickBeds.Remove(temp);
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

        public bool UpdateSickBed(CommContracts.SickBed sickBed)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.SickBeds.FirstOrDefault(m => m.ID == sickBed.ID);
                if (temp != null)
                {
                    temp.Name = sickBed.Name;
                    temp.Price = sickBed.Price;
                    temp.Unit = sickBed.Unit;
                    temp.SickRoomID = sickBed.SickRoomID;
                    temp.Remarks = sickBed.Remarks;
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
