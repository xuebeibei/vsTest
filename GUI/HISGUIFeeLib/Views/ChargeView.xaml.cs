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
    public enum YiZhuEnum
    {
        处方,
        治疗,
        化验,
        检查,
        材料,
        其他
    }
    public class YiZhu
    {
        public int ID { get; set; }
        public DateTime? WriteTime { get; set; }
        public decimal SumOfMoney { get; set; }
        public string Doctor { get; set; }
        public YiZhuEnum YiZhuEnum { get; set; }
    }

    [Export]
    [Export("ChargeView", typeof(ChargeView))]
    public partial class ChargeView : HISGUIViewBase
    {
        private int PatientID;
        public ChargeView()
        {
            InitializeComponent();
        }

        [Import]
        private HISGUIFeeVM ImportVM
        {
            set { this.VM = value; }
        }

        private void NoPayCheck_Click(object sender, RoutedEventArgs e)
        {
            this.AllWillPayList.Visibility = Visibility.Visible;
            this.AllPayList.Visibility = Visibility.Collapsed;
        }

        private void HavePayCheck_Click(object sender, RoutedEventArgs e)
        {
            this.AllWillPayList.Visibility = Visibility.Collapsed;
            this.AllPayList.Visibility = Visibility.Visible;
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReadCard_Click(object sender, RoutedEventArgs e)
        {
            PatientID = 8;
            ShowPatientMsg();
            UpdateAllChage();
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
                "籍贯：" + tempPatient.JiGuan + " " +
                "电话：" + tempPatient.Tel + " "
                ;
            PatientMsg.Inlines.Add(new Run(str));
            PatientMsg.Inlines.Add(new Run("账户余额：" + dBalance.Value) { Foreground = Brushes.Green, FontSize = 25 });

        }

        public void UpdateAllChage()
        {
            if(this.HavePayCheck.IsChecked.Value)
            {
                // 得到所有已收费单据
            }
            else if(this.NoPayCheck.IsChecked.Value)
            {
                // 得到所有已开却未完成收费的单据
                List<YiZhu> list = new List<YiZhu>();
                var vm = this.DataContext as HISGUIFeeVM;
                List<CommContracts.Recipe> listR =  vm?.GetAllXiCheng();
                foreach(var tem in listR)
                {
                    YiZhu yiZhu = new YiZhu();
                    yiZhu.YiZhuEnum = YiZhuEnum.处方;
                    yiZhu.ID = tem.ID;
                    yiZhu.Doctor = tem.WriteUserID.ToString();
                    yiZhu.WriteTime = tem.WriteTime;
                    yiZhu.SumOfMoney = tem.SumOfMoney;
                    list.Add(yiZhu);
                }
                this.AllWillPayList.ItemsSource = list;
            }
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
