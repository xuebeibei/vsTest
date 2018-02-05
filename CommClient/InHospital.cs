using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class InHospital : MyTableBase
    {
        public List<CommContracts.InHospital> GetAllInHospitalList(int EmployeeID = 0, string strName = "")
        {
            return client.GetAllInHospitalList( EmployeeID, strName);
        }

        public bool SaveInHospital(CommContracts.InHospital inpatient)
        {
            return client.SaveInHospital(inpatient);
        }

        public bool UpdateInHospital(CommContracts.InHospital inpatient)
        {
            return client.UpdateInHospital(inpatient);
        }

        // 读取未入院患者信息，并新建入院登记
        public CommContracts.InHospital ReadNewInHospital(int PatientID)
        {
            return client.ReadNewInHospital(PatientID);
        }

        // 读取已入院患者信息
        public CommContracts.InHospital ReadCurrentInHospital(int InHospitalID)
        {
            return client.ReadCurrentInHospital(InHospitalID);
        }

        // 读取已出院患者信息
        public CommContracts.InHospital ReadLeavedPatient(int InHospitalID)
        {
            return client.ReadLeavedPatient(InHospitalID);
        }
    }
}
