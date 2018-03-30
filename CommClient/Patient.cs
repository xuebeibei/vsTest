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
    public class Patient : MyTableBase
    {
        public Patient()
        {
        }

        public string getNewPID()
        {
            return client.getNewPID();
        }

        public string getNewPatientCardNum()
        {
            return client.getNewPatientCardNum();
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

        public bool UpdatePatient(CommContracts.Patient patient, ref string ErrorMsg)
        {
            return client.UpdatePatient(patient, ref ErrorMsg);
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
