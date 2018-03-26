using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoginInAndOutRecords : MyTableBase
    {
        /// <summary>
        /// 登录地址
        /// </summary>
        public string LoginMachineCode { get; set; }

        public bool LoginInOrLoginOut { get; set; }
    }
}
