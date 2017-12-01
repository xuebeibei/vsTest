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
    [Export("EditPatientMsgVM", typeof(HISGUIVMBase))]
    class EditPatientMsgVM : HISGUIVMBase
    {
        public ICommand EditPatientMsgOKCommand { get; set; }
        public ICommand EditPatientMsgCancelCommand { get; set; }

        public override void RegisterCommands()
        {
            base.RegisterCommands();
            EditPatientMsgOKCommand = new DelegateCommand(EditPatientMsgOK);
            EditPatientMsgCancelCommand = new DelegateCommand(EditPatientMsgCancel);
        }

        public void EditPatientMsgOK()
        {
            this.RegionManager.RequestNavigate("DownRegion", "TriageView");
        }

        public void EditPatientMsgCancel()
        {
            this.RegionManager.RequestNavigate("DownRegion", "TriageView");
        }

    }
}
