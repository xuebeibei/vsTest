using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RecipeChargeBill
    {
        public bool SaveRecipeChargeBill(CommContracts.RecipeChargeBill assay)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.RecipeChargeBill, DAL.RecipeChargeBill>().ForMember(x => x.RecipeChargeDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.RecipeChargeBill temp = new DAL.RecipeChargeBill();
                temp = mapper.Map<DAL.RecipeChargeBill>(assay);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.RecipeChargeDetail, DAL.RecipeChargeDetail>().ForMember(x => x.RecipeChargeBill, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.RecipeChargeDetail> list1 = assay.RecipeChargeDetails;
                List<DAL.RecipeChargeDetail> res = mapperDetail.Map<List<DAL.RecipeChargeDetail>>(list1); ;

                temp.RecipeChargeDetails = res;
                ctx.RecipeChargeBills.Add(temp);
                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                }
            }
            return true;
        }
    }
}
