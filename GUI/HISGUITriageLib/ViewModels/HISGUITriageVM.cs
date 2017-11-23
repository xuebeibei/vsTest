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


namespace HISGUITriageLib.ViewModels
{
    [Export]
    [Export("HISGUITriageVM", typeof(HISGUIVMBase))]
    class HISGUITriageVM : HISGUIVMBase
    {
        
    }
}
