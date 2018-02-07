using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Patient
    {
        public CommContracts.Patient ReadCurrentPatient(int PatientID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                CommContracts.Patient patient = new CommContracts.Patient();
                var temp = ctx.Patients.Find(PatientID);
                if (temp == null)
                    return patient;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Patient, CommContracts.Patient>();
                });
                var mapper = config.CreateMapper();

                patient = mapper.Map<CommContracts.Patient>(temp);

                return patient;

            }
        }

        public decimal GetCurrentPatientBalance(int PatientID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                decimal balance = 0.0m;
                var temp = ctx.PrePays.Where(x => x.PatientID == PatientID).Count();
                if (temp > 0)
                {
                    var prePayBalance = ctx.PrePays.Where(s => (s.PatientID == PatientID)).Select(o => o.PrePayMoney).Sum();
                    balance += prePayBalance;
                }


                // 挂号付费
                temp = (from u in ctx.Registrations
                        where u.PatientID == PatientID &&
                        u.PayWayEnum == DAL.PayWayEnum.账户支付 &&
                        !u.ReturnTime.HasValue
                        select u.RegisterFee).Count();
                if(temp>0)
                {
                    var RegistrationBalance = (from u in ctx.Registrations
                                             where u.PatientID == PatientID &&
                                             u.PayWayEnum == DAL.PayWayEnum.账户支付 &&
                                             !u.ReturnTime.HasValue
                                             select u.RegisterFee).Sum();
                    balance -= RegistrationBalance;
                }


                // 正常用药收费
                temp = (from u in ctx.MedicineCharges
                        where u.MedicineDoctorAdvice.PatientID == PatientID &&
                        u.PayWayEnum == DAL.PayWayEnum.账户支付
                        select u.SumOfMoney).Count();
                if(temp>0)
                {
                    var MedicineChargeBalance = (from u in ctx.MedicineCharges
                                                 where u.MedicineDoctorAdvice.PatientID == PatientID &&
                                               u.PayWayEnum == DAL.PayWayEnum.账户支付
                                                 select u.SumOfMoney).Sum();
                    balance -= MedicineChargeBalance;
                }

                // 材料收费
                temp = (from u in ctx.MaterialCharges
                        where u.MaterialDoctorAdvice.PatientID == PatientID &&
                        u.PayWayEnum == DAL.PayWayEnum.账户支付
                        select u.SumOfMoney).Count();
                if (temp > 0)
                {
                    var MaterialChargeBalance = (from u in ctx.MaterialCharges
                                                 where u.MaterialDoctorAdvice.PatientID == PatientID &&
                                               u.PayWayEnum == DAL.PayWayEnum.账户支付
                                                 select u.SumOfMoney).Sum();
                    balance -= MaterialChargeBalance;
                }
                //  化验收费
                temp = (from u in ctx.AssayCharges
                        where u.AssayDoctorAdvice.PatientID == PatientID &&
                        u.PayWayEnum == DAL.PayWayEnum.账户支付
                        select u.SumOfMoney).Count();
                if (temp > 0)
                {
                    var AssayChargeBalance = (from u in ctx.AssayCharges
                                              where u.AssayDoctorAdvice.PatientID == PatientID &&
                                            u.PayWayEnum == DAL.PayWayEnum.账户支付
                                              select u.SumOfMoney).Sum();
                    balance -= AssayChargeBalance;
                }
                //  检查收费
                temp = (from u in ctx.InspectCharges
                        where u.InspectDoctorAdvice.PatientID == PatientID &&
                        u.PayWayEnum == DAL.PayWayEnum.账户支付
                        select u.SumOfMoney).Count();
                if (temp > 0)
                {
                    var InspectChargeBalance = (from u in ctx.InspectCharges
                                                where u.InspectDoctorAdvice.PatientID == PatientID &&
                                              u.PayWayEnum == DAL.PayWayEnum.账户支付
                                                select u.SumOfMoney).Sum();
                    balance -= InspectChargeBalance;
                }
                //  治疗收费
                temp = (from u in ctx.TherapyCharges
                        where u.TherapyDoctorAdvice.PatientID == PatientID &&
                        u.PayWayEnum == DAL.PayWayEnum.账户支付
                        select u.SumOfMoney).Count();
                if (temp > 0)
                {
                    var TherapyChargeBalance = (from u in ctx.TherapyCharges
                                               where u.TherapyDoctorAdvice.PatientID == PatientID &&
                                             u.PayWayEnum == DAL.PayWayEnum.账户支付
                                               select u.SumOfMoney).Sum();
                    balance -= TherapyChargeBalance;
                }


                return balance;

            }
        }

        public List<CommContracts.Patient> GetAllPatient(string strName)
        {
            List<CommContracts.Patient> list = new List<CommContracts.Patient>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.Patients
                            where t.Name.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Patient, CommContracts.Patient>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.Patient tem in query)
                {
                    var dto = mapper.Map<CommContracts.Patient>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SavePatient(CommContracts.Patient Patient)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Patient, DAL.Patient>();
                });
                var mapper = config.CreateMapper();

                DAL.Patient temp = new DAL.Patient();
                temp = mapper.Map<DAL.Patient>(Patient);

                ctx.Patients.Add(temp);
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

        public bool DeletePatient(int PatientID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Patients.FirstOrDefault(m => m.ID == PatientID);
                if (temp != null)
                {
                    ctx.Patients.Remove(temp);
                }

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

        public bool UpdatePatient(CommContracts.Patient Patient)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Patients.FirstOrDefault(m => m.ID == Patient.ID);
                if (temp != null)
                {
                    temp.Name = Patient.Name;
                    temp.Gender = (DAL.GenderEnum)Patient.Gender;
                    temp.BirthDay = Patient.BirthDay;
                    temp.IDCardNo = Patient.IDCardNo;
                    temp.Volk = (DAL.VolkEnum)Patient.Volk;
                    temp.Tel = Patient.Tel;
                    temp.JiGuan = Patient.JiGuan;
                }
                else
                {
                    return false;
                }

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
