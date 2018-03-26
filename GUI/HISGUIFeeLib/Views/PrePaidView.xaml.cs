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
    [Export("PrePaidView", typeof(PrePaidView))]
    public partial class PrePaidView : HISGUIViewBase
    {
        private int PatientID;
        public PrePaidView()
        {
            InitializeComponent();
            PatientID = 0;
        }

        [Import]
        private HISGUIFeeVM ImportVM
        {
            set { this.VM = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientID = 8;
            ShowPatientMsg();
            UpdateAllPrePay();
        }

        private void ShowPatientMsg()
        {
            var vm = this.DataContext as HISGUIFeeVM;
            CommContracts.Patient tempPatient = vm?.ReadCurrentPatient(PatientID);
            decimal? dBalance = vm?.GetCurrentPatientBalance(PatientID);

            PatientMsg.Inlines.Clear();
            string str =
                "姓名：" + tempPatient.Name + " " +
                "性别：" + tempPatient.Gender + " " +
                "生日：" + tempPatient.BirthDay + " " +
                "身份证号：" + tempPatient.IDCardNo + " " +
                "民族：" + tempPatient.Volk + " " +
                "籍贯：" + tempPatient.JiGuan_Sheng + " " +
                "电话：" + tempPatient.Tel + " "
                ;
            PatientMsg.Inlines.Add(new Run(str));
            PatientMsg.Inlines.Add(new Run("账户余额：" + dBalance.Value) { Foreground = Brushes.Green, FontSize = 25 });

        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIFeeVM;
            decimal money = 0.0m;
            string str = "缴费";
            if(PayCheck.IsChecked.Value)
            {
                money = decimal.Parse(this.MoneyBox.Text);
            }
            else if(ReturnCheck.IsChecked.Value)
            {
                money =  - decimal.Parse(this.MoneyBox.Text);
                str = "退费";
            }

            bool? result = vm?.SavePrePay(PatientID, money, 3);
            if (result.HasValue)
            {
                if(result.Value)
                {
                    MessageBox.Show(str + "成功！");
                    ShowPatientMsg();
                    UpdateAllPrePay();
                    return;
                }
            }
            MessageBox.Show(str + "失败！");
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int PrePayID = 0;
            var temp = this.AllPrePaidList.SelectedItem as CommContracts.PrePay;
            if (temp == null)
            {
                return;
            }
            else
            {
                PrePayID = temp.ID;
            }
            var vm = this.DataContext as HISGUIFeeVM;
            bool? bResult = vm?.DeletePrePay(PrePayID);
            if(bResult.HasValue)
            {
                if(bResult.Value)
                {
                    MessageBox.Show("删除成功！");
                    ShowPatientMsg();
                    UpdateAllPrePay();
                    return;
                }
            }
            MessageBox.Show("删除失败！");
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateAllPrePay()
        {
            var vm = this.DataContext as HISGUIFeeVM;
            this.AllPrePaidList.ItemsSource = vm?.GetAllPrePay(PatientID);
        }

        private void PayCheck_Click(object sender, RoutedEventArgs e)
        {
            this.PayBtn.Content = "缴费";
        }

        private void ReturnCheck_Click(object sender, RoutedEventArgs e)
        {
            this.PayBtn.Content = "退费";
        }
    }
}
