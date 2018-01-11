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
    public class Recipe
    {
        public void ReadRecipe()
        {
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var recipe = context.Recipes.Find(3);
            }
        }

        public bool SaveRecipe(CommContracts.Recipe recipe)
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CommContracts.Recipe, DAL.Recipe>().ForMember(x => x.RecipeDetails, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                DAL.Recipe temp = new DAL.Recipe();
                temp = mapper.Map<DAL.Recipe>(recipe);

                var configDetail = new MapperConfiguration(ctr =>
                {
                    ctr.CreateMap<CommContracts.RecipeDetail, DAL.RecipeDetail>().ForMember(x => x.Recipe, opt => opt.Ignore());
                });
                var mapperDetail = configDetail.CreateMapper();

                List<CommContracts.RecipeDetail> list1 = recipe.RecipeDetails;
                List<DAL.RecipeDetail> res = mapperDetail.Map<List<DAL.RecipeDetail>>(list1); ;

                temp.RecipeDetails = res;
                ctx.Recipes.Add(temp);
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

        public List<CommContracts.Recipe> getAllXiCheng(int RegistrationID)
        {
            return getAllRecipes(RegistrationID, 0, DAL.RecipeContentEnum.XiChengYao);
        }

        public List<CommContracts.Recipe> getAllZhong(int RegistrationID)
        {
            return getAllRecipes(RegistrationID, 0, DAL.RecipeContentEnum.ZhongYao);
        }

        private List<CommContracts.Recipe> getAllRecipes(int RegistrationID, int InpatientID, DAL.RecipeContentEnum recipeContentEnum)
        {
            List<CommContracts.Recipe> list = new List<CommContracts.Recipe>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from r in context.Recipes
                            where r.RegistrationID == RegistrationID &&
                            r.InpatientID == InpatientID &&
                            r.RecipeContentEnum == recipeContentEnum
                            select r;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DAL.Recipe, CommContracts.Recipe>();
                });
                var mapper = config.CreateMapper();


                foreach (var tem in query)
                {
                    var recipe = mapper.Map<CommContracts.Recipe>(tem);

                    list.Add(recipe);
                }

            }
            return list;
        }


        public List<CommContracts.Recipe> getAllInHospitalXiCheng(int InpatientID)
        {
            return getAllRecipes(0, InpatientID, DAL.RecipeContentEnum.XiChengYao);
        }

        public List<CommContracts.Recipe> getAllInHospitalZhong(int InpatientID)
        {
            return getAllRecipes(0, InpatientID, DAL.RecipeContentEnum.ZhongYao);
        }

        public bool UpdateChargeStatus(int RecipeID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var tem = context.Recipes.Find(RecipeID);
                if (tem == null)
                    return false;

                tem.ChargeStatusEnum = (DAL.ChargeStatusEnum)chargeStatusEnum;
                try
                {
                    context.SaveChanges();   
                }
                catch(Exception ex)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
