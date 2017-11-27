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
using HISGUIClinicDoctorLib;
using HISGUICore;
using System.Data;

namespace HISGUIClinicDoctorLib.ViewModels
{
    [Export]
    [Export("HISGUIClinicDoctorVM", typeof(HISGUIVMBase))]
    class HISGUIClinicDoctorVM : HISGUIVMBase
    {
    }
}
