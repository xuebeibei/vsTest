using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 病历
    public class MedicalRecord
    {
        public MedicalRecord()
        {

        }

        public int ID { get; set; }  // ID
        public string NO { get; set; } // 病历号
        public MedicalRecordEnum MedicalRecordEnum { get; set; }  // 类别
        public int RegistrationID { get; set; }                   // 门诊ID
        public DateTime? WriteTime { get; set; }                   // 编辑时间
        public int WriteUserID { get; set; }                      // 编写人的用户ID
        public string ContentXml { get; set; }                    // 内容xml

        public virtual Registration Registration { get; set; }
    }
}
