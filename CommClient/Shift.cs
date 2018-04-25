using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommClient
{
    public class Shift : MyTableBase
    {
        public Shift()
        {
        }

        public List<CommContracts.Shift> GetAllShift(string strName = "")
        {
            return client.GetAllShift(strName);
        }

        public bool UpdateShift(CommContracts.Shift Shift)
        {
            return client.UpdateShift(Shift);
        }

        public bool SaveShift(CommContracts.Shift Shift)
        {
            return client.SaveShift(Shift);
        }

        public bool DeleteShift(int ShiftID)
        {
            return client.DeleteShift(ShiftID);
        }
    }
}
