using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 物资入库明细
    public class MaterialInStoreDetail : StoreOperateBillDetailBase
    {
        public MaterialInStoreDetail()
        {

        }
        public int MaterialID { get; set; }          // 对应物资字典
        public int MaterialInStoreID { get; set; }  // 入库单ID

        public virtual MaterialItem Material { get; set; }    // 物资字典外键
        public virtual MaterialInStore MaterialInStore { get; set; }   // 入库单外键
    }
}
