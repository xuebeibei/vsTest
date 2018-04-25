using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class ClinicMedicalRecordModel : MyTableBase
    {
        public ClinicMedicalRecordModel()
        {
        }

        public List<CommContracts.ClinicMedicalRecordModel> GetAllClinicMedicalRecordModel(string strName = "")
        {
            return client.GetAllClinicMedicalRecordModel(strName);
        }

        public bool UpdateClinicMedicalRecordModel(CommContracts.ClinicMedicalRecordModel ClinicMedicalRecordModel)
        {
            return client.UpdateClinicMedicalRecordModel(ClinicMedicalRecordModel);
        }

        public bool SaveClinicMedicalRecordModel(CommContracts.ClinicMedicalRecordModel ClinicMedicalRecordModel)
        {
            return client.SaveClinicMedicalRecordModel(ClinicMedicalRecordModel);
        }

        public bool DeleteClinicMedicalRecordModel(int ClinicMedicalRecordModelID)
        {
            return client.DeleteClinicMedicalRecordModel(ClinicMedicalRecordModelID);
        }
    }
}
