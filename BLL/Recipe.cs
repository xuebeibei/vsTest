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
        public bool SaveRecipe()
        {
            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var myRecipe = ctx.Recipes.FirstOrDefault();
                if (myRecipe == null)
                {
                    myRecipe = new DAL.Recipe();
                }
                //       public int ID { get; set; }                               // 处方ID
                //public string No { get; set; }                            // 处方编号
                //public RecipeTypeEnum RecipeTypeEnum { get; set; }        // 处方类型
                //public string MedicalInstitution { get; set; }            // 医疗机构名称
                //public int ChargeTypeEnum { get; set; }                   // 费别,*是否存在在门诊和住院中，待定
                //public int RegistrationID { get; set; }                   // 门诊ID
                //public int InpatientID { get; set; }                      // 住院ID
                //public string ClinicalDiagnosis { get; set; }             // 临床诊断
                //public string PatientsIDCardNum { get; set; }             // 患者身份证    -- 麻醉和精一处方
                //public string ProxyIDCardNum { get; set; }                // 代办人身份证  -- 麻醉和精一处方
                //public string ProxyName { get; set; }                     // 代办人姓名    -- 麻醉和精一处方

                //public double SumOfMoney { get; set; }                    // 金额
                //public DateTime WriteTime { get; set; }                   // 开具时间
                //public int WriteUserID { get; set; }                      // 开具医生

                //public int AuditorUserID { get; set; }                    // 审核、调配，核对、发药人员
                //public DateTime AuditorTime { get; set; }                 // 审核、调配，核对、发药时间

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
