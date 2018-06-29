using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class DoctorAdviceDetail : MyTableBase
    {
        public DoctorAdviceDetail()
        {
        }

        public List<CommContracts.DoctorAdviceDetail> GetAllDoctorAdviceDetail(string strName = "")
        {
            return client.GetAllDoctorAdviceDetail(strName);
        }

        public bool UpdateDoctorAdviceDetail(CommContracts.DoctorAdviceDetail DoctorAdviceDetail)
        {
            return client.UpdateDoctorAdviceDetail(DoctorAdviceDetail);
        }

        public bool SaveDoctorAdviceDetail(CommContracts.DoctorAdviceDetail DoctorAdviceDetail)
        {
            return client.SaveDoctorAdviceDetail(DoctorAdviceDetail);
        }

        public bool DeleteDoctorAdviceDetail(int DoctorAdviceDetailID)
        {
            return client.DeleteDoctorAdviceDetail(DoctorAdviceDetailID);
        }
    }
}
