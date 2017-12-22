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
                var myRecipe = new DAL.Recipe();
                myRecipe.No = recipe.No;
                myRecipe.RecipeTypeEnum = DAL.RecipeTypeEnum.PuTong;
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
    }
}
