using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommContracts;
using System.ServiceModel;
using System.Collections;

namespace CommClient
{
    public class Inpatient
    {
        private ILoginService client;

        public Inpatient()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public List<CommContracts.Inpatient> GetAllInPatientList(CommContracts.InHospitalStatusEnum inHospitalStatusEnum, string strName = "")
        {
            return client.GetAllInPatientList(inHospitalStatusEnum, strName);
        }

        public string getInPatientBMIMsg(int InpatientID)
        {
            return client.getInPatientBMIMsg(InpatientID);
        }

        public Dictionary<int, string> GetAllInPatientMsg()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            List<CommContracts.Inpatient> list = new List<CommContracts.Inpatient>();
            list = client.GetAllInPatientList(CommContracts.InHospitalStatusEnum.在院中);
            foreach (var tem in list)
            {
                if (tem != null)
                {
                    string str = tem.Patient.Name + " " +
                                    tem.Patient.Gender +
                                    "岁\r\n" +
                                    "科室：\r\n" +
                                    "医生：" + "\r\n" +
                                    "入院时间：" + tem.InHospitalTime.ToString() + "\r\n";
                    dictionary.Add(tem.ID, str);
                }
            }
            return dictionary;
        }

        public bool SaveInPatient(CommContracts.Inpatient inpatient)
        {
            return client.SaveInPatient(inpatient);
        }

        public bool UpdateInPatient(CommContracts.Inpatient inpatient)
        {
            return client.UpdateInPatient(inpatient);
        }

        // 读取未入院患者信息，并新建入院登记
        public CommContracts.Inpatient ReadNewInPatient(int PatientID)
        {
            return client.ReadNewInPatient(PatientID);
        }

        // 读取已入院患者信息
        public CommContracts.Inpatient ReadCurrentInPatient(int InPatientID)
        {
            return client.ReadCurrentInPatient(InPatientID);
        }

        // 读取已出院患者信息
        public CommContracts.Inpatient ReadLeavedPatient(int InPatientID)
        {
            return client.ReadLeavedPatient(InPatientID);
        }
    }
}
