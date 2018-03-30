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
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    return false;
                }
            }

            return true;
        }

        public bool UpdateExecuteEnum(int DoctorAdviceID, CommContracts.ExecuteEnum executeEnum)
        {
            using (DAL.HisContext context = new DAL.HisContext())
            {
                var tem = context.DoctorAdviceBases.Find(DoctorAdviceID);
                if (tem == null)
                    return false;

                tem.ExecuteEnum = (DAL.ExecuteEnum)executeEnum;
                try
                {
                    context.SaveChanges();
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    return false;
                }
            }

            return true;
        }
    }
}
