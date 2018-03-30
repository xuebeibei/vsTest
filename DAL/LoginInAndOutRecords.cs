using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“LoginInAndOutRecords”的 XML 注释
    public class LoginInAndOutRecords : MyTableBase
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“LoginInAndOutRecords”的 XML 注释
    {
        /// <summary>
        /// 登录地址
        /// </summary>
        public string LoginMachineCode { get; set; }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“LoginInAndOutRecords.LoginInOrLoginOut”的 XML 注释
        public bool LoginInOrLoginOut { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“LoginInAndOutRecords.LoginInOrLoginOut”的 XML 注释
    }
}
