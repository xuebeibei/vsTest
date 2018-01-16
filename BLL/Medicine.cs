using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Medicine
    {
        //public List<CommContracts.Medicine> getAllMedicine()
        //{
        //    List<CommContracts.Medicine> list = new List<CommContracts.Medicine>();
        //    using (DAL.HisContext ctx = new DAL.HisContext())
        //    {
        //        var query = from m in ctx.Medicines
        //                    select m;
        //        var config = new MapperConfiguration(cfg =>
        //        {
        //            cfg.CreateMap<DAL.Medicine, CommContracts.Medicine>();
        //        });
        //        var mapper = config.CreateMapper();

        //        foreach (DAL.Medicine tem in query)
        //        {
        //            var dto = mapper.Map<CommContracts.Medicine>(tem);
        //            list.Add(dto);
        //        }
        //    }
        //    return list;
        //}

        public CommContracts.Medicine GetMedicine(int id)
        {
            CommContracts.Medicine medicine = new CommContracts.Medicine();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from m in ctx.Medicines
                            where m.ID == id 
                            select m;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Medicine, CommContracts.Medicine>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.Medicine tem in query)
                {
                    medicine = mapper.Map<CommContracts.Medicine>(tem);
                    break;
                }
            }

            return medicine;
        }

        public List<CommContracts.Medicine> GetAllMedicine(string strName = "")
        {
            List<CommContracts.Medicine> list = new List<CommContracts.Medicine>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.Medicines
                            where a.Name.StartsWith(strName)
                            select a;
                foreach (DAL.Medicine ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Medicine, CommContracts.Medicine>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Medicine temp = mapper.Map<CommContracts.Medicine>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveMedicine(CommContracts.Medicine Medicine)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Medicine, DAL.Medicine>();
                });
                var mapper = config.CreateMapper();

                DAL.Medicine temp = new DAL.Medicine();
                temp = mapper.Map<DAL.Medicine>(Medicine);

                ctx.Medicines.Add(temp);
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

        public bool DeleteMedicine(int MedicineID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Medicines.FirstOrDefault(m => m.ID == MedicineID);
                if (temp != null)
                {
                    ctx.Medicines.Remove(temp);
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

        public bool UpdateMedicine(CommContracts.Medicine Medicine)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Medicines.FirstOrDefault(m => m.ID == Medicine.ID);
                if (temp != null)
                {
                    temp.MedicineTypeEnum = (DAL.MedicineTypeEnum)Medicine.MedicineTypeEnum;
                    temp.Name = Medicine.Name;
                    temp.Abbr1 = Medicine.Abbr1;
                    temp.Abbr2 = Medicine.Abbr2;
                    temp.Abbr3 = Medicine.Abbr3;
                    temp.DosageFormEnum = (DAL.DosageFormEnum)Medicine.DosageFormEnum;
                    temp.Unit = Medicine.Unit;
                    temp.AdministrationRoute = Medicine.AdministrationRoute;
                    temp.Specifications = Medicine.Specifications;
                    temp.Manufacturer = Medicine.Manufacturer;
                    temp.PoisonousHemp = Medicine.PoisonousHemp;
                    temp.Valuable = Medicine.Valuable;
                    temp.EssentialDrugs = Medicine.EssentialDrugs;
                    temp.YiBaoEnum = (DAL.YiBaoEnum)Medicine.YiBaoEnum;
                    temp.MaxNum = Medicine.MaxNum;
                    temp.MinNum = Medicine.MinNum;

                    temp.SellPrice = Medicine.SellPrice;
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
