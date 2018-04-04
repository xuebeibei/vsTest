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

        public bool SaveJob(CommContracts.Job job)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Job, DAL.Job>();
                });
                var mapper = config.CreateMapper();

                DAL.Job temp = new DAL.Job();
                temp = mapper.Map<DAL.Job>(job);

                ctx.Jobs.Add(temp);
                try
                {
                    ctx.SaveChanges();
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    return false;
                }
            }
            return true;
        }

        public bool DeleteJob(int jobID)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Jobs.FirstOrDefault(m => m.ID == jobID);
                if (temp != null)
                {
                    ctx.Jobs.Remove(temp);
                }

                try
                {
                    ctx.SaveChanges();
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    return false;
                }
            }
            return true;
        }

        public bool UpdateJob(CommContracts.Job job)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var temp = ctx.Jobs.FirstOrDefault(m => m.ID == job.ID);
                if (temp != null)
                {
                    temp.Name = job.Name;
                    temp.JobGrade = (DAL.JobGradeEnum)job.JobGrade;
                    temp.PowerEnum = (DAL.PowerEnum)job.PowerEnum;
                    temp.JobType = (DAL.JobTypeEnum)job.JobType;
                }
                else
                {
                    return false;
                }

                try
                {
                    ctx.SaveChanges();
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    return false;
                }
            }
            return true;
        }
    }
}
