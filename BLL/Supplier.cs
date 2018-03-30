using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Supplier
    {

        public List<CommContracts.Supplier> GetAllSuppliers(string strFindName)
        {
            List<CommContracts.Supplier> list = new List<CommContracts.Supplier>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.Suppliers
                            where a.Name.StartsWith(strFindName) ||
                            a.Abbr1.StartsWith(strFindName) ||
                            a.Abbr2.StartsWith(strFindName) ||
                            a.Abbr3.StartsWith(strFindName) 
                            select a;
                foreach (DAL.Supplier ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Supplier, CommContracts.Supplier>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Supplier temp = mapper.Map<CommContracts.Supplier>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveSupplier(CommContracts.Supplier supplier)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Supplier, DAL.Supplier>();
                });
                var mapper = config.CreateMapper();

                DAL.Supplier temp = new DAL.Supplier();
                temp = mapper.Map<DAL.Supplier>(supplier);

                ctx.Suppliers.Add(temp);
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

        public bool DeleteSupplier(int supplierID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Suppliers.FirstOrDefault(m => m.ID == supplierID);
                if (temp != null)
                {
                    ctx.Suppliers.Remove(temp);
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

        public bool UpdateSupplier(CommContracts.Supplier supplier)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Suppliers.FirstOrDefault(m => m.ID == supplier.ID);
                if (temp != null)
                {
                    temp.Name = supplier.Name;
                    temp.Contents = supplier.Contents;
                    temp.Tel = supplier.Tel;
                    temp.Address = supplier.Address;
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
