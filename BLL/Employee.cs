using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Employee
    {
        public List<CommContracts.Employee> getAllDoctor()
        {
            List<CommContracts.Employee> list = new List<CommContracts.Employee>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = ctx.Employees.Include("Job").Include("Department").ToList();

               // var aa = from c in query where c.Job.ID == 1 select c;

                Mapper.Initialize(x => x.CreateMap<DAL.Employee, CommContracts.Employee>());

                foreach (DAL.Employee tem in query)
                {
                    var dto = Mapper.Map<CommContracts.Employee>(tem);
                    list.Add(dto);
                }
            }

            return list;
        }
    }
}
