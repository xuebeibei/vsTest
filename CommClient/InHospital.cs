using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class InHospital : MyTableBase
    {
        public List<CommContracts.InHospital> GetAllInHospitalList(CommContracts.InHospitalStatusEnum inHospitalStatusEnum, string strName = "")
        {
            return client.GetAllInHospitalList(inHospitalStatusEnum, strName);
        }

        public List<CommContracts.InHospital> GetAllInHospitalMsg()
        {
            List<CommContracts.InHospital> dictionary = new List<CommContracts.InHospital>();

            List<CommContracts.InHospital> list = new List<CommContracts.InHospital>();
            list = client.GetAllInHospitalList(CommContracts.InHospitalStatusEnum.在院中);
            foreach (var tem in list)
            {
                if (tem != null)
                {
                    string str = tem.Patient.Name + " " +
                                    tem.Patient.Gender +
                                    "岁\r\n" +
                                    "科室：\r\n" +
                                    "医生：" + "\r\n" +
                                    "入院时间：" + tem.InTime.ToString() + "\r\n";
                    dictionary.Add(tem);
                }
            }
            return dictionary;
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
