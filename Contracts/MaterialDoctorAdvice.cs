using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class MaterialDoctorAdvice : DoctorAdviceBase
    {
        public MaterialDoctorAdvice()
        {
        }
        [DataMember]
        public string ReCheckName { get; set; }
        [DataMember]
        public List<MaterialDoctorAdviceDetail> MaterialDoctorAdviceDetails { get; set; }

        public override string ToString()
        {
            string str = "";

            str = "处方号：" + this.NO + "  " +
                "处方日期：" + this.WriteTime.ToString() + "  " +
                "就诊科室：" + (this.WriteDoctorUser == null ? "" :
                (this.WriteDoctorUser.Employee == null ? "" :
                (this.WriteDoctorUser.Employee.Department == null ? "" : this.WriteDoctorUser.Employee.Department.Name)
                )
                ) + "  " +
                "看诊医师：" + (this.WriteDoctorUser == null ? "" :
                (this.WriteDoctorUser.Employee == null ? "" : this.WriteDoctorUser.Employee.Name)
                ) + "  ";
            return str;
        }
    }
}
