﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Practices.ServiceLocation;
using Prism.Regions;
using HISGUICore;
using HISGUICore.MyContorls;
using HISGUINurseLib.ViewModels;
using System.Data;

namespace HISGUINurseLib.Views
{
    [Export]
    [Export("EditPatientMsgView", typeof(EditPatientMsgView))]
    public partial class EditPatientMsgView : HISGUIViewBase
    {
        public EditPatientMsgView()
        {
            InitializeComponent();
        }

        [Import]
        private HISGUINurseVM ImportVM
        {
            set { this.VM = value; }
        }
    }
}
