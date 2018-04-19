using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    [DataContract]
    public class Employee
    {
        public Employee()
        {
            Name = "";
        }


        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        [DataMember]
        public string Abbr { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [DataMember]
        public GenderEnum Gender { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        [DataMember]
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        [DataMember]
        public DateTime ModifiedDate { get; set; }

        public override bool Equals(object obj)
        {
            var em = obj as Employee;
            if (em == null)
                return false;
            if (em.ID == this.ID)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
