using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Inpatient
    {
        public List<CommContracts.Inpatient> GetAllInPatientList(CommContracts.InHospitalStatusEnum inHospitalStatusEnum, string strName = "")
        {
            List<CommContracts.Inpatient> list = new List<CommContracts.Inpatient>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.Inpatients
                            where a.InHospitalStatusEnum == (DAL.InHospitalStatusEnum)inHospitalStatusEnum &&
                            a.Patient.Name.StartsWith(strName)
                            select a;
                foreach (DAL.Inpatient ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Inpatient, CommContracts.Inpatient>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Inpatient temp = mapper.Map<CommContracts.Inpatient>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }

        public string getInPatientBMIMsg(int InpatientID)
        {
            string strMsg = "";
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from i in ctx.Inpatients
                            where i.ID == InpatientID
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

        public bool SaveInPatient(CommContracts.Inpatient inpatient)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config1 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Patient, DAL.Patient>().
                    ForMember(x => x.Registrations, opt => opt.Ignore()).
                    ForMember(x => x.Inpatients, opt => opt.Ignore());
                });
                var mapper1 = config1.CreateMapper();

                DAL.Patient patient = new DAL.Patient();
                patient = mapper1.Map<DAL.Patient>(inpatient.Patient);

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Inpatient, DAL.Inpatient>().ForMember(x => x.Patient, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.Inpatient temp = new DAL.Inpatient();
                temp = mapper.Map<DAL.Inpatient>(inpatient);
                temp.Patient = patient;



                ctx.Inpatients.Add(temp);
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

        public bool UpdateInPatient(CommContracts.Inpatient inpatient)
        {
            if (inpatient == null)
                return false;
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                DAL.Inpatient temp = new DAL.Inpatient();
                temp = ctx.Inpatients.Find(inpatient.ID);
                if (temp == null)
                    return false;

                temp.No = inpatient.No;
                temp.PayTypeEnum = (DAL.PayTypeEnum)inpatient.PayTypeEnum;
                temp.YiBaoNo = inpatient.YiBaoNo;
                temp.PatientID = inpatient.PatientID;
                temp.MarriageEnum = (DAL.MarriageEnum)inpatient.MarriageEnum;
                temp.Job = inpatient.Job;
                temp.WorkAddress = inpatient.WorkAddress;
                temp.ContactsName = inpatient.ContactsName;
                temp.ContactsTel = inpatient.ContactsTel;
                temp.ContactsAddress = inpatient.ContactsAddress;
                temp.InHospitalTime = inpatient.InHospitalTime;
                temp.InHospitalDiagnoses = inpatient.InHospitalDiagnoses;
                temp.IllnesSstateEnum = (DAL.IllnesSstateEnum)inpatient.IllnesSstateEnum;
                temp.InPatientUserID = inpatient.InPatientUserID;

                temp.LeaveHospitalDepartment = inpatient.LeaveHospitalDepartment;
                temp.LeaveHospitalDiagnoses = inpatient.LeaveHospitalDiagnoses;
                temp.LeaveHospitalDoctorName = inpatient.LeaveHospitalDoctorName;
                temp.LeaveHospitalTime = inpatient.LeaveHospitalTime;
                temp.LeaveHospitalUserID = inpatient.LeaveHospitalUserID;

                temp.InHospitalStatusEnum = (DAL.InHospitalStatusEnum)inpatient.InHospitalStatusEnum;

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
        public CommContracts.Inpatient ReadNewInPatient(int PatientID)
        {
            CommContracts.Inpatient temp = new CommContracts.Inpatient();
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
        public CommContracts.Inpatient ReadCurrentInPatient(int InPatientID)
        {
            CommContracts.Inpatient re = new CommContracts.Inpatient();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.Inpatients
                            where a.InHospitalStatusEnum == DAL.InHospitalStatusEnum.在院中 &&
                            a.ID == InPatientID
                            select a;
                foreach (DAL.Inpatient ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Inpatient, CommContracts.Inpatient>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Inpatient temp = mapper.Map<CommContracts.Inpatient>(ass);
                    re = temp;

                    break;
                }
            }
            return re;
        }

        // 读取已出院患者信息
        public CommContracts.Inpatient ReadLeavedPatient(int InPatientID)
        {
            CommContracts.Inpatient re = new CommContracts.Inpatient();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.Inpatients
                            where a.InHospitalStatusEnum == DAL.InHospitalStatusEnum.已出院 &&
                            a.ID == InPatientID
                            select a;
                foreach (DAL.Inpatient ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Inpatient, CommContracts.Inpatient>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Inpatient temp = mapper.Map<CommContracts.Inpatient>(ass);
                    re = temp;

                    break;
                }
            }
            return re;
        }
    }
}
