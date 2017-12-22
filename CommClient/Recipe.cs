using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommContracts;
using System.ServiceModel;
using System.Collections;

namespace CommClient
{
    public class Recipe
    {
        private ILoginService client;

        private CommContracts.Recipe recipe;

        public int ID { get; set; }                               // 处方ID
        public string No { get; set; }                            // 处方编号
        public RecipeTypeEnum RecipeTypeEnum { get; set; }        // 处方类型
        public string MedicalInstitution { get; set; }            // 医疗机构名称
        public int ChargeTypeEnum { get; set; }                   // 费别,*是否存在在门诊和住院中，待定
        public int RegistrationID { get; set; }                   // 门诊ID
        public int InpatientID { get; set; }                      // 住院ID
        public string ClinicalDiagnosis { get; set; }             // 临床诊断
        public string PatientsIDCardNum { get; set; }             // 患者身份证    -- 麻醉和精一处方
        public string ProxyIDCardNum { get; set; }                // 代办人身份证  -- 麻醉和精一处方
        public string ProxyName { get; set; }                     // 代办人姓名    -- 麻醉和精一处方

        public double SumOfMoney { get; set; }                    // 金额
        public DateTime WriteTime { get; set; }                   // 开具时间
        public int WriteUserID { get; set; }                      // 开具医生

        public int AuditorUserID { get; set; }                    // 审核、调配，核对、发药人员
        public DateTime AuditorTime { get; set; }                 // 审核、调配，核对、发药时间

        public virtual ICollection<RecipeDetail> RecipeDetails { get; set; }

        public Recipe()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
            RecipeDetails = new List<RecipeDetail>();
            recipe = new CommContracts.Recipe();
        }

        public bool SaveRecipe()
        {
            recipe.ID = this.ID;
            recipe.No = this.No;
            recipe.RecipeTypeEnum = this.RecipeTypeEnum;
            recipe.MedicalInstitution = this.MedicalInstitution;
            recipe.ChargeTypeEnum = this.ChargeTypeEnum;
            recipe.RegistrationID = this.RegistrationID;
            recipe.InpatientID = this.InpatientID;
            recipe.ClinicalDiagnosis = this.ClinicalDiagnosis;
            recipe.PatientsIDCardNum = this.PatientsIDCardNum;
            recipe.ProxyIDCardNum = this.ProxyIDCardNum;
            recipe.ProxyName = this.ProxyName;
            recipe.SumOfMoney = this.SumOfMoney;
            recipe.WriteTime = this.WriteTime;
            recipe.WriteUserID = this.WriteUserID;
            recipe.AuditorTime = this.AuditorTime;
            recipe.AuditorUserID = this.AuditorUserID;


            return client.SaveRecipe(recipe); 
        }
    }
}
