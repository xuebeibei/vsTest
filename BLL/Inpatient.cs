using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Inpatient
    {
        public Dictionary<int, string> GetAllInPatient()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            using (DAL.HisContext ctx = new DAL.HisContext())
            {
                var query = from r in ctx.Inpatients
                            select r;

                foreach (DAL.Inpatient tem in query)
                {
                    string str = tem.ToString();
                    dictionary.Add(tem.ID, str);
                }
            }

            return dictionary;
        }
    }
}
