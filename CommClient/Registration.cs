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

        public List<CommContracts.Registration> getAllRegistration()
        {
            return client.getAllRegistration();
        }

        public void SetRegistration(CommContracts.Registration registration)
        {
            this.registration = registration;
        }

        public DateTime GetDateTime ()
        {
            return registration.GetDateTime;
        }

        public string getPatientMsg()
        {
            return registration.GetPatient.Name + " " + 
                registration.GetPatient.Gender + " " + 
                registration.GetPatient.Age;
        }

        public string getDepartment()
        {
            try
            {
                return registration.GetSignalSource.GetDepartment.Name;
            }
            catch(Exception ex)
            {
                return "";
            }
            
        }

        public string getDoctor()
        {
            if(registration.GetSignalSource.SignalType == 1)
            {
                return "";
            }
            return registration.GetSignalSource.Specialist.ToString();
        }

        public DateTime getVisitingTime()
        {
            return registration.GetSignalSource.VistTime;
        }

        public bool SaveRegistration()
        {
            return client.SaveRegistration(registration);
        }

    }
}
