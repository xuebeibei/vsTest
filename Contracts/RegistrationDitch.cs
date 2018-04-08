using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
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
        一级 = 1,
        /// <summary>
        /// 二级
        /// </summary>
        二级 = 2,
        /// <summary>
        /// 三级
        /// </summary>
        三级 = 3,
        /// <summary>
        /// 四级
        /// </summary>
        四级 = 4,
        /// <summary>
        /// 五级
        /// </summary>
        五级 = 5,
        /// <summary>
        /// 六级
        /// </summary>
        六级 = 6,
        /// <summary>
        /// 七级
        /// </summary>
        七级 = 7,
        /// <summary>
        /// 八级
        /// </summary>
        八级 = 8,
        /// <summary>
        /// 九极
        /// </summary>
        九极 = 9,
        /// <summary>
        /// 十级
        /// </summary>
        十级 = 10
    }

    /// <summary>
    /// 放号渠道是否可用
    /// </summary>
    public enum RegistrationDitchStatusEnum
    {

        /// <summary>
        /// 禁用
        /// </summary>
        禁用 = 0,
        /// <summary>
        /// 可用
        /// </summary>
        可用 = 1
    }

    /// <summary>
    /// 放号渠道
    /// </summary>
    [DataContract]
    public class RegistrationDitch
    {
        public RegistrationDitch()
        {
            this.Status = RegistrationDitchStatusEnum.可用;
            this.Priority = PriorityEnum.一级;
        }

        /// <summary>
        /// 放号渠道ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 放号渠道名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 放号时间
        /// </summary>
        [DataMember]
        public string StartTime { get; set; }
        /// <summary>
        /// 放号渠道优先级
        /// </summary>
        [DataMember]
        public PriorityEnum Priority { get; set; }
        /// <summary>
        /// 放号渠道占比
        /// </summary>
        [DataMember]
        public int Proportion { get; set; }
        /// <summary>
        /// 放号渠道状态
        /// </summary>
        [DataMember]
        public RegistrationDitchStatusEnum Status { get; set; }

    }
}
