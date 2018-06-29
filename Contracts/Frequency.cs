using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommContracts
{
    public class Frequency
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 给药频次名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 拼音简写，用来搜索
        /// </summary>
        public string Abbr { get; set; }
        /// <summary>
        /// 五笔简写，用来搜索
        /// </summary>
        public string WuBi { get; set; }
        /// <summary>
        /// 实际计算参数
        /// </summary>
        public decimal CoefficientNum { get; set; }


        public override string ToString()
        {
            return Name;
        }
        public override bool Equals(object obj)
        {
            var tem = obj as Frequency;
            if (tem == null)
                return false;

            if (tem.ID == this.ID)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
