using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommContracts
{
    public class DoctorAdviceDetail
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 医嘱字典项ID
        /// </summary>
        public int DoctorAdviceItemID { get; set; }

        /// <summary>
        /// 总量
        /// </summary>
        public int TotalNum { get; set; }

        /// <summary>
        /// 单次用量
        /// </summary>
        public decimal SignalDose { get; set; }

        /// <summary>
        /// 医嘱组ID
        /// </summary>
        public int DoctorAdviceDetailGroupID { get; set; }


        /// <summary>
        /// 医嘱字典项
        /// </summary>
        public DoctorAdviceItem DoctorAdviceItem { get; set; }

        public override string ToString()
        {
            return DoctorAdviceItem.Name + " 每次" + SignalDose + DoctorAdviceItem.MinPackageUnit;
        }
    }
}
