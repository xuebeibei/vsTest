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
using HISGUIMenuLib;
using HISGUICore;


namespace HISGUIMenuLib.ViewModels
{
    [Export]
    [Export("HISGUIMenuVM", typeof(HISGUIVMBase))]
    class HISGUIMenuVM : HISGUIVMBase
    {
    }
}
