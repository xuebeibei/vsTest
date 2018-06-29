using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommContracts
{
    public class DiagnoseItem
    {
        /// <summary>
        /// 诊断ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 诊断名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 诊断名称的拼音缩写，用来搜索
        /// </summary>
        public string Abbr { get; set; }
    }
}
