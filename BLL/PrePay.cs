using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PrePay
    {
        public CommContracts.PrePay GetPrePay(int Id)
        {
            CommContracts.PrePay prePay = new CommContracts.PrePay();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.PrePays
                            where t.ID == Id
                            select t;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.PrePay, CommContracts.PrePay>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    prePay = mapper.Map<CommContracts.PrePay>(tem);
                    break;
                }
            }
            return prePay;
        }

        public bool SavePrePay(CommContracts.PrePay prePay)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.PrePay, DAL.PrePay>();
                });
                var mapper = config.CreateMapper();

                DAL.PrePay temp = new DAL.PrePay();
                temp = mapper.Map<DAL.PrePay>(prePay);
                
                ctx.PrePays.Add(temp);
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

        public List<CommContracts.PrePay> GetAllPrePay(int PatientID)
        {
            List<CommContracts.PrePay> list = new List<CommContracts.PrePay>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.PrePays
                            where a.PatientID == PatientID 
                            orderby a.PrePayTime descending 
                            select a;
                foreach (DAL.PrePay ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.PrePay, CommContracts.PrePay>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.PrePay temp = mapper.Map<CommContracts.PrePay>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool DeletePrePay(int PrePayID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.PrePays.Find(PrePayID);
                if (temp == null)
                    return false;
                else
                    ctx.PrePays.Remove(temp);
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
