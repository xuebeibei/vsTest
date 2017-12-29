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
    public class MaterialBill
    {
        private ILoginService client;

        public MaterialBill()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public CommContracts.MaterialBill GetMaterialBill(int Id)
        {
            return client.GetMaterialBill(Id);
        }

        public bool SaveMaterialBill(CommContracts.MaterialBill materialBill)
        {
            return client.SaveMaterialBill(materialBill);
        }

        public List<CommContracts.MaterialBill> getAllMaterialBill(int RegistrationID)
        {
            return client.getAllMaterialBill(RegistrationID);
        }

        public List<CommContracts.MaterialBill> getAllInHospitalMaterialBill(int InpatientID)
        {
            return client.getAllInHospitalMaterialBill(InpatientID);
        }
    }
}
