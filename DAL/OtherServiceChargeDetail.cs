using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 其他医嘱收费单明细
    public class OtherServiceChargeDetail : ChargeDetailBase
    {
        public int OtherServiceID { get; set; }               // 其他项目
        public int OtherServiceChargeID { get; set; }

        public virtual OtherServiceCharge OtherServiceCharge { get; set; }
        public virtual OtherServiceItem OtherService { get; set; }
    }
}
