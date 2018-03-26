using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    /// <summary>
    /// 登录状态
    /// </summary>
    public enum LoginStatus
    {
        /// <summary>
        /// 无效状态
        /// </summary>
        invalid,

        /// <summary>
        /// 未知状态
        /// </summary>
        unknow,

        /// <summary>
        /// 登出状态
        /// </summary>
        logout,

        /// <summary>
        /// 登录状态
        /// </summary>
        login
    };

    /// <summary>
    /// 客户端用户
    /// </summary>
    public class User
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public User()
        {
            this.Username = "";
            this.Password = "";
            this.Status = LoginStatus.unknow;
            Registrations = new List<Registration>();
            //Inpatients = new List<Inpatient>();
            PrePays = new List<PrePay>();
            DoctorAdviceBases = new List<DoctorAdviceBase>();
            StoreOperateBillBases = new List<StoreOperateBillBase>();
            ChargeBases = new List<ChargeBase>();
            InHospitalApplys = new List<InHospitalApply>();
            MyTableBases = new List<MyTableBase>();
        }

        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 账户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 登录状态
        /// </summary>
        public LoginStatus Status { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLogin { get; set; }


        /// <summary>
        /// 关联员工
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// 员工
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// 所有门诊挂号
        /// </summary>
        public virtual ICollection<Registration> Registrations { get; set; }
        //public virtual ICollection<Inpatient> Inpatients { get; set; }       // 所有住院登记 

        /// <summary>
        /// 所有预付款
        /// </summary>
        public virtual ICollection<PrePay> PrePays { get; set; }

        /// <summary>
        /// 所有医嘱
        /// </summary>
        public virtual ICollection<DoctorAdviceBase> DoctorAdviceBases { get; set; }

        /// <summary>
        /// 所有用户相关
        /// </summary>
        public virtual ICollection<MyTableBase> MyTableBases { get; set; }

        /// <summary>
        /// 所有药品操作
        /// </summary>
        public virtual ICollection<StoreOperateBillBase> StoreOperateBillBases { get; set; }

        /// <summary>
        /// 所有收费操作
        /// </summary>
        public virtual ICollection<ChargeBase> ChargeBases { get; set; }

        /// <summary>
        /// 所有住院申请
        /// </summary>
        public virtual ICollection<InHospitalApply> InHospitalApplys { get; set; }
    }
}
