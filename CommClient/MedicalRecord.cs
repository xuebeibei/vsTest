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
    public class MedicalRecord
    {
        private ILoginService client;
        public MedicalRecord()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public CommContracts.MedicalRecord GetMedicalRecord(int id)
        {
            return client.GetMedicalRecord(id);
        }

        public bool SaveMedicalRecord(CommContracts.MedicalRecord medicalRecord)
        {
            return client.SaveMedicalRecord(medicalRecord);
        }
    }
}
