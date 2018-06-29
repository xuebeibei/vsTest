using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class DoctorAdviceItem : MyTableBase
    {
        public DoctorAdviceItem()
        {
        }

        public List<CommContracts.DoctorAdviceItem> GetAllDoctorAdviceItem(string strName = "")
        {
            return client.GetAllDoctorAdviceItem(strName);
        }

        public bool UpdateDoctorAdviceItem(CommContracts.DoctorAdviceItem DoctorAdviceItem)
        {
            return client.UpdateDoctorAdviceItem(DoctorAdviceItem);
        }

        public bool SaveDoctorAdviceItem(CommContracts.DoctorAdviceItem DoctorAdviceItem)
        {
            return client.SaveDoctorAdviceItem(DoctorAdviceItem);
        }

        public bool DeleteDoctorAdviceItem(int DoctorAdviceItemID)
        {
            return client.DeleteDoctorAdviceItem(DoctorAdviceItemID);
        }
    }
}
