using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MaterialBill
    {
        public CommContracts.MaterialBill GetMaterialBill(int Id)
        {
            CommContracts.MaterialBill materialBill = new CommContracts.MaterialBill();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.MaterialBills
                            where t.ID == Id
                            select t;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.MaterialBill, CommContracts.MaterialBill>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    materialBill = mapper.Map<CommContracts.MaterialBill>(tem);
                    break;
                }
            }
            return materialBill;
        }

        public bool SaveMaterialBill(CommContracts.MaterialBill materialBill)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.MaterialBill, DAL.MaterialBill>().ForMember(x => x.MaterialBillDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.MaterialBill temp = new DAL.MaterialBill();
                temp = mapper.Map<DAL.MaterialBill>(materialBill);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.MaterialBillDetail, DAL.MaterialBillDetail>().ForMember(x => x.MaterialBill, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.MaterialBillDetail> list1 = materialBill.MaterialBillDetails;
                List<DAL.MaterialBillDetail> res = mapperDetail.Map<List<DAL.MaterialBillDetail>>(list1); ;

                temp.MaterialBillDetails = res;
                ctx.MaterialBills.Add(temp);
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

        public List<CommContracts.MaterialBill> getAllMaterialBill(int RegistrationID)
        {
            List<CommContracts.MaterialBill> list = new List<CommContracts.MaterialBill>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.MaterialBills
                            where a.RegistrationID == RegistrationID
                            select a;
                foreach (DAL.MaterialBill ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.MaterialBill, CommContracts.MaterialBill>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.MaterialBill temp = mapper.Map<CommContracts.MaterialBill>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.MaterialBill> getAllInHospitalMaterialBill(int InpatientID)
        {
            List<CommContracts.MaterialBill> list = new List<CommContracts.MaterialBill>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.MaterialBills
                            where a.InpatientID == InpatientID
                            select a;
                foreach (DAL.MaterialBill ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.MaterialBill, CommContracts.MaterialBill>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.MaterialBill temp = mapper.Map<CommContracts.MaterialBill>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
