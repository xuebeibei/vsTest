using System;
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
using HISGUIClinicDoctorLib.ViewModels;
using System.Data;

namespace HISGUIClinicDoctorLib.Views
{
    [Export]
    [Export("ClinicRecipe", typeof(ClinicRecipe))]
    public partial class ClinicRecipe : HISGUIViewBase
    {
        public ClinicRecipe()
        {
            InitializeComponent();
        }

        [Import]
        private HISGUIClinicDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void SelectTempletBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SelectDrugBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CopyRecipeBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
