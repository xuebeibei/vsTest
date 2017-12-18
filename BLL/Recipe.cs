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

        public bool SaveRecipe()
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var myRecipe = new DAL.Recipe();

                myRecipe.No = "123";
                myRecipe.RecipeTypeEnum = DAL.RecipeTypeEnum.PuTong;
                myRecipe.MedicalInstitution = "三河市燕郊镇开发区卫生院";
                myRecipe.ChargeTypeEnum = 1;
                myRecipe.RegistrationID = 1;
                myRecipe.ClinicalDiagnosis = "感冒发烧";
                myRecipe.SumOfMoney = 60.0;
                myRecipe.WriteTime = DateTime.Now;
                myRecipe.WriteUserID = 1;
                myRecipe.AuditorTime = DateTime.Now;
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
