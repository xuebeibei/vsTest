using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DoctorAdviceBase
    {
        public bool UpdateChargeStatus(int AdviceID, CommContracts.ChargeStatusEnum chargeStatusEnum)
        {
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var tem = context.DoctorAdviceBases.Find(AdviceID);
                if (tem == null)
                    return false;

                tem.ChargeStatusEnum = (DAL.ChargeStatusEnum)chargeStatusEnum;
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
