using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 用药处方医嘱
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdvice”的 XML 注释
    public class MedicineDoctorAdvice : DoctorAdviceBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdvice”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdvice.MedicineDoctorAdvice()”的 XML 注释
        public MedicineDoctorAdvice()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdvice.MedicineDoctorAdvice()”的 XML 注释
        {
            MedicineDoctorAdviceDetails = new List<MedicineDoctorAdviceDetail>();
            MedicineCharges = new List<MedicineCharge>();
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdvice.RecipeContentEnum”的 XML 注释
        public DoctorAdviceContentEnum RecipeContentEnum { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdvice.RecipeContentEnum”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdvice.MedicineDoctorAdviceDetails”的 XML 注释
        public virtual ICollection<MedicineDoctorAdviceDetail> MedicineDoctorAdviceDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdvice.MedicineDoctorAdviceDetails”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdvice.MedicineCharges”的 XML 注释
        public virtual ICollection<MedicineCharge> MedicineCharges { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdvice.MedicineCharges”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdvice.InjectionBills”的 XML 注释
        public virtual ICollection<InjectionBill> InjectionBills { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MedicineDoctorAdvice.InjectionBills”的 XML 注释
    }
}
