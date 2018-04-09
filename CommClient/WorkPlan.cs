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
    public class WorkPlan : MyTableBase
    {
        public WorkPlan()
        {
        }

        public List<CommContracts.WorkPlan> GetAllWorkPlan()
        {
            return client.GetAllWorkPlan();
        }

        public List<DateTime> getAllWorkPlanDate(int DepartmentID)
        {
            return client.getAllWorkPlanDate(DepartmentID);
        }

        public List<int> getAllWorkPlanIntival(int DepartmentID)
        {
            return client.getAllWorkPlanIntival(DepartmentID);
        }

        public string getWorkPlanTip(int DepartmentID, DateTime dateTime, int TimeIntival)
        {
            return client.getWorkPlanTip(DepartmentID, dateTime, TimeIntival);
        }

        public bool UpdateWorkPlanHasUsedNum(int nSignalSourceID)
        {
            return client.UpdateWorkPlanHasUsedNum(nSignalSourceID);
        }

        public bool SaveWorkPlanList(List<CommContracts.WorkPlan> list)
        {
            return client.SaveWorkPlanList(list);
        }

        public List<CommContracts.WorkPlan> GetWorkPlanList(int DepartmentID, int EmployeeID, DateTime startDate, DateTime endDate)
        {
            return client.GetWorkPlanList(DepartmentID, EmployeeID, startDate, endDate);
        }

        public bool UpdateWorkPlan(CommContracts.WorkPlan signalSource)
        {
            return client.UpdateWorkPlan(signalSource);
        }

        public bool UpdateWorkPlanStatus(int workPlanID, CommContracts.WorkPlanStatus workPlanStatus)
        {
            return client.UpdateWorkPlanStatus(workPlanID, workPlanStatus);
        }
    }
}
