using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 渠道的优先级
    /// 序号由小到大排列，数字越大，优先级越小
    /// </summary>
    public enum PriorityEnum
    {
        /// <summary>
        /// 一级，最高级
        /// </summary>
        one = 1,
        /// <summary>
        /// 二级
        /// </summary>
        two = 2,
        /// <summary>
        /// 三级
        /// </summary>
        three = 3,
        /// <summary>
        /// 四级
        /// </summary>
        four = 4,
        /// <summary>
        /// 五级
        /// </summary>
        five = 5,
        /// <summary>
        /// 六级
        /// </summary>
        six = 6,
        /// <summary>
        /// 七级
        /// </summary>
        seven = 7,
        /// <summary>
        /// 八级
        /// </summary>
        eight = 8,
        /// <summary>
        /// 九极
        /// </summary>
        nine = 9,
        /// <summary>
        /// 十级
        /// </summary>
        ten = 10
    }

    /// <summary>
    /// 放号渠道是否可用
    /// </summary>
    public enum RegistrationDitchStatusEnum
    {

        /// <summary>
        /// 禁用
        /// </summary>
        IsError = 0,
        /// <summary>
        /// 可用
        /// </summary>
        IsOk = 1
    }



    /// <summary>
    /// 放号渠道
    /// </summary>
    public class RegistrationDitch
    {
        /// <summary>
        /// 放号渠道ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 放号渠道名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 放号时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 放号渠道优先级
        /// </summary>
        public PriorityEnum Priority { get; set; }
        /// <summary>
        /// 放号渠道占比
        /// </summary>
        public int Proportion { get; set; }
        /// <summary>
        /// 放号渠道状态
        /// </summary>
        public RegistrationDitchStatusEnum Status { get; set; }

    }
}
