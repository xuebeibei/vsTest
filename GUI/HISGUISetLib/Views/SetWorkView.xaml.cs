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
using HISGUISetLib.ViewModels;
using System.Data;
using HISGUICore.MyContorls;

namespace HISGUISetLib.Views
{
    [Export]
    [Export("SetWorkView", typeof(SetWorkView))]
    public partial class SetWorkView : HISGUIViewBase    
    {
        public SetWorkView()
        {
            InitializeComponent();
        }

        [Import]
        private HISGUISetVM ImportVM
        {
            set { this.VM = value; }
        }

        private void InitVisable()
        {
            HospitalSetView.Visibility = Visibility.Collapsed;
            DepartmentView.Visibility = Visibility.Collapsed;
        }

        private void NewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void UserInfoSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void PasswordSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void HospitalInfoSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            HospitalSetView.Visibility = Visibility.Visible;
        }

        private void DepartmentSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            DepartmentView.Visibility = Visibility.Visible;
        }

        private void JobSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void StorehouseSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void SupplierSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void SickRoomSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void EmployeeSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void UserSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void PowerSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void DiagnosisSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void OtherServiceSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void AssaySet(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void InspectSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void MaterialSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void MedicineSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void OpinionSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }
    }
}
