using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class User
    {
        public User()
        {
            this.Username = "";
            this.Password = "";
            this.Status = LoginStatus.unknow;
            Registrations = new List<Registration>();
            Inpatients = new List<Inpatient>();
            PrePays = new List<PrePay>();
            DoctorAdviceBases = new List<DoctorAdviceBase>();
            StoreOperateBillBases = new List<StoreOperateBillBase>();
            ChargeBases = new List<ChargeBase>();
        }
        public enum LoginStatus { invalid, unknow, logout, login };
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginStatus Status { get; set; }
        public DateTime? LastLogin { get; set; }

        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; } // 所有门诊挂号
        public virtual ICollection<Inpatient> Inpatients { get; set; }       // 所有住院登记 

        public virtual ICollection<PrePay> PrePays { get; set; }

        public virtual ICollection<DoctorAdviceBase> DoctorAdviceBases { get; set; }

        public virtual ICollection<StoreOperateBillBase> StoreOperateBillBases { get; set; }

        public virtual ICollection<ChargeBase> ChargeBases { get; set; }
    }
}
