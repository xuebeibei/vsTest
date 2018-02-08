using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 药品字典
    /// </summary>
    public class Medicine : GoodsBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Medicine()
        {
            MedicineInStoreDetails = new List<MedicineInStoreDetail>();
            StoreRoomMedicineNums = new List<StoreRoomMedicineNum>();
            MedicineDoctorAdviceDetails = new List<MedicineDoctorAdviceDetail>();
        }

        /// <summary>
        /// 药品类型
        /// </summary>
        public MedicineTypeEnum MedicineTypeEnum { get; set; }
        /// <summary>
        /// 别名1
        /// </summary>
        public string Abbr1 { get; set; }
        /// <summary>
        /// 别名2
        /// </summary>
        public string Abbr2 { get; set; }
        /// <summary>
        /// 别名3
        /// </summary>
        public string Abbr3 { get; set; }
        /// <summary>
        /// 药品剂型
        /// </summary>
        public DosageFormEnum DosageFormEnum { get; set; }
        /// <summary>
        /// 给药方式
        /// </summary>
        public string AdministrationRoute { get; set; }
        /// <summary>
        /// 毒麻
        /// </summary>
        public bool PoisonousHemp { get; set; }
        /// <summary>
        /// 贵重
        /// </summary>
        public bool Valuable { get; set; }
        /// <summary>
        /// 基本药物
        /// </summary>
        public bool EssentialDrugs { get; set; }
        /// <summary>
        /// 药品入库单明细列表
        /// </summary>
        public virtual ICollection<MedicineInStoreDetail> MedicineInStoreDetails { get; set; }
        /// <summary>
        /// 药品库存列表
        /// </summary>
        public virtual ICollection<StoreRoomMedicineNum> StoreRoomMedicineNums { get; set; }
        /// <summary>
        /// 药品医嘱明细列表
        /// </summary>
        public virtual ICollection<MedicineDoctorAdviceDetail> MedicineDoctorAdviceDetails { get; set; }
    }
}
