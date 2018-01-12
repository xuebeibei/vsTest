using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommContracts
{
    public enum GenderEnum { man, woman };
    public enum VolkEnum { hanzu, other };

    [DataContract]
    public class Patient
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public GenderEnum Gender { get; set; }

        [DataMember]
        public DateTime BirthDay { get; set; }

        [DataMember]
        public VolkEnum Volk { get; set; }

        //[DataMember]
        //public string Age
        //{
        //    get
        //    {
        //        DateTime dt1 = BirthDay;
        //        DateTime dt2 = DateTime.Now;

        //        string str = "";
        //        int Year = dt2.Year - dt1.Year;
        //        str = Year.ToString() + "岁";

        //        if (Year<3)
        //        {
        //            int Month = dt2.Month - dt1.Month;
        //            if(Month != 0)
        //            {
        //                str += Month.ToString() + "月";
        //            }
                    
        //        }
        //        // 求时间差
        //        return str;
        //    }
        //    set
        //    {
        //        return;
        //    }
        //}

    }
}
