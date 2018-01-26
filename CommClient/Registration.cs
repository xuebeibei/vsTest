﻿using System;
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

        public List<CommContracts.Registration> GetDepartmentRegistrationList(int DepartmentID, int EmployeeID, DateTime startDate, DateTime endDate)
        {
            return client.GetDepartmentRegistrationList(DepartmentID, EmployeeID, startDate, endDate);
        }

        public bool SaveRegistration(CommContracts.Registration registration)
        {
            return client.SaveRegistration(registration);
        }

        // 查找某个患者最后一次挂号情况
        public CommContracts.Registration ReadLastRegistration(int PatientID)
        {
            return client.ReadLastRegistration(PatientID);
        }

    }
}
