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
using HISGUITriageLib.Views;

namespace HISGUITriageLib.ViewModels
{
    [Export]
    [Export("SelectDoctorVM", typeof(HISGUIVMBase))]
    class SelectDoctorVM : HISGUIVMBase
    {
        public ICommand SelectDoctorOKCommand { get; set; }
        public ICommand SelectDoctorCancelCommand { get; set; }

        public override void RegisterCommands()
        {
            base.RegisterCommands();
            SelectDoctorOKCommand = new DelegateCommand(SelectDoctorOK);
            SelectDoctorCancelCommand = new DelegateCommand(SelectDoctorCancel);
        }

        public void SelectDoctorOK()
        {
            this.RegionManager.RequestNavigate("DownRegion", "TriageView");
        }

        public void SelectDoctorCancel()
        {
            this.RegionManager.RequestNavigate("DownRegion", "TriageView");
        }

        public List<CommContracts.Employee> getAllDoctor()
        {
            List<CommContracts.Employee> list = new List<CommContracts.Employee>();

            CommClient.Employee myd = new CommClient.Employee();
            list = myd.getAllDoctor();
            return list;
        }

    }

}
