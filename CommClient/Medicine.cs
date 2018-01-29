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
    public class Medicine
    {
        private ILoginService client;
        public Medicine()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }


        public CommContracts.Medicine GetMedicine(int id)
        {
            return client.GetMedicine(id);
        }

        public List<CommContracts.Medicine> GetOneTypeMedicine(CommContracts.MedicineTypeEnum medicineTypeEnum, string strName = "")
        {
            return client.GetOneTypeMedicine(medicineTypeEnum, strName);
        }

        public List<CommContracts.Medicine> GetAllXiChengMedicine(string strName = "")
        {
             return client.GetAllXiChengMedicine(strName);
        }

        public List<CommContracts.Medicine> GetAllMedicine(string strName = "")
        {
             return client.GetAllMedicine(strName);
        }

        public bool UpdateMedicine(CommContracts.Medicine Medicine)
        {
            return client.UpdateMedicine(Medicine);
        }

        public bool SaveMedicine(CommContracts.Medicine Medicine)
        {
            return client.SaveMedicine(Medicine);
        }

        public bool DeleteMedicine(int MedicineID)
        {
            return client.DeleteMedicine(MedicineID);
        }

    }
}
