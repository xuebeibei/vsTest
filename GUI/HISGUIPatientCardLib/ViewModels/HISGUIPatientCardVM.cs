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
using HISGUIPatientCardLib;
using HISGUICore;
using System.Data;
using System.Windows.Input;
using Prism.Commands;

namespace HISGUIPatientCardLib.ViewModels
{
    [Export]
    [Export("HISGUIPatientCardVM", typeof(HISGUIVMBase))]
    class HISGUIPatientCardVM : HISGUIVMBase
    {
        public override void RegisterCommands()
        {
            base.RegisterCommands();
        }
    }
}
