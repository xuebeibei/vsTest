using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 病历
    /// </summary>
    public class MedicalRecord
    {
        /// <summary>
        /// 
        /// </summary>
        public MedicalRecord()
        {

        }

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 病历号
        /// </summary>
        public string NO { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public MedicalRecordEnum MedicalRecordEnum { get; set; }
        /// <summary>
        /// 门诊ID
        /// </summary>
        public int RegistrationID { get; set; }
        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime? WriteTime { get; set; }
        /// <summary>
        /// 编写人的用户ID
        /// </summary>
        public int WriteUserID { get; set; }
        /// <summary>
        /// 内容xml
        /// </summary>
        public string ContentXml { get; set; }                    

        /// <summary>
        /// 门诊
        /// </summary>
        public virtual Registration Registration { get; set; }
    }
}
