using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Job
    {
        public List<CommContracts.Job> GetAllJob(string strName = "")
        {
            List<CommContracts.Job> list = new List<CommContracts.Job>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from a in ctx.Jobs
                            where a.Name.StartsWith(strName) 
                            select a;
                foreach (DAL.Job ass in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Job, CommContracts.Job>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Job temp = mapper.Map<CommContracts.Job>(ass);
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
