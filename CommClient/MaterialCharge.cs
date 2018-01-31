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
    public class MaterialCharge
    {
        private ILoginService client;

        public MaterialCharge()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public bool SaveMaterialCharge(CommContracts.MaterialCharge MaterialCharge)
        {
            return client.SaveMaterialCharge(MaterialCharge);
        }

        public List<CommContracts.MaterialCharge> GetAllChargeFromMaterialAdvice(int AdviceID)
        {
            return client.GetAllChargeFromMaterialAdvice(AdviceID);
        }

        public List<CommContracts.MaterialCharge> GetAllClinicMaterialCharge(int RegistrationID)
        {
            return client.GetAllClinicMaterialCharge(RegistrationID);
        }

        public List<CommContracts.MaterialCharge> GetAllInHospitalMaterialCharge(int InpatientID)
        {
            return client.GetAllInHospitalMaterialCharge(InpatientID);
        }
    }
}
