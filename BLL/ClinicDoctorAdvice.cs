using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClinicDoctorAdvice
    {
        public List<CommContracts.ClinicDoctorAdvice> GetAllClinicDoctorAdvice(string strName)
        {
            List<CommContracts.ClinicDoctorAdvice> list = new List<CommContracts.ClinicDoctorAdvice>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.ClinicDoctorAdvices
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.ClinicDoctorAdvice, CommContracts.ClinicDoctorAdvice>().ForMember(x=>x.ClinicDoctorAdvice_DiagnoseItems, opt=>opt.Ignore());
                });
                var mapper = config.CreateMapper();




                var configDiagnoseItems = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.ClinicDoctorAdvice_DiagnoseItem, CommContracts.ClinicDoctorAdvice_DiagnoseItem>().ForMember(x => x.ClinicDoctorAdvice, opt => opt.Ignore());
                });
                var mapperDiagnoseItems = configDiagnoseItems.CreateMapper();


                foreach (DAL.ClinicDoctorAdvice tem in query)
                {
                    var dto = mapper.Map<CommContracts.ClinicDoctorAdvice>(tem);

                    List<CommContracts.ClinicDoctorAdvice_DiagnoseItem> reslinicDoctorAdvice_DiagnoseItems = new List<CommContracts.ClinicDoctorAdvice_DiagnoseItem>();
                    reslinicDoctorAdvice_DiagnoseItems = mapperDiagnoseItems.Map<List<CommContracts.ClinicDoctorAdvice_DiagnoseItem>>(tem.ClinicDoctorAdvice_DiagnoseItems);
                    dto.ClinicDoctorAdvice_DiagnoseItems = reslinicDoctorAdvice_DiagnoseItems;


                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveClinicDoctorAdvice(CommContracts.ClinicDoctorAdvice ClinicDoctorAdvice)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.ClinicDoctorAdvice, DAL.ClinicDoctorAdvice>()/*.ForMember(x => x.ClinicDoctorAdvice_DiagnoseItems, opt => opt.Ignore())*/
                    /*.ForMember(x => x.DoctorAdviceDetailGroups, opt => opt.Ignore())*/;
                });
                var mapper = config.CreateMapper();

                DAL.ClinicDoctorAdvice temp = new DAL.ClinicDoctorAdvice();
                temp = mapper.Map<DAL.ClinicDoctorAdvice>(ClinicDoctorAdvice);


                //var configDetail = new MapperConfiguration(ctr =>
                //{
                //    ctr.CreateMap<CommContracts.ClinicDoctorAdvice_DiagnoseItem, DAL.ClinicDoctorAdvice_DiagnoseItem>().ForMember(x => x.ClinicDoctorAdvice, opt => opt.Ignore());
                //});
                //var mapperDetail = configDetail.CreateMapper();

                //List<CommContracts.ClinicDoctorAdvice_DiagnoseItem> list1 = ClinicDoctorAdvice.ClinicDoctorAdvice_DiagnoseItems;
                //List<DAL.ClinicDoctorAdvice_DiagnoseItem> res = mapperDetail.Map<List<DAL.ClinicDoctorAdvice_DiagnoseItem>>(list1);

                //temp.ClinicDoctorAdvice_DiagnoseItems = res;

                //List<DAL.DoctorAdviceDetailGroup> resGroup = new List<DAL.DoctorAdviceDetailGroup>();
                //foreach (var temGroupDetail in ClinicDoctorAdvice.DoctorAdviceDetailGroups)
                //{
                //    var configGroupDetail = new MapperConfiguration(ctr =>
                //    {
                //        ctr.CreateMap<CommContracts.DoctorAdviceDetailGroup, DAL.DoctorAdviceDetailGroup>().ForMember(x => x.ClinicDoctorAdvice, opt => opt.Ignore())
                //        .ForMember(x => x.Usage, opt => opt.Ignore()).ForMember(x => x.DoctorAdviceItems, opt => opt.Ignore());
                //    });
                //    var mapperGroupDetail = configGroupDetail.CreateMapper();

                //    DAL.DoctorAdviceDetailGroup resGroupDetail = new DAL.DoctorAdviceDetailGroup();
                //    resGroupDetail = mapperGroupDetail.Map<DAL.DoctorAdviceDetailGroup>(temGroupDetail);


                //    ///
                //    var configItmes = new MapperConfiguration(ctr =>
                //    {
                //        ctr.CreateMap<CommContracts.DoctorAdviceDetail, DAL.DoctorAdviceDetail>()
                //        .ForMember(x=>x.DoctorAdviceDetailGroup, opt=> opt.Ignore()).ForMember(x=>x.DoctorAdviceItem, opt =>opt.Ignore());
                //    });
                //    var mapperItems = configItmes.CreateMapper();

                //    List<CommContracts.DoctorAdviceDetail> listItems = temGroupDetail.DoctorAdviceItems;
                //    List<DAL.DoctorAdviceDetail> resItems = mapperItems.Map<List<DAL.DoctorAdviceDetail>>(listItems);

                //    resGroupDetail.DoctorAdviceItems = resItems;

                //    resGroup.Add(resGroupDetail);

                //}



                //temp.DoctorAdviceDetailGroups = resGroup;

                ctx.ClinicDoctorAdvices.Add(temp);
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

        public bool DeleteClinicDoctorAdvice(int ClinicDoctorAdviceID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.ClinicDoctorAdvices.FirstOrDefault(m => m.ID == ClinicDoctorAdviceID);
                if (temp != null)
                {
                    ctx.ClinicDoctorAdvices.Remove(temp);
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

        public bool UpdateClinicDoctorAdvice(CommContracts.ClinicDoctorAdvice ClinicDoctorAdvice)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.ClinicDoctorAdvices.FirstOrDefault(m => m.ID == ClinicDoctorAdvice.ID);
                if (temp != null)
                {
                    temp.DoctorAdviceType = (DAL.DoctorAdviceItemType)ClinicDoctorAdvice.DoctorAdviceType;
                    temp.StartTime = ClinicDoctorAdvice.StartTime;
                    temp.DoctorName = ClinicDoctorAdvice.DoctorName;
                    temp.DepartmentName = ClinicDoctorAdvice.DepartmentName;
                    temp.IsExigence = ClinicDoctorAdvice.IsExigence;
                    

                    temp.UpdateTime = ClinicDoctorAdvice.UpdateTime;
                    temp.ClinicRegistrationID = ClinicDoctorAdvice.ClinicRegistrationID;
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
