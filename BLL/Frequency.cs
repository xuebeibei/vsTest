using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Frequency
    {
        public List<CommContracts.Frequency> GetAllFrequency(string strName)
        {
            List<CommContracts.Frequency> list = new List<CommContracts.Frequency>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.Frequencys
                            where t.Name.StartsWith(strName) ||
                            t.Abbr.StartsWith(strName) ||
                            t.WuBi.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Frequency, CommContracts.Frequency>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.Frequency tem in query)
                {
                    var dto = mapper.Map<CommContracts.Frequency>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveFrequency(CommContracts.Frequency Frequency)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Frequency, DAL.Frequency>();
                });
                var mapper = config.CreateMapper();

                DAL.Frequency temp = new DAL.Frequency();
                temp = mapper.Map<DAL.Frequency>(Frequency);

                ctx.Frequencys.Add(temp);
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

        public bool DeleteFrequency(int FrequencyID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Frequencys.FirstOrDefault(m => m.ID == FrequencyID);
                if (temp != null)
                {
                    ctx.Frequencys.Remove(temp);
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

        public bool UpdateFrequency(CommContracts.Frequency Frequency)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Frequencys.FirstOrDefault(m => m.ID == Frequency.ID);
                if (temp != null)
                {
                    temp.Name = Frequency.Name;
                    temp.Abbr = Frequency.Abbr;
                    temp.WuBi = Frequency.WuBi;
                    temp.CoefficientNum = Frequency.CoefficientNum;
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
