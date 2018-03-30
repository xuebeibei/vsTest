using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class NumStringHelper
    {
        public static string GetFirstNum()
        {
            string str = "";
            str = "0000 0001";
            return str;
        }

        public static string GetNextNum(string currentNum)
        {
            string str = "";
            // 生成下一个代码

            // 先取出一个代码"0000 0001",将" "替换成""
            currentNum = currentNum.Replace(" ", "");

            // 再将字符串转化为数字
            int n = int.Parse(currentNum);

            // 将数字加一之后变成字符串
            str = (n + 1).ToString();

            // 然后将字符串拿" "填充左侧为8位
            str = str.PadLeft(8);

            // 再将" "替换成"0"
            str = str.Replace(" ", "0");

            // 最后将字符串按照每4位进行" "分隔
            str = str.Substring(0, 4) + " " + str.Substring(4, 4);

            return str;
        }
    }

    public class Patient
    {
        public string getNewPID()
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = (from u in ctx.Patients
                             where u.PID != null
                            orderby u.ID ascending
                            select u.PID).ToList();
                string str = "";

                string strLast = query.Last();
                if (string.IsNullOrEmpty(strLast))
                {
                    str = NumStringHelper.GetFirstNum();
                }
                else
                {
                    str = NumStringHelper.GetNextNum(strLast);
                }
                return str;
            }
        }

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
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
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
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    return false;
                }
            }
            return true;
        }

        public bool UpdatePatient(CommContracts.Patient Patient, ref string ErrorMsg)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Patients.FirstOrDefault(m => m.ID == Patient.ID);
                if (temp != null)
                {
                    temp.Name = Patient.Name;
                    temp.PID = Patient.Name;
                    temp.PatientCardEnum = (DAL.PatientCardEnum)Patient.PatientCardEnum;
                    temp.PatientCardNo = Patient.Name;
                    temp.Gender = (DAL.GenderEnum)Patient.Gender;
                    temp.BirthDay = Patient.BirthDay;
                    temp.ZhengJianEnum = (DAL.ZhengJianEnum)Patient.ZhengJianEnum;
                    temp.ZhengJianNum = Patient.ZhengJianNum;
                    temp.HunYin = (DAL.HunYinEnum)Patient.HunYin;
                    temp.Country = (DAL.CountryEnum)Patient.Country;
                    temp.PatientJob = (DAL.PatientJobEnum)Patient.PatientJob;
                    temp.JobUnit = Patient.JobUnit;
                    temp.JobUnitTel = Patient.JobUnitTel;
                    temp.HomeAddress = Patient.HomeAddress;
                    temp.HomeTel = Patient.HomeTel;
                    temp.ConnectName = Patient.ConnectName;
                    temp.ConnectTel = Patient.ConnectTel;
                    temp.ConnectGuanXi = (DAL.GuanXiEnum)Patient.ConnectGuanXi;
                    temp.Volk = (DAL.VolkEnum)Patient.Volk;
                    temp.Tel = Patient.Tel;
                    temp.JiGuan_Sheng = Patient.JiGuan_Sheng;
                    temp.JiGuan_Shi = Patient.JiGuan_Shi;
                    temp.JiGuan_Xian = Patient.JiGuan_Xian;
                    temp.FeeTypeEnum = (DAL.FeeTypeEnum)Patient.FeeTypeEnum;
                    temp.YbCardNo = Patient.YbCardNo;
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
                    ErrorMsg = ex.Message;
                    return false;
                }
            }
            return true;
        }
    }
}
