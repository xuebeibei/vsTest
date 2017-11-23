using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Patient
    {
        CommContracts.Patient patient;

        public Patient(CommContracts.Patient patient)
        {
            this.patient = patient;
        }
    }
}
