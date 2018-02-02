using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InHospital
    {
        public List<CommContracts.InHospital> GetAllInHospitalList(CommContracts.InHospitalStatusEnum inHospitalStatusEnum, int EmployeeID = 0, string strName = "")
        {
            List<CommContracts.InHospital> list = new List<CommContracts.InHospital>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.InHospitals
                            from b in a.InHospitalPatientDoctors
                            where a.InHospitalStatusEnum == (DAL.InHospitalStatusEnum)inHospitalStatusEnum &&
                            a.Patient.Name.StartsWith(strName) &&
                            (EmployeeID == 0 || (b.EndTime == null && b.DoctorID == EmployeeID))
                            select a;

                foreach (DAL.InHospital ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.InHospital, CommContracts.InHospital>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.InHospital temp = mapper.Map<CommContracts.InHospital>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public string getInHospitalBMIMsg(int InHospitalID)
        {
            string strMsg = "";
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from i in ctx.InHospitals
                            where i.ID == InHospitalID
                            select i;
                foreach (var tem in query)
                {
                    if (tem == null)
                        continue;

                    int PatientID = tem.PatientID;
                    var patient = ctx.Patients.Find(PatientID);
                    strMsg = patient.ToBMIMsg();

                    break;
                }
            }

            return strMsg;
        }

        public bool SaveInHospital(CommContracts.InHospital InHospital)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config1 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Patient, DAL.Patient>().
                    ForMember(x => x.Registrations, opt => opt.Ignore()).
                    ForMember(x => x.InHospitals, opt => opt.Ignore());
                });
                var mapper1 = config1.CreateMapper();

                DAL.Patient patient = new DAL.Patient();
                patient = mapper1.Map<DAL.Patient>(InHospital.Patient);

                var config2 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.InHospitalPatientDoctor, DAL.InHospitalPatientDoctor>().
                    ForMember(x => x.InHospital, opt => opt.Ignore()).
                    ForMember(x=>x.Doctor, opt=>opt.Ignore()).ForMember(x=>x.User ,opt=>opt.Ignore());
                });
                var mapper2 = config2.CreateMapper();

                List<DAL.InHospitalPatientDoctor> patientDoctors = new List<DAL.InHospitalPatientDoctor>();
                patientDoctors = mapper2.Map<List<DAL.InHospitalPatientDoctor>>(InHospital.InHospitalPatientDoctors);


                var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<CommContracts.InHospital, DAL.InHospital>().
                        ForMember(x => x.Patient, opt => opt.Ignore()).
                        ForMember(x => x.InHospitalPatientDoctors, opt => opt.Ignore());
                    });
                var mapper = config.CreateMapper();


                DAL.InHospital temp = new DAL.InHospital();
                temp = mapper.Map<DAL.InHospital>(InHospital);
                temp.Patient = patient;
                temp.InHospitalPatientDoctors = patientDoctors;



                ctx.InHospitals.Add(temp);
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

        public bool UpdateInHospital(CommContracts.InHospital InHospital)
        {
            if (InHospital == null)
                return false;
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                DAL.InHospital temp = new DAL.InHospital();
                temp = ctx.InHospitals.Find(InHospital.ID);
                if (temp == null)
                    return false;

                temp.NO = InHospital.NO;
                temp.PatientID = InHospital.PatientID;
                temp.InTime = InHospital.InTime;
                temp.UserID = InHospital.UserID;
                temp.CurrentTime = InHospital.CurrentTime;

                temp.InHospitalStatusEnum = (DAL.InHospitalStatusEnum)InHospital.InHospitalStatusEnum;

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

        // 读取未入院患者信息，并新建入院登记
        public CommContracts.InHospital ReadNewInHospital(int PatientID)
        {
            CommContracts.InHospital temp = new CommContracts.InHospital();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.Patients
                            where a.ID == PatientID
                            select a;
                foreach (DAL.Patient ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Patient, CommContracts.Patient>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Patient patient = mapper.Map<CommContracts.Patient>(ass);
                    temp.Patient = patient;

                    break;
                }
            }
            return temp;
        }
        // 读取已入院患者信息
        public CommContracts.InHospital ReadCurrentInHospital(int InHospitalID)
        {
            CommContracts.InHospital re = new CommContracts.InHospital();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.InHospitals
                            where a.InHospitalStatusEnum == DAL.InHospitalStatusEnum.在院中 &&
                            a.ID == InHospitalID
                            select a;
                foreach (DAL.InHospital ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.InHospital, CommContracts.InHospital>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.InHospital temp = mapper.Map<CommContracts.InHospital>(ass);
                    re = temp;

                    break;
                }
            }
            return re;
        }

        // 读取已出院患者信息
        public CommContracts.InHospital ReadLeavedPatient(int InHospitalID)
        {
            CommContracts.InHospital re = new CommContracts.InHospital();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.InHospitals
                            where a.InHospitalStatusEnum == DAL.InHospitalStatusEnum.已出院 &&
                            a.ID == InHospitalID
                            select a;
                foreach (DAL.InHospital ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.InHospital, CommContracts.InHospital>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.InHospital temp = mapper.Map<CommContracts.InHospital>(ass);
                    re = temp;

                    break;
                }
            }
            return re;
        }
    }
}
