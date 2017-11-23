
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.Entity;
using System.Data;
using System.Globalization;
using System.Collections;

namespace BLL
{
    public class Department
    {
        public int getAllDepartmentNum()
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var queryResult = from u in ctx.Departments
                                  select u;

                return queryResult.Count();
            }
        }

        public List<CommContracts.Department> getALLDepartment()
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {

                IEnumerable<DAL.Department> queryResultList = from u in ctx.Departments
                                                                        select u;
                List<CommContracts.Department> myList = new List<CommContracts.Department>();

                
                foreach(DAL.Department tem in queryResultList)
                {
                    CommContracts.Department temp1 = new CommContracts.Department();
                    temp1.ID = tem.ID;
                    temp1.Name = tem.Name;
                    temp1.Abbr = tem.Abbr;
                    temp1.IsDoctorDepartment = tem.IsDoctorDepartment;
                    temp1.ParentDepartmentID = tem.ParentID;

                    myList.Add(temp1);
                }
                return myList;
            }
        }
    }
}