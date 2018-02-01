using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 药品字典
    public class Medicine : GoodsBase
    {
        public Medicine()
        {
            MedicineInStoreDetails = new List<MedicineInStoreDetail>();
            StoreRoomMedicineNums = new List<StoreRoomMedicineNum>();
            MedicineDoctorAdviceDetails = new List<MedicineDoctorAdviceDetail>();
        }

        public MedicineTypeEnum MedicineTypeEnum { get; set; }      // 药品类型
        public string Abbr1 { get; set; }                           // 别名1
        public string Abbr2 { get; set; }                           // 别名2
        public string Abbr3 { get; set; }                           // 别名3
        public DosageFormEnum DosageFormEnum { get; set; }          // 药品剂型   
        public string AdministrationRoute { get; set; }             // 给药方式
        public bool PoisonousHemp { get; set; }                     // 毒麻
        public bool Valuable { get; set; }                          // 贵重
        public bool EssentialDrugs { get; set; }                    // 基本药物
        public virtual ICollection<MedicineInStoreDetail> MedicineInStoreDetails { get; set; }
        public virtual ICollection<StoreRoomMedicineNum> StoreRoomMedicineNums { get; set; }
        public virtual ICollection<MedicineDoctorAdviceDetail> MedicineDoctorAdviceDetails { get; set; }
    }
}
