using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DoctorAdviceDetail
    {
        public List<CommContracts.DoctorAdviceDetail> GetAllDoctorAdviceDetail(string strName)
        {
            List<CommContracts.DoctorAdviceDetail> list = new List<CommContracts.DoctorAdviceDetail>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.DoctorAdviceDetails
                            where t.DoctorAdviceItem.Name.StartsWith(strName) ||
                            t.DoctorAdviceItem.Abbr.StartsWith(strName) ||
                            t.DoctorAdviceItem.WuBi.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.DoctorAdviceDetail, CommContracts.DoctorAdviceDetail>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.DoctorAdviceDetail tem in query)
                {
                    var dto = mapper.Map<CommContracts.DoctorAdviceDetail>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveDoctorAdviceDetail(CommContracts.DoctorAdviceDetail DoctorAdviceDetail)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.DoctorAdviceDetail, DAL.DoctorAdviceDetail>();
                });
                var mapper = config.CreateMapper();

                DAL.DoctorAdviceDetail temp = new DAL.DoctorAdviceDetail();
                temp = mapper.Map<DAL.DoctorAdviceDetail>(DoctorAdviceDetail);

                ctx.DoctorAdviceDetails.Add(temp);
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

        public bool DeleteDoctorAdviceDetail(int DoctorAdviceDetailID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.DoctorAdviceDetails.FirstOrDefault(m => m.ID == DoctorAdviceDetailID);
                if (temp != null)
                {
                    ctx.DoctorAdviceDetails.Remove(temp);
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

        public bool UpdateDoctorAdviceDetail(CommContracts.DoctorAdviceDetail DoctorAdviceDetail)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.DoctorAdviceDetails.FirstOrDefault(m => m.ID == DoctorAdviceDetail.ID);
                if (temp != null)
                {
                    temp.DoctorAdviceItemID = DoctorAdviceDetail.DoctorAdviceItemID;
                    temp.TotalNum = DoctorAdviceDetail.TotalNum;
                    temp.SignalDose = DoctorAdviceDetail.SignalDose;
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
