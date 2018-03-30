using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 用药处方医嘱明细
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdviceDetail”的 XML 注释
    public class MedicineDoctorAdviceDetail : DoctorAdviceDetailBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdviceDetail”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdviceDetail.MedicineID”的 XML 注释
        public int MedicineID { get; set; }               // 药品
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdviceDetail.MedicineID”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdviceDetail.MedicineDoctorAdviceID”的 XML 注释
        public int MedicineDoctorAdviceID { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdviceDetail.MedicineDoctorAdviceID”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdviceDetail.MedicineDoctorAdvice”的 XML 注释
        public virtual MedicineDoctorAdvice MedicineDoctorAdvice { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdviceDetail.MedicineDoctorAdvice”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdviceDetail.Medicine”的 XML 注释
        public virtual Medicine Medicine { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdviceDetail.Medicine”的 XML 注释
    }
}
