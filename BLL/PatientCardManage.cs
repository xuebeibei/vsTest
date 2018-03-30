using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PatientCardManage
    {
        public List<CommContracts.PatientCardManage> GetAllPatientCardManage(string strName)
        {
            List<CommContracts.PatientCardManage> list = new List<CommContracts.PatientCardManage>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.PatientCardManages
                            where t.Patient.Name.StartsWith(strName) ||
                            t.User.Username.StartsWith(strName)
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    //.ForMember(x => x.User, opt => opt.Ignore())
                    cfg.CreateMap<DAL.PatientCardManage, CommContracts.PatientCardManage>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.PatientCardManage tem in query)
                {
                    var dto = mapper.Map<CommContracts.PatientCardManage>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SavePatientCardManage(CommContracts.PatientCardManage PatientCardManage, ref string ErrorMsg)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                if(!string.IsNullOrEmpty(PatientCardManage.Patient.ZhengJianNum))
                {
                    var query = from u in ctx.Patients
                                where u.ZhengJianNum == PatientCardManage.Patient.ZhengJianNum
                                select u;
                    if (query.Count() > 0)
                    {
                        ErrorMsg = "身份证号已存在";
                        return false;
                    }
                }

                if(!string.IsNullOrEmpty(PatientCardManage.Patient.Tel))
                {
                    var query = from u in ctx.Patients
                            where u.Tel == PatientCardManage.Patient.Tel
                            select u;

                    if (query.Count() > 0)
                    {
                        ErrorMsg = "电话号已存在";
                        return false;
                    }
                }
               
                if(!string.IsNullOrEmpty(PatientCardManage.Patient.YbCardNo))
                {
                    var query = from u in ctx.Patients
                                where u.YbCardNo == PatientCardManage.Patient.YbCardNo && 
                                u.FeeTypeEnum == (DAL.FeeTypeEnum)PatientCardManage.Patient.FeeTypeEnum
                                select u;

                    if (query.Count() > 0)
                    {
                        ErrorMsg = "医保号已存在";
                        return false;
                    }
                }

                var config2 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.PatientCardManage, DAL.PatientCardManage>().
                    ForMember(x => x.User, opt => opt.Ignore()).
                    ForMember(x => x.Patient, opt => opt.Ignore());
                });
                var mapper2 = config2.CreateMapper();

                DAL.PatientCardManage dalPatientCardManage = new DAL.PatientCardManage();
                dalPatientCardManage = mapper2.Map<DAL.PatientCardManage>(PatientCardManage);


                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Patient, DAL.Patient>();
                });
                var mapper = config.CreateMapper();


                DAL.Patient tempPatient = new DAL.Patient();
                tempPatient = mapper.Map<DAL.Patient>(PatientCardManage.Patient);
                dalPatientCardManage.Patient = tempPatient;

                ctx.PatientCardManages.Add(dalPatientCardManage);
                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    ErrorMsg = ex.Message.ToString();
                    return false;
                }
            }
            ErrorMsg = "";

            return true;
        }

        public bool DeletePatientCardManage(int PatientCardManageID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.PatientCardManages.FirstOrDefault(m => m.ID == PatientCardManageID);
                if (temp != null)
                {
                    ctx.PatientCardManages.Remove(temp);
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

        public bool UpdatePatientCardManage(CommContracts.PatientCardManage PatientCardManage)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.PatientCardManages.FirstOrDefault(m => m.ID == PatientCardManage.ID);
                if (temp != null)
                {
                    temp.PatientID = PatientCardManage.PatientID;
                    temp.CardNo = PatientCardManage.CardNo;
                    temp.CardManageEnum = (DAL.CardManageEnum)PatientCardManage.CardManageEnum;
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
    }
}
