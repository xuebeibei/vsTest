using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SignalItem
    {
        public SignalItem()
        {
            SignalSources = new List<SignalSource>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public SignalTimeEnum SignalTimeEnum { get; set; }
        public int MaxNum { get; set; }
        public decimal SellPrice { get; set; }

        public virtual ICollection<SignalSource> SignalSources { get; set; }
    }
}
