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
using HISGUIDoctorLib.ViewModels;
using System.Data;

namespace HISGUIDoctorLib.Views
{
    [Export]
    [Export("ReceivingNewPatientsView", typeof(ReceivingNewPatientsView))]
    public partial class ReceivingNewPatientsView : HISGUIViewBase
    {
        private bool bIsClinicOrInHospital { get; set; }
        private CommContracts.Registration CurrentRegistration { get; set; }
        public ReceivingNewPatientsView()
        {
            InitializeComponent();
            CurrentRegistration = new CommContracts.Registration();
            this.Loaded += ReceivingNewPatients_Loaded;
        }

        [Import]
        private HISGUIDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void ReceivingNewPatients_Loaded(object sender, RoutedEventArgs e)
        {
        }

        public void ShowClinicMsg(CommContracts.Registration registration)
        {
            this.bIsClinicOrInHospital = true;
            this.CurrentRegistration = registration;
            showVisibility();
            showPatientMsg();
        }

        private void showVisibility()
        {
            if (this.bIsClinicOrInHospital)
            {
                Page1.Visibility = Visibility.Visible;
                Page2.Visibility = Visibility.Collapsed;
                this.tabControl.SelectedIndex = 0;  // 设置默认选中的选项卡，否则会出现界面乱切换的现象
            }
            else
            {
                Page1.Visibility = Visibility.Collapsed;
                Page2.Visibility = Visibility.Visible;
                this.tabControl.SelectedIndex = 1;
            }
        }

        private void showPatientMsg()
        {
            if(this.bIsClinicOrInHospital)
            {
                PatientMsg.Inlines.Clear();
                
                if (CurrentRegistration == null)
                    return;
                if (CurrentRegistration.Patient == null)
                    return;

                string str =
                    "姓名：" + CurrentRegistration.Patient.Name + "     " +
                    "性别：" + CurrentRegistration.Patient.Gender + "     " +
                    "生日：" + CurrentRegistration.Patient.BirthDay + "     " +
                    "身份证号：" + CurrentRegistration.Patient.IDCardNo + "     " +
                    "民族：" + CurrentRegistration.Patient.Volk + "     " +
                    "籍贯：" + CurrentRegistration.Patient.JiGuan + "     " +
                    "电话：" + CurrentRegistration.Patient.Tel + "\n";
                ;
                PatientMsg.Inlines.Add(new Run(str));

                str = "号源名称：" + CurrentRegistration.SignalSource.SignalItem.Name + "     " +
                    "科室：" + CurrentRegistration.SignalSource.DepartmentID + "     " +
                    "看诊状态：" + CurrentRegistration.SeeDoctorStatus.ToString() + "     " +
                    "看诊时间：" + CurrentRegistration.SignalSource.VistTime.Value.Date.ToString("yyyy-MM-dd") + "     " +
                    "时段：" + CurrentRegistration.SignalSource.SignalItem.SignalTimeEnum + "     " +
                    "费用：" + CurrentRegistration.RegisterFee + "元     " +
                    "挂号经办人：" + CurrentRegistration.RegisterUser.Username + "     " +
                    "经办时间：" + CurrentRegistration.RegisterTime.Value.Date + "     " ;
                PatientMsg.Inlines.Add(new Run(str));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window();//Windows窗体
            CostPreview jks = new CostPreview();  //UserControl写的界面   
            window.Title = "费用";
            window.Height = 768;
            window.Width = 1024;

            window.Content = jks;
            window.ShowDialog();
        }
    }
}
