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
using AutoMapper;

namespace BLL
{
    public class Therapy
    {
        public CommContracts.Therapy GetTherapy(int Id)
        {
            CommContracts.Therapy therapy = new CommContracts.Therapy();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.Therapies
                            where t.ID == Id
                            select t;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Therapy, CommContracts.Therapy>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    therapy = mapper.Map<CommContracts.Therapy>(tem);
                    break;
                }
            }
            return therapy;
        }

        public bool SaveTherapy(CommContracts.Therapy therapy)
        {
            DAL.Therapy temp = new DAL.Therapy();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Therapy, DAL.Therapy> ();
                });
                var mapper = config.CreateMapper();

                temp = mapper.Map<DAL.Therapy>(therapy);

                ctx.Therapies.Add(temp);

                try
                {
                    ctx.SaveChanges();
                }
                catch(Exception ex)
                {
                    return false;
                }
                
            }
            return true;
        }

        public List<CommContracts.Therapy> getAllTherapy(int RegistrationID)
        {
            List<CommContracts.Therapy> list = new List<CommContracts.Therapy>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.Therapies
                            where t.RegistrationID == RegistrationID
                            select t;
                foreach (DAL.Therapy th in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Therapy, CommContracts.Therapy>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Therapy temp = mapper.Map<CommContracts.Therapy>(th);
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<CommContracts.Therapy> getAllInHospitalTherapy(int InpatientID)
        {
            List<CommContracts.Therapy> list = new List<CommContracts.Therapy>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from t in ctx.Therapies
                            where t.InpatientID == InpatientID
                            select t;
                foreach (DAL.Therapy th in query)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<DAL.Therapy, CommContracts.Therapy>();
                    });
                    var mapper = config.CreateMapper();

                    CommContracts.Therapy temp = mapper.Map<CommContracts.Therapy>(th);
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
