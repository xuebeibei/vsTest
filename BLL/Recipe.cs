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
                //var config = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<CommContracts.Recipe, DAL.Recipe>();
                //});
                //var mapper = config.CreateMapper();

                //DAL.Recipe temp = mapper.Map<DAL.Recipe>(recipe);// 提示失败

                //ctx.Recipes.Add(temp);

                //try
                //{
                //    ctx.SaveChanges();
                //}
                //catch (Exception ex)
                //{
                //    return false;
                //}

                var myRecipe = new DAL.Recipe();
                myRecipe.No = recipe.No;
                myRecipe.RecipeTypeEnum = (DAL.RecipeTypeEnum)recipe.RecipeTypeEnum;
                myRecipe.RecipeContentEnum = (DAL.RecipeContentEnum)recipe.RecipeContentEnum;
                myRecipe.MedicalInstitution = recipe.MedicalInstitution;
                myRecipe.ChargeTypeEnum = recipe.ChargeTypeEnum;
                myRecipe.RegistrationID = recipe.RegistrationID;
                myRecipe.ClinicalDiagnosis = recipe.ClinicalDiagnosis;
                myRecipe.SumOfMoney = recipe.SumOfMoney;
                myRecipe.WriteTime = recipe.WriteTime;
                myRecipe.WriteUserID = recipe.WriteUserID;


                List<DAL.RecipeDetail> list = new List<DAL.RecipeDetail>();
                foreach (var tem in recipe.RecipeDetails)
                {
                    DAL.RecipeDetail recipeDetail = new DAL.RecipeDetail();
                    recipeDetail.GroupNum = tem.GroupNum;
                    recipeDetail.MedicineID = tem.MedicineID;
                    recipeDetail.SingleDose = tem.SingleDose;
                    recipeDetail.Usage = (DAL.UsageEnum)tem.Usage;
                    recipeDetail.DDDS = (DAL.DDDSEnum)tem.DDDS;
                    recipeDetail.DaysNum = tem.DaysNum;
                    recipeDetail.IntegralDose = tem.IntegralDose;
                    recipeDetail.Illustration = tem.Illustration;

                    list.Add(recipeDetail);
                }

                myRecipe.RecipeDetails = list;

                ctx.Recipes.Add(myRecipe);
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
            return getAllRecipes(RegistrationID, DAL.RecipeContentEnum.XiChengYao);
        }

        public List<CommContracts.Recipe> getAllZhong(int RegistrationID)
        {
            return getAllRecipes(RegistrationID, DAL.RecipeContentEnum.ZhongYao);
        }

        private List<CommContracts.Recipe> getAllRecipes(int RegistrationID, DAL.RecipeContentEnum recipeContentEnum)
        {
            List<CommContracts.Recipe> list = new List<CommContracts.Recipe>();
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var query = from r in context.Recipes
                            where r.RegistrationID == RegistrationID && 
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
    }
}
