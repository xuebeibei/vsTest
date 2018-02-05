using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RecallHospital
    {
        public List<CommContracts.RecallHospital> GetAllRecallHospitalList(int EmployeeID = 0, string strName = "")
        {
            List<CommContracts.RecallHospital> list = new List<CommContracts.RecallHospital>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.RecallHospitals
                            from b in a.LeaveHospital.InHospital.InHospitalPatientDoctors
                            where a.LeaveHospital.InHospital.Patient.Name.StartsWith(strName) &&
                            (EmployeeID == 0 || (b.EndTime == null && b.DoctorID == EmployeeID))
                            select a;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.RecallHospital, CommContracts.RecallHospital>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.RecallHospital ass in query)
                {

                    CommContracts.RecallHospital temp = mapper.Map<CommContracts.RecallHospital>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveRecallHospital(CommContracts.RecallHospital RecallHospital)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config2 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.RecallHospital, DAL.RecallHospital>().
                    ForMember(x => x.User, opt => opt.Ignore());
                });
                var mapper2 = config2.CreateMapper();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.RecallHospital, DAL.RecallHospital>();
                });
                var mapper = config.CreateMapper();


                DAL.RecallHospital temp = new DAL.RecallHospital();
                temp = mapper.Map<DAL.RecallHospital>(RecallHospital);

                ctx.RecallHospitals.Add(temp);
                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        public bool UpdateRecallHospital(CommContracts.RecallHospital RecallHospital)
        {
            if (RecallHospital == null)
                return false;
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                DAL.RecallHospital temp = new DAL.RecallHospital();
                temp = ctx.RecallHospitals.Find(RecallHospital.ID);
                if (temp == null)
                    return false;

                temp.Reason = RecallHospital.Reason;
                temp.LeaveHospitalID = RecallHospital.LeaveHospitalID;
                temp.RecallTime = RecallHospital.RecallTime;
                temp.UserID = RecallHospital.UserID;
                temp.CurrentTime = RecallHospital.CurrentTime;

                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
