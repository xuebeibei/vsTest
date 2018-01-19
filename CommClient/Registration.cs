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
    public class Registration
    {
        private ILoginService client;

        private CommContracts.Registration registration;

        public Registration()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));

            registration = new CommContracts.Registration();
        }

        public Dictionary<int, string> getAllRegistration()
        {
            return client.getAllRegistration();
        }

        public Dictionary<int, string> GetAllClinicPatients(DateTime startDate, DateTime endDate, string strFindName = "", bool HavePay = false)
        {
            return client.GetAllClinicPatients(startDate, endDate, strFindName, HavePay);
        }

        public string getPatientBMIMsg(int RegistrationID)
        {
            return client.getPatientBMIMsg(RegistrationID);
        }

        public void SetRegistration(CommContracts.Registration registration)
        {
            this.registration = registration;
        }

        public DateTime? GetDateTime ()
        {
            return registration.RegisterTime;
        }

        public string getPatientMsg()
        {
            return registration.Patient.Name + " " +
                registration.Patient.Gender + " ";
        }

        public string getDepartment()
        {
            try
            {
                return registration.SignalSource.GetDepartment.Name;
            }
            catch(Exception ex)
            {
                return "";
            }
            
        }

        public string getDoctor()
        {
            if(registration.SignalSource.SignalType == 1)
            {
                return "";
            }
            return registration.SignalSource.Specialist.ToString();
        }

        public DateTime? getVisitingTime()
        {
            return registration.SignalSource.VistTime;
        }

        public bool SaveRegistration()
        {
            return client.SaveRegistration(registration);
        }

    }
}
