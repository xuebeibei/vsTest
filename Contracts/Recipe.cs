using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum RecipeTypeEnum { XiChengYao, ZhaoYao };

    [DataContract]
    public class Recipe
    {
        public Recipe()
        {
            this.RecipeTypeEnum = RecipeTypeEnum.XiChengYao;
            RecipeDetails = new List<RecipeDetail>();
        }

        [DataMember]
        public int ID { get; set; }                               // 处方ID
        [DataMember]
        public string No { get; set; }                            // 处方编号
        [DataMember]
        public RecipeTypeEnum RecipeTypeEnum { get; set; }        // 处方类型
        [DataMember]
        public string MedicalInstitution { get; set; }            // 医疗机构名称
        [DataMember]
        public int ChargeTypeEnum { get; set; }                   // 费别,*是否存在在门诊和住院中，待定
        [DataMember]
        public int RegistrationID { get; set; }                   // 门诊ID
        [DataMember]
        public int InpatientID { get; set; }                      // 住院ID
        [DataMember]
        public string ClinicalDiagnosis { get; set; }             // 临床诊断
        [DataMember]
        public string PatientsIDCardNum { get; set; }             // 患者身份证    -- 麻醉和精一处方
        [DataMember]
        public string ProxyIDCardNum { get; set; }                // 代办人身份证  -- 麻醉和精一处方
        [DataMember]
        public string ProxyName { get; set; }                     // 代办人姓名    -- 麻醉和精一处方
        [DataMember]
        public double SumOfMoney { get; set; }                    // 金额
        [DataMember]
        public DateTime WriteTime { get; set; }                   // 开具时间
        [DataMember]
        public int WriteUserID { get; set; }                      // 开具医生
        [DataMember]
        public virtual ICollection<RecipeDetail> RecipeDetails { get; set; }

        public string ToTipString()
        {
            string str = "";

            str = "处方号：" + this.No + "  " +
                "处方日期：" + this.WriteTime.ToString() + "  " +
                "就诊科室：" + "外科" + "  " +
                "看诊医师：" + "张医生" + "  ";
            return str;
        }
    }
}
