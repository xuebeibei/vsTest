﻿using AutoMapper;
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

                foreach(DAL.Employee tem in query)
                {
                    Mapper.Initialize(x => x.CreateMap<CommContracts.Employee, DAL.Employee>());

                    var dto = Mapper.Map<CommContracts.Employee>(tem);

                    list.Add(dto);
                }
            }
            return list;
        }
    }
}
