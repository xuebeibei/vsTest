﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LeaveHospital
    {
        public List<CommContracts.LeaveHospital> GetAllLeaveHospitalList(int EmployeeID = 0, string strName = "")
        {
            List<CommContracts.LeaveHospital> list = new List<CommContracts.LeaveHospital>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.LeaveHospitals
                            from b in a.InHospital.InHospitalPatientDoctors
                            where a.InHospital.Patient.Name.StartsWith(strName) &&
                            (EmployeeID == 0 || (b.EndTime == null && b.DoctorID == EmployeeID)) && 
                            a.InHospital.InHospitalStatusEnum == DAL.InHospitalStatusEnum.已出院 
                            select a;

                var config1 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.InHospital, CommContracts.InHospital>().ForMember(x => x.LeaveHospitals, opt => opt.Ignore());
                });
                var mapper1 = config1.CreateMapper();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.LeaveHospital, CommContracts.LeaveHospital>().ForMember(x => x.InHospital, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                foreach (DAL.LeaveHospital ass in query)
                {
                    CommContracts.InHospital tempInhospital = mapper1.Map<CommContracts.InHospital>(ass.InHospital);

                    CommContracts.LeaveHospital temp = mapper.Map<CommContracts.LeaveHospital>(ass);
                    temp.InHospital = tempInhospital;
                    list.Add(temp);
                }
            }
            return list;
        }

        public bool SaveLeaveHospital(CommContracts.LeaveHospital LeaveHospital)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config2 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.RecallHospital, DAL.RecallHospital>().
                    ForMember(x => x.LeaveHospital, opt => opt.Ignore()).
                    ForMember(x => x.User, opt => opt.Ignore());
                });
                var mapper2 = config2.CreateMapper();

                List<DAL.RecallHospital> patientDoctors = new List<DAL.RecallHospital>();
                patientDoctors = mapper2.Map<List<DAL.RecallHospital>>(LeaveHospital.RecallHospitals);


                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.LeaveHospital, DAL.LeaveHospital>().
                    ForMember(x => x.RecallHospitals, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();


                DAL.LeaveHospital temp = new DAL.LeaveHospital();
                temp = mapper.Map<DAL.LeaveHospital>(LeaveHospital);
                temp.RecallHospitals = patientDoctors;

                ctx.LeaveHospitals.Add(temp);
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

        public bool UpdateLeaveHospital(CommContracts.LeaveHospital LeaveHospital)
        {
            if (LeaveHospital == null)
                return false;
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                DAL.LeaveHospital temp = new DAL.LeaveHospital();
                temp = ctx.LeaveHospitals.Find(LeaveHospital.ID);
                if (temp == null)
                    return false;

                temp.Diagnosis = LeaveHospital.Diagnosis;
                temp.InHospitalID = LeaveHospital.InHospitalID;
                temp.LeaveTime = LeaveHospital.LeaveTime;
                temp.UserID = LeaveHospital.UserID;
                temp.CurrentTime = LeaveHospital.CurrentTime;

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
