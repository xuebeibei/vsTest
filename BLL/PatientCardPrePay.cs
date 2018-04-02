using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PatientCardPrePay
    {
        public CommContracts.PatientCardPrePay GetPrePay(int Id)
        {
            CommContracts.PatientCardPrePay prePay = new CommContracts.PatientCardPrePay();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.PatientCardPrePays
                            where t.ID == Id
                            select t;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.PatientCardPrePay, CommContracts.PatientCardPrePay>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    prePay = mapper.Map<CommContracts.PatientCardPrePay>(tem);
                    break;
                }
            }
            return prePay;
        }

        public bool SavePrePay(CommContracts.PatientCardPrePay prePay)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.PatientCardPrePay, DAL.PatientCardPrePay>();
                });
                var mapper = config.CreateMapper();

                DAL.PatientCardPrePay temp = new DAL.PatientCardPrePay();
                temp = mapper.Map<DAL.PatientCardPrePay>(prePay);
                
                ctx.PatientCardPrePays.Add(temp);
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

        public List<CommContracts.PatientCardPrePay> GetAllPrePay(int PatientID)
        {
            List<CommContracts.PatientCardPrePay> list = new List<CommContracts.PatientCardPrePay>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.PatientCardPrePays
                            where a.PatientID == PatientID 
                            orderby a.CurrentTime descending 
                            select a;
                foreach (DAL.PatientCardPrePay ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.PatientCardPrePay, CommContracts.PatientCardPrePay>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.PatientCardPrePay temp = mapper.Map<CommContracts.PatientCardPrePay>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool DeletePrePay(int PrePayID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.PatientCardPrePays.Find(PrePayID);
                if (temp == null)
                    return false;
                else
                    ctx.PatientCardPrePays.Remove(temp);
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
