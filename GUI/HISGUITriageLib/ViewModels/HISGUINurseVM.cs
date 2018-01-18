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
using HISGUINurseLib;
using HISGUICore;
using System.Data;
using System.Windows.Input;
using Prism.Commands;

namespace HISGUINurseLib.ViewModels
{
    [Export]
    [Export("HISGUINurseVM", typeof(HISGUIVMBase))]
    class HISGUINurseVM : HISGUIVMBase
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
            this.RegionManager.RequestNavigate("DownRegion", "NurseWorkView");
        }
    }
}
