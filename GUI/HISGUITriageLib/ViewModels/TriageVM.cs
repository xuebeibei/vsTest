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
using HISGUITriageLib;
using HISGUICore;
using System.Data;
using System.Windows.Input;
using Prism.Commands;

namespace HISGUITriageLib.ViewModels
{
    [Export]
    [Export("TriageVM", typeof(HISGUIVMBase))]
    class TriageVM : HISGUIVMBase
    {
        public ICommand SelectDoctorCommand { get; set; }
        public ICommand EditPatientMsgCommand { get; set; }

        public override void RegisterCommands()
        {
            base.RegisterCommands();
            SelectDoctorCommand = new DelegateCommand(SelectDoctor);
            EditPatientMsgCommand = new DelegateCommand(EditPatientMsg);
        }

        //巡检点位管理
        public void SelectDoctor()
        {
            this.RegionManager.RequestNavigate("DownRegion", "SelectDoctorView");
        }

        public void EditPatientMsg()
        {
            this.RegionManager.RequestNavigate("DownRegion", "EditPatientMsgView");
        }

        public Dictionary<int, string> GetAllUnTriagePatient()
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.getAllRegistration();
        }
    }
}
