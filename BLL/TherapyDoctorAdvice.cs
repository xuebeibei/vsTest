using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.Entity;
using System.Data;
using System.Globalization;
using System.Collections;
using AutoMapper;

namespace BLL
{
    public class TherapyDoctorAdvice
    {
        public CommContracts.TherapyDoctorAdvice GetTherapy(int Id)
        {
            CommContracts.TherapyDoctorAdvice therapy = new CommContracts.TherapyDoctorAdvice();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.TherapyDoctorAdvices
                            where t.ID == Id
                            select t;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.TherapyDoctorAdvice, CommContracts.TherapyDoctorAdvice>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    therapy = mapper.Map<CommContracts.TherapyDoctorAdvice>(tem);
                    break;
                }
            }
            return therapy;
        }

        public bool SaveTherapy(CommContracts.TherapyDoctorAdvice therapy)
        {
            DAL.TherapyDoctorAdvice temp = new DAL.TherapyDoctorAdvice();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.TherapyDoctorAdvice, DAL.TherapyDoctorAdvice>().ForMember(x => x.TherapyDoctorAdviceDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                temp = mapper.Map<DAL.TherapyDoctorAdvice>(therapy);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.TherapyDoctorAdviceDetail, DAL.TherapyDoctorAdviceDetail>().ForMember(x => x.Therapy, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.TherapyDoctorAdviceDetail> list1 = therapy.TherapyDoctorAdviceDetails;
                List<DAL.TherapyDoctorAdviceDetail> res = mapperDetail.Map<List<DAL.TherapyDoctorAdviceDetail>>(therapy.TherapyDoctorAdviceDetails); ;

                temp.TherapyDoctorAdviceDetails = res;
                ctx.TherapyDoctorAdvices.Add(temp);

                try
                {
                    ctx.SaveChanges();
                }
                catch(Exception ex)
                {
                    return false;
                }
                
            }
            return true;
        }

        public List<CommContracts.TherapyDoctorAdvice> getAllTherapy(int RegistrationID)
        {
            List<CommContracts.TherapyDoctorAdvice> list = new List<CommContracts.TherapyDoctorAdvice>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.TherapyDoctorAdvices
                            where t.RegistrationID == RegistrationID
                            select t;
                foreach (DAL.TherapyDoctorAdvice th in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.TherapyDoctorAdvice, CommContracts.TherapyDoctorAdvice>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.TherapyDoctorAdvice temp = mapper.Map<CommContracts.TherapyDoctorAdvice>(th);
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.TherapyDoctorAdvice> getAllInHospitalTherapyDoctorAdvice(int InpatientID)
        {
            List<CommContracts.TherapyDoctorAdvice> list = new List<CommContracts.TherapyDoctorAdvice>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.TherapyDoctorAdvices
                            where t.InpatientID == InpatientID
                            select t;
                foreach (DAL.TherapyDoctorAdvice th in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.TherapyDoctorAdvice, CommContracts.TherapyDoctorAdvice>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.TherapyDoctorAdvice temp = mapper.Map<CommContracts.TherapyDoctorAdvice>(th);
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
