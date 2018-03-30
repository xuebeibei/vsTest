using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedicineCharge
    {
        public bool SaveMedicineCharge(CommContracts.MedicineCharge medicineCharge)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.MedicineCharge, DAL.MedicineCharge>().ForMember(x => x.MedicineChargeDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.MedicineCharge temp = new DAL.MedicineCharge();
                temp = mapper.Map<DAL.MedicineCharge>(medicineCharge);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.MedicineChargeDetail, DAL.MedicineChargeDetail>().ForMember(x => x.MedicineCharge, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.MedicineChargeDetail> list1 = medicineCharge.MedicineChargeDetails;
                List<DAL.MedicineChargeDetail> res = mapperDetail.Map<List<DAL.MedicineChargeDetail>>(list1); ;

                temp.MedicineChargeDetails = res;
                ctx.MedicineCharges.Add(temp);
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

        public List<CommContracts.MedicineCharge> GetAllChargeFromMedicineAdvice(int AdviceID)
        {
            List<CommContracts.MedicineCharge> list = new List<CommContracts.MedicineCharge>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.MedicineCharges
                            where a.MedicineDoctorAdviceID == AdviceID
                            select a;
                foreach (DAL.MedicineCharge ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.MedicineCharge, CommContracts.MedicineCharge>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.MedicineCharge temp = mapper.Map<CommContracts.MedicineCharge>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.MedicineCharge> GetAllClinicMedicineCharge(int RegistrationID)
        {
            List<CommContracts.MedicineCharge> list = new List<CommContracts.MedicineCharge>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from m in context.MedicineCharges
                            where m.MedicineDoctorAdvice.RegistrationID == RegistrationID
                            select m;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.MedicineCharge, CommContracts.MedicineCharge>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    var charge = mapper.Map<CommContracts.MedicineCharge>(tem);

                    list.Add(charge);
                }

            }
            return list;
        }

        public List<CommContracts.MedicineCharge> GetAllInHospitalMedicineCharge(int InpatientID)
        {
            List<CommContracts.MedicineCharge> list = new List<CommContracts.MedicineCharge>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from m in context.MedicineCharges
                            where m.MedicineDoctorAdvice.InpatientID == InpatientID
                            select m;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.MedicineCharge, CommContracts.MedicineCharge>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    var charge = mapper.Map<CommContracts.MedicineCharge>(tem);

                    list.Add(charge);
                }

            }
            return list;
        }
    }
}
