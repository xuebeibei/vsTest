using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoMapper;

namespace BLL
{
    public class Registration
    {
        CommContracts.Registration registration;

        public Registration(CommContracts.Registration registration)
        {
            this.registration = registration;
        }

        public Registration()
        {

        }

        public List<CommContracts.Registration> getAllRegistration(int EmployeeID = 0, DateTime? VistTime = null, bool HaveArrive = true)
        {
            List<CommContracts.Registration> list = new List<CommContracts.Registration>();

            //using (DAL.HisContext ctx = new DAL.HisContext())
            //{
            //    var query = from r in ctx.Registrations
            //                where
            //                (EmployeeID <= 0 || r.SignalSource.EmployeeID == EmployeeID) &&
            //                (VistTime == null || r.SignalSource.WorkPlanDate == VistTime) &&
            //                (!HaveArrive || r.ArriveTime.HasValue)
            //                select r;

            //    var config = new MapperConfiguration(cfg =>
            //    {
            //        cfg.CreateMap<DAL.Registration, CommContracts.Registration>();
            //    });
            //    var mapper = config.CreateMapper();

            //    foreach (DAL.Registration tem in query)
            //    {
            //        var dto = mapper.Map<CommContracts.Registration>(tem);
            //        list.Add(dto);
            //    }
            //}

            return list;
        }

        public List<CommContracts.Registration> GetAllClinicPatients(DateTime startDate, DateTime endDate, string strFindName = "", bool HavePay = false)
        {
            List<CommContracts.Registration> list = new List<CommContracts.Registration>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = (from r in ctx.Registrations
                            join d in ctx.DoctorAdviceBases
                            on r.ID equals d.RegistrationID 
                            select r).Distinct();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Registration, CommContracts.Registration>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.Registration tem in query)
                {
                    var dto = mapper.Map<CommContracts.Registration>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public string getPatientBMIMsg(int RegistrationID)
        {
            string strBMIMsg = "";
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = ctx.Registrations.Find(RegistrationID);
                var temp = query as DAL.Registration;
                if (temp == null)
                    return strBMIMsg;

                int PatientID = temp.PatientID;
                var patient = ctx.Patients.Find(PatientID);
                strBMIMsg = patient.ToBMIMsg();
            }

            return strBMIMsg;
        }

        public bool SaveRegistration()
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Registration, DAL.Registration>().
                    ForMember(x => x.MedicalRecords, opt => opt.Ignore()).
                    ForMember(x => x.Patient, opt => opt.Ignore()).
                    ForMember(x => x.RegisterUser, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.Registration temp = new DAL.Registration();
                temp = mapper.Map<DAL.Registration>(registration);

                ctx.Registrations.Add(temp);
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
            //return false;
        }

        public bool UpdateRegistration(CommContracts.Registration registration)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Registrations.FirstOrDefault(m => m.ID == registration.ID);
                if (temp != null)
                {
                    temp.PatientID = registration.PatientID;
                    temp.RegisterUserID = registration.RegisterUserID;
                    temp.RegisterFee = registration.RegisterFee;
                    temp.RegisterTime = registration.RegisterTime;
                    temp.SeeDoctorStatus = (DAL.SeeDoctorStatusEnum)registration.SeeDoctorStatus;
                    temp.TriageStatus = (DAL.TriageStatusEnum)registration.TriageStatus;
                    temp.PayWayEnum = (DAL.PayWayEnum)registration.PayWayEnum;
                    temp.ArriveUserID = registration.ArriveUserID;
                    temp.ArriveTime = registration.ArriveTime;
                    temp.StartSeeDoctorTime = registration.StartSeeDoctorTime;
                    temp.EndSeeDoctorTime = registration.EndSeeDoctorTime;
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

        public List<CommContracts.Registration> GetDepartmentRegistrationList(int DepartmentID, int EmployeeID, DateTime startDate, DateTime endDate)
        {
            List<CommContracts.Registration> list = new List<CommContracts.Registration>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from r in ctx.Registrations
                            join cr in ctx.CancelRegistrations
                            on r.ID equals cr.RegistrationID into rr
                            from cr in rr.DefaultIfEmpty()
                            where cr == null &&
                            (DepartmentID <= 0 || r.DepartmentID == DepartmentID) &&
                            //(EmployeeID <= 0 || r.SignalSource.EmployeeID == EmployeeID) &&
                            r.SignalDate <= endDate &&
                            r.SignalDate >= startDate
                            select r;
                foreach (DAL.Registration ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Registration, CommContracts.Registration>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Registration temp = mapper.Map<CommContracts.Registration>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        // 查找某个患者的挂号记录
        public List<CommContracts.Registration> GetPatientRegistrations(int PatientID, DateTime? DateTime = null)
        {
            List<CommContracts.Registration> list = new List<CommContracts.Registration>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.Registrations
                            where
                            a.PatientID == PatientID &&
                            (!DateTime.HasValue || a.SignalDate <= DateTime)
                            orderby a.RegisterTime descending
                            select a;
                foreach (DAL.Registration ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Registration, CommContracts.Registration>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Registration temp = mapper.Map<CommContracts.Registration>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public CommContracts.Registration CallNextRegistration(int nDepartmentID, DateTime dateTime)
        {
            DateTime date = dateTime.Date;
            DateTime endDate = date.AddDays(1);

            CommContracts.Registration returnTemp = new CommContracts.Registration();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.Registrations
                            where
                            a.DepartmentID == nDepartmentID &&
                            a.TriageStatus == DAL.TriageStatusEnum.no &&
                            a.ArriveTime.Value >= date && 
                            a.ArriveTime.Value < endDate
                            orderby a.ArriveTime descending
                            select a;
                
                if(query.Count() > 0)
                {
                    foreach(var tem in query)
                    {
                        var config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<DAL.Registration, CommContracts.Registration>();
                        });
                        var mapper = config.CreateMapper();

                        returnTemp = mapper.Map<CommContracts.Registration>(tem);
                        returnTemp.TriageStatus = CommContracts.TriageStatusEnum.yes;

                        if (UpdateRegistration(returnTemp))
                        {
                            return returnTemp;
                        }
                    }
                }
            }

            return null;
        }

    }
}
