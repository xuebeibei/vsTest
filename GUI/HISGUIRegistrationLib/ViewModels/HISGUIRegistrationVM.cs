using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Xml;
using HISGUIRegistrationLib;
using HISGUICore;
using System.Data;
using System.Windows.Input;
using Prism.Commands;
using CommContracts;

namespace HISGUIRegistrationLib.ViewModels
{
    [Export]
    [Export("HISGUIRegistrationVM", typeof(HISGUIVMBase))]
    class HISGUIRegistrationVM : HISGUIVMBase   
    {

        public List<CommContracts.LevelOneDepartment> GetAllLevelOneDepartment()
        {
            CommClient.LevelOneDepartment LevelOneDepartment = new CommClient.LevelOneDepartment();

            return LevelOneDepartment.GetAllLevelOneDepartment();
        }

        public List<CommContracts.DoctorClinicWorkPlan> GetAllDoctorClinicWorkPlan()
        {
            CommClient.DoctorClinicWorkPlan DoctorClinicWorkPlan = new CommClient.DoctorClinicWorkPlan();

            return DoctorClinicWorkPlan.GetAllDoctorClinicWorkPlan();
        }

        public bool SaveClinicRegistration(CommContracts.ClinicRegistration clinicRegistration)
        {
            CommClient.ClinicRegistration clinicRegistrationClient = new CommClient.ClinicRegistration();
            return clinicRegistrationClient.SaveClinicRegistration(clinicRegistration);
        }

        public List<CommContracts.ClinicRegistration> GetAllClinicRegistration()
        {
            CommClient.ClinicRegistration ClinicRegistration = new CommClient.ClinicRegistration();

            return ClinicRegistration.GetAllClinicRegistration();
        }

    }
}
