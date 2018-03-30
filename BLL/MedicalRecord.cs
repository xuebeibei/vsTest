using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    // 病历
    public class MedicalRecord
    {
        public MedicalRecord()
        {

        }

        public CommContracts.MedicalRecord GetMedicalRecord(int RegistrationID)
        {
            CommContracts.MedicalRecord medicalRecord = new CommContracts.MedicalRecord();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from m in ctx.MedicalRecords
                            where m.RegistrationID == RegistrationID
                            orderby m.WriteTime descending
                            select m ;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.MedicalRecord, CommContracts.MedicalRecord>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    medicalRecord = mapper.Map<CommContracts.MedicalRecord>(tem);
                    break;
                }
                
            }
            return medicalRecord;
        }

        public bool SaveMedicalRecord(CommContracts.MedicalRecord medicalRecord)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = new DAL.MedicalRecord();

                temp.ID = medicalRecord.ID;
                temp.NO = medicalRecord.NO;
                temp.MedicalRecordEnum = (DAL.MedicalRecordEnum)medicalRecord.MedicalRecordEnum;
                temp.RegistrationID = medicalRecord.RegistrationID;
                temp.WriteTime = medicalRecord.WriteTime;
                temp.WriteUserID = medicalRecord.WriteUserID;
                temp.ContentXml = medicalRecord.ContentXml;

                ctx.MedicalRecords.Add(temp);
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
                return true;
            }
        }
    }
}
