using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AssayDoctorAdvice
    {
        public CommContracts.AssayDoctorAdvice GetAssayDoctorAdvice(int Id)
        {
            CommContracts.AssayDoctorAdvice AssayDoctorAdvice = new CommContracts.AssayDoctorAdvice();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.AssayDoctorAdvices
                            where t.ID == Id
                            select t;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.AssayDoctorAdvice, CommContracts.AssayDoctorAdvice>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    AssayDoctorAdvice = mapper.Map<CommContracts.AssayDoctorAdvice>(tem);
                    break;
                }
            }
            return AssayDoctorAdvice;
        }

        public bool SaveAssayDoctorAdvice(CommContracts.AssayDoctorAdvice AssayDoctorAdvice)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.AssayDoctorAdvice, DAL.AssayDoctorAdvice>().ForMember(x => x.AssayDoctorAdviceDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.AssayDoctorAdvice temp = new DAL.AssayDoctorAdvice();
                temp = mapper.Map<DAL.AssayDoctorAdvice>(AssayDoctorAdvice);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.AssayDoctorAdviceDetail, DAL.AssayDoctorAdviceDetail>().ForMember(x => x.AssayDoctorAdvice, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.AssayDoctorAdviceDetail> list1 = AssayDoctorAdvice.AssayDoctorAdviceDetails;
                List<DAL.AssayDoctorAdviceDetail> res = mapperDetail.Map<List<DAL.AssayDoctorAdviceDetail>>(list1); ;

                temp.AssayDoctorAdviceDetails = res;
                ctx.AssayDoctorAdvices.Add(temp);
                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                }
            }
            return true;
        }

        public List<CommContracts.AssayDoctorAdvice> getAllAssayDoctorAdvice(int RegistrationID)
        {
            List<CommContracts.AssayDoctorAdvice> list = new List<CommContracts.AssayDoctorAdvice>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.AssayDoctorAdvices
                            where a.RegistrationID == RegistrationID
                            select a;
                foreach (DAL.AssayDoctorAdvice ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.AssayDoctorAdvice, CommContracts.AssayDoctorAdvice>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.AssayDoctorAdvice temp = mapper.Map<CommContracts.AssayDoctorAdvice>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.AssayDoctorAdvice> getAllInHospitalAssayDoctorAdvice(int InpatientID)
        {
            List<CommContracts.AssayDoctorAdvice> list = new List<CommContracts.AssayDoctorAdvice>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.AssayDoctorAdvices
                            where a.InpatientID == InpatientID
                            select a;
                foreach (DAL.AssayDoctorAdvice ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.AssayDoctorAdvice, CommContracts.AssayDoctorAdvice>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.AssayDoctorAdvice temp = mapper.Map<CommContracts.AssayDoctorAdvice>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
// automapper测试


// 1  简单实体的映射

//DAL.MaterialItem dto = new DAL.MaterialItem
//{
//    ID = 1
//};

//Mapper.Initialize(m => m.CreateMap<DAL.MaterialItem, CommContracts.MaterialItem>());

//CommContracts.MaterialItem materialItem = Mapper.Map<DAL.MaterialItem, CommContracts.MaterialItem>(dto);

// 2  不同名称属性的映射,将ID映射到Name中去
//DAL.MaterialItem dto = new DAL.MaterialItem

//{

//    ID = 1,
//    Name = "dt"
//};

//Mapper.Initialize(m => m.CreateMap<DAL.MaterialItem, CommContracts.MaterialItem>().ForMember(x => x.Name, opt => opt.MapFrom(o => o.ID)));

//CommContracts.MaterialItem address = Mapper.Map<DAL.MaterialItem, CommContracts.MaterialItem>(dto);

// 3  集合转换
//DAL.MaterialItem address = new DAL.MaterialItem {
//    ID = 1,
//    Name = "dt"
//};

//DAL.MaterialItem address2 = new DAL.MaterialItem()
//{
//    ID = 2,
//    Name = "dt1"
//};

//List<DAL.MaterialItem> addressList = new List<DAL.MaterialItem>() { address2, address };

//Mapper.Initialize(m => m.CreateMap<DAL.MaterialItem, CommContracts.MaterialItem>());//这里仅需配置实体间的转换，而不是实体集合的转换

//List<CommContracts.MaterialItem> res = Mapper.Map<List<DAL.MaterialItem>, List<CommContracts.MaterialItem>>(addressList);

//}

// 4  忽略映射

//DAL.MaterialItem author = new DAL.MaterialItem() {
//    ID = 1,
//    Name = "dt"
//};

//Mapper.Initialize(m => { m.CreateMap<DAL.MaterialItem, CommContracts.MaterialItem>().ForMember(x => x.Name, opt => opt.Ignore()); });

//CommContracts.MaterialItem dto = Mapper.Map<DAL.MaterialItem, CommContracts.MaterialItem>(author);


////这里的Ignore代表配置ContractInfo该属性的操作  为 忽略Ignore,映射时将忽略该属性   由于List<TContactInfo>()和List<VM_ContactInfo>() 是不同类型，所以需要配置忽略或者是特殊映射，特殊映射例子看下方

// 5  实体包含不同类型属性转换