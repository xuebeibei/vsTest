﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Inspect
    {
        public CommContracts.Inspect GetInspect(int Id)
        {
            CommContracts.Inspect inspect = new CommContracts.Inspect();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.Inspects
                            where t.ID == Id
                            select t;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Inspect, CommContracts.Inspect>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    inspect = mapper.Map<CommContracts.Inspect>(tem);
                    break;
                }
            }
            return inspect;
        }

        public bool SaveInspect(CommContracts.Inspect inspect)
        {
            DAL.Inspect temp = new DAL.Inspect();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Inspect, DAL.Inspect>();
                });
                var mapper = config.CreateMapper();

                temp = mapper.Map<DAL.Inspect>(inspect);

                ctx.Inspects.Add(temp);

                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return true;
        }
    }
}