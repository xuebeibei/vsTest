using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommContracts
{
    public class DoctorClinicWorkPlan
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 二级科室ID
        /// </summary>
        public int LevelTwoDepartmentID { get; set; }

        /// <summary>
        /// 医生
        /// </summary>
        public string Doctor { get; set; }

        /// <summary>
        /// 号别名称
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// 时间段
        /// </summary>
        public string TimeBucket { get; set; }

        /// <summary>
        /// 医师服务费
        /// </summary>
        public decimal Fee { get; set; }

        /// <summary>
        /// 最大号源数量
        /// </summary>
        public int MaxNum { get; set; }

        /// <summary>
        /// 1周一，2周二，3周三，4周四，5周五，6周六，7周日
        /// </summary>
        public int Zhou { get; set; }
    }
}
