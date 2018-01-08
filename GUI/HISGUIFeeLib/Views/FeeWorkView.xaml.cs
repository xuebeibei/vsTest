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
using HISGUIFeeLib.ViewModels;
using System.Data;
using HISGUICore.MyContorls;

namespace HISGUIFeeLib.Views
{
    [Export]
    [Export("FeeWorkView", typeof(FeeWorkView))]
    public partial class FeeWorkView : HISGUIViewBase
    {
        public FeeWorkView()
        {
            InitializeComponent();
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIFeeVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            initVisibility();
            ShowList();
        }

        private void ShowList()
        {
            if (this.ClinicPatient.IsChecked.Value)
                ShowAllRegistration();
            else if (this.InHospitalPatient.IsChecked.Value)
                ShowAllInPatient();
        }

        private void FindChargeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PayFeeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReturnFeeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowAllRegistration()
        {
            var vm = this.DataContext as HISGUIFeeVM;

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary = vm?.GetClinicChargePatients();

            List<PatientMsgBox> list = new List<PatientMsgBox>();
            if (dictionary != null)
            {
                for (int i = 0; i < dictionary.Count; i++)
                {
                    // 实例化一个控件
                    list.Add(new PatientMsgBox(dictionary.ElementAt(i).Key, dictionary.ElementAt(i).Value));
                }

                this.AllChargeBillList.ItemsSource = list;
            }
        }

        private void ShowAllInPatient()
        {
            var vm = this.DataContext as HISGUIFeeVM;

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary = vm?.GetAllInHospitalChargePatient();

            List<PatientMsgBox> list = new List<PatientMsgBox>();
            if (dictionary != null)
            {
                for (int i = 0; i < dictionary.Count; i++)
                {
                    // 实例化一个控件
                    list.Add(new PatientMsgBox(dictionary.ElementAt(i).Key, dictionary.ElementAt(i).Value));
                }

                this.AllChargeBillList.ItemsSource = list;
            }
        }

        private void PayFeeBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ClinicPatient_Click(object sender, RoutedEventArgs e)
        {
            ShowList();
        }

        private void InHospitalPatient_Click(object sender, RoutedEventArgs e)
        {
            ShowList();
        }

        private void NotPay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HavePay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AutoReadChargeCheck_Click(object sender, RoutedEventArgs e)
        {
            initVisibility();
        }

        private void initVisibility()
        {
            if (this.AutoReadChargeCheck.IsChecked.HasValue)
            {
                if (this.AutoReadChargeCheck.IsChecked.Value)
                {
                    this.NotPay.Visibility = Visibility.Visible;
                    this.HavePay.Visibility = Visibility.Visible;
                    return;
                }
            }
            this.NotPay.Visibility = Visibility.Collapsed;
            this.HavePay.Visibility = Visibility.Collapsed;
        }
    }
}
