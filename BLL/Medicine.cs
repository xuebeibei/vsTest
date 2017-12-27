using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Medicine
    {
        public List<CommContracts.Medicine> getAllMedicine()
        {
            List<CommContracts.Medicine> list = new List<CommContracts.Medicine>();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from m in ctx.Medicines
                            select m;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Medicine, CommContracts.Medicine>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.Medicine tem in query)
                {
                    var dto = mapper.Map<CommContracts.Medicine>(tem);
                    list.Add(dto);
                }
            }
            return list;
        }

        public CommContracts.Medicine GetMedicine(int id)
        {
            CommContracts.Medicine medicine = new CommContracts.Medicine();
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from m in ctx.Medicines
                            where m.ID == id 
                            select m;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Medicine, CommContracts.Medicine>();
                });
                var mapper = config.CreateMapper();

                foreach (DAL.Medicine tem in query)
                {
                    medicine = mapper.Map<CommContracts.Medicine>(tem);
                    break;
                }
            }

            return medicine;
        }


    }
}
