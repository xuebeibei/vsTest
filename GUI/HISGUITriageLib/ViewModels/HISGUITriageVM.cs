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
    [Export("HISGUITriageVM", typeof(HISGUIVMBase))]
    class HISGUITriageVM : HISGUIVMBase
    {
       // public ICommand TriageCommand { get; set; }

        public override void RegisterCommands()
        {
            base.RegisterCommands();
           // TriageCommand = new DelegateCommand(TriageManage);
        }

        //显示分诊界面
        public void TriageManage()
        {
            this.RegionManager.RequestNavigate("DownRegion", "TriageView");
        }
    }
}
