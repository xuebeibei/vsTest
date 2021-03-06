﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommContracts;
using System.ServiceModel;
using System.Collections;

namespace CommClient
{
    public class TherapyDoctorAdvice : DoctorAdviceBase
    {
        public CommContracts.TherapyDoctorAdvice GetTherapyDoctorAdvice(int Id)
        {
            return client.GetTherapyDoctorAdvice(Id);
        }

        public bool SaveTherapyDoctorAdvice(CommContracts.TherapyDoctorAdvice therapy)
        {
            return client.SaveTherapyDoctorAdvice(therapy);
        }

        public List<CommContracts.TherapyDoctorAdvice> getAllTherapyDoctorAdvice(int RegistrationID)
        {
            return client.getAllTherapyDoctorAdvice(RegistrationID);
        }

        public List<CommContracts.TherapyDoctorAdvice> getAllInHospitalTherapyDoctorAdvice(int InpatientID)
        {
            return client.getAllInHospitalTherapyDoctorAdvice(InpatientID);
        }
    }
}
