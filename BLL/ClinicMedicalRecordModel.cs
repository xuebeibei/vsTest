using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClinicMedicalRecordModel
    {
        public List<CommContracts.ClinicMedicalRecordModel> GetAllClinicMedicalRecordModel(string strName)
        {
            List<CommContracts.ClinicMedicalRecordModel> list = new List<CommContracts.ClinicMedicalRecordModel>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.ClinicMedicalRecordModels
                            where t.Name.StartsWith(strName) 
                            select t;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.ClinicMedicalRecordModel, CommContracts.ClinicMedicalRecordModel>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.ClinicMedicalRecordModel tem in query)
                {
                    var dto = mapper.Map<CommContracts.ClinicMedicalRecordModel>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }

        public bool SaveClinicMedicalRecordModel(CommContracts.ClinicMedicalRecordModel ClinicMedicalRecordModel)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.ClinicMedicalRecordModel, DAL.ClinicMedicalRecordModel>();
                });
                var mapper = config.CreateMapper();

                DAL.ClinicMedicalRecordModel temp = new DAL.ClinicMedicalRecordModel();
                temp = mapper.Map<DAL.ClinicMedicalRecordModel>(ClinicMedicalRecordModel);

                ctx.ClinicMedicalRecordModels.Add(temp);
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

        public bool DeleteClinicMedicalRecordModel(int ClinicMedicalRecordModelID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.ClinicMedicalRecordModels.FirstOrDefault(m => m.ID == ClinicMedicalRecordModelID);
                if (temp != null)
                {
                    ctx.ClinicMedicalRecordModels.Remove(temp);
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

        public bool UpdateClinicMedicalRecordModel(CommContracts.ClinicMedicalRecordModel ClinicMedicalRecordModel)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.ClinicMedicalRecordModels.FirstOrDefault(m => m.ID == ClinicMedicalRecordModel.ID);
                if (temp != null)
                {
                    temp.Name = ClinicMedicalRecordModel.Name;
                    temp.EmployeeID = ClinicMedicalRecordModel.EmployeeID;
                    temp.DepartmentID = ClinicMedicalRecordModel.DepartmentID;
                    temp.ModelUsageRangeEnum = (DAL.ModelUsageRangeEnum)ClinicMedicalRecordModel.ModelUsageRangeEnum;
                    temp.ContentXML = ClinicMedicalRecordModel.ContentXML;
                    temp.ModifiedDate = ClinicMedicalRecordModel.ModifiedDate;
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
