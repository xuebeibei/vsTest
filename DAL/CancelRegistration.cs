using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace DAL
{
    /// <summary>
    /// 退号
    /// </summary>
    public class CancelRegistration
    {
        /// <summary>
        /// 退号ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 退号对应的挂号ID
        /// </summary>
        public int RegistrationID { get; set; }
        /// <summary>
        /// 退号对应的挂号单
        /// </summary>
        public virtual Registration Registration { get; set; }

        /// <summary>
        /// 退号时间
        /// </summary>
        public DateTime CancelTime { get; set; }

        /// <summary>
        /// 此记录最后的更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }
    }
    /// <summary>
    /// 我们通过如下映射来得到一对一的关系
    /// </summary>
    public class CancelRegistrationMap : EntityTypeConfiguration<CancelRegistration>
    {
        /// <summary>
        /// 
        /// </summary>
        public CancelRegistrationMap()
        {
            HasOptional(p => p.Registration).WithRequired();
        }
    }

}
