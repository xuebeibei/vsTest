using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class DoctorClinicWorkPlan
        : MyTableBase
    {
        public DoctorClinicWorkPlan()
        {
        }

        public List<CommContracts.DoctorClinicWorkPlan> GetAllDoctorClinicWorkPlan(string strName = "")
        {
            return client.GetAllDoctorClinicWorkPlan(strName);
        }

        public bool UpdateDoctorClinicWorkPlan(CommContracts.DoctorClinicWorkPlan DoctorClinicWorkPlan)
        {
            return client.UpdateDoctorClinicWorkPlan(DoctorClinicWorkPlan);
        }

        public bool SaveDoctorClinicWorkPlan(CommContracts.DoctorClinicWorkPlan DoctorClinicWorkPlan)
        {
            return client.SaveDoctorClinicWorkPlan(DoctorClinicWorkPlan);
        }

        public bool DeleteDoctorClinicWorkPlan(int DoctorClinicWorkPlanID)
        {
            return client.DeleteDoctorClinicWorkPlan(DoctorClinicWorkPlanID);
        }
    }
}
