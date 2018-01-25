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
    public class Patient
    {
        private ILoginService client;

        public Patient()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }
        public CommContracts.Patient ReadCurrentPatient(int PatientID)
        {
            return client.ReadCurrentPatient(PatientID);
        }

        public decimal GetCurrentPatientBalance(int PatientID)
        {
            return client.GetCurrentPatientBalance(PatientID);
        }

        public List<CommContracts.Patient> GetAllPatient(string strName = "")
        {
            return client.GetAllPatient(strName);
        }

        public bool UpdatePatient(CommContracts.Patient patient)
        {
            return client.UpdatePatient(patient);
        }

        public bool SavePatient(CommContracts.Patient patient)
        {
            return client.SavePatient(patient);
        }

        public bool DeletePatient(int PatientID)
        {
            return client.DeletePatient(PatientID);
        }
    }
}
