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
using System.Windows.Threading;

namespace HISGUIFeeLib.Views
{
    [Export]
    [Export("FeeWorkView", typeof(FeeWorkView))]
    public partial class FeeWorkView : HISGUIViewBase
    {
        protected DispatcherTimer ShowTimer;
        public FeeWorkView()
        {
            InitializeComponent();
            //show timer by_songgp
            ShowTimer = new System.Windows.Threading.DispatcherTimer();
            ShowTimer.Tick += new EventHandler(ShowCurTimer);//起个Timer一直获取当前时间
            ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            ShowTimer.Start();
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIFeeVM ImportVM
        {
            set { this.VM = value; }
        }
        private void ShowCurTimer(object sender, EventArgs e)
        {
            //"星期"+DateTime.Now.DayOfWeek.ToString(("d"))

            //获得星期几
            this.Tt.Text = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("zh-cn"));
            this.Tt.Text += " ";
            //获得年月日
            this.Tt.Text += DateTime.Now.ToString("yyyy年MM月dd日");   //yyyy年MM月dd日
            this.Tt.Text += " ";
            //获得时分秒
            this.Tt.Text += DateTime.Now.ToString("HH:mm:ss");
            //System.Diagnostics.Debug.Print("this.ShowCurrentTime {0}", this.ShowCurrentTime);
        }
        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            ShowList();
        }

        private void ShowList()
        {
            //if (this.ClinicPatient.IsChecked.Value)
            //    ShowAllRegistration();
            //else if (this.InHospitalPatient.IsChecked.Value)
            //    ShowAllInPatient();
        }

        private void FindChargeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowAllRegistration()
        {
            var vm = this.DataContext as HISGUIFeeVM;

            //Dictionary<int, string> dictionary = new Dictionary<int, string>();
            //dictionary = vm?.GetAllClinicPatients(this.StartChargeDate.SelectedDate.HasValue ? this.StartChargeDate.SelectedDate.Value : DateTime.Now,
            //    this.EndChargeDate.SelectedDate.HasValue ? this.EndChargeDate.SelectedDate.Value : DateTime.Now, 
            //    this.FindChargeTextEdti.Text, 
            //    this.HavePay.IsChecked.HasValue? this.HavePay.IsChecked.Value : false);

            //List<PatientMsgBox> list = new List<PatientMsgBox>();
            //if (dictionary != null)
            //{
            //    for (int i = 0; i < dictionary.Count; i++)
            //    {
            //        // 实例化一个控件
            //        list.Add(new PatientMsgBox(dictionary.ElementAt(i).Key, dictionary.ElementAt(i).Value));
            //    }

            //    this.AllChargeBillList.ItemsSource = list;
            //}
        }

        private void ShowAllInPatient()
        {
            var vm = this.DataContext as HISGUIFeeVM;

            //Dictionary<int, string> dictionary = new Dictionary<int, string>();
            //dictionary = vm?.GetAllInHospitalChargePatient(this.StartChargeDate.SelectedDate.HasValue ? this.StartChargeDate.SelectedDate.Value : DateTime.Now,
            //    this.EndChargeDate.SelectedDate.HasValue ? this.EndChargeDate.SelectedDate.Value : DateTime.Now,
            //    this.FindChargeTextEdti.Text,
            //    this.HavePay.IsChecked.HasValue ? this.HavePay.IsChecked.Value : false);

            //List<PatientMsgBox> list = new List<PatientMsgBox>();
            //if (dictionary != null)
            //{
            //    for (int i = 0; i < dictionary.Count; i++)
            //    {
            //        // 实例化一个控件
            //        list.Add(new PatientMsgBox(dictionary.ElementAt(i).Key, dictionary.ElementAt(i).Value));
            //    }

            //    this.AllChargeBillList.ItemsSource = list;
            //}
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

        private void AllChargeBillList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //var vm = this.DataContext as HISGUIFeeVM;
            //var thePatient = this.AllChargeBillList.SelectedItem as PatientMsgBox;
            //if (this.ClinicPatient.IsChecked.Value)
            //{
            //    vm.IsClinicOrInHospital = true;
            //    vm.CurrentRegistrationID = thePatient.ID;
            //}
            //else if(this.InHospitalPatient.IsChecked.Value)
            //{
            //    vm.IsClinicOrInHospital = false;
            //    vm.CurrentInHospitalID = thePatient.ID;
            //}

            //MessageBox.Show(vm.IsClinicOrInHospital.ToString() +"|"+ vm.CurrentInHospitalID+"|" + vm.CurrentRegistrationID);
            //vm?.ShowCharge();
        }

        private void LayoutBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIFeeVM;
            vm?.RegionManager.RequestNavigate("DownRegion", "HISGUILoginView");
        }
    }
}
