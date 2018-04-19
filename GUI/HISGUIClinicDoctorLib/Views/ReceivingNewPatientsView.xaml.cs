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
        public ReceivingNewPatientsView()
        {
            InitializeComponent();
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
            var vm = this.DataContext as HISGUIDoctorVM;
            vm.IsClinicOrInHospital = true;
            vm.CurrentRegistration = registration;
            showVisibility();
            showPatientMsg();
        }

        public void ShowInHospitalMsg(CommContracts.InHospital inHospital)
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            vm.IsClinicOrInHospital = false;
            vm.CurrentInHospital = inHospital;
            showVisibility();
            showPatientMsg();
        }

        public void SetMyEnable(bool IsEnable)
        {
            tabControl.IsEnabled = IsEnable;
        }

        private void showVisibility()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            if (vm.IsClinicOrInHospital)
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
            var vm = this.DataContext as HISGUIDoctorVM;
            if (vm.IsClinicOrInHospital)
            {
                PatientMsg.Inlines.Clear();
                
                if (vm.CurrentRegistration == null)
                    return;
                if (vm.CurrentRegistration.Patient == null)
                    return;

                string str =
                    "姓名：" + vm.CurrentRegistration.Patient.Name + "     " +
                    "性别：" + vm.CurrentRegistration.Patient.Gender + "     " +
                    "生日：" + vm.CurrentRegistration.Patient.BirthDay + "     " +
                    "身份证号：" + vm.CurrentRegistration.Patient.ZhengJianNum + "     " +
                    "民族：" + vm.CurrentRegistration.Patient.Volk + "     " +
                    "籍贯：" + vm.CurrentRegistration.Patient.JiGuan_Sheng + "     " +
                    "电话：" + vm.CurrentRegistration.Patient.Tel + "\n";
                ;
                PatientMsg.Inlines.Add(new Run(str));

                str = "号源名称：" + vm.CurrentRegistration.SignalSource.SignalItem.Name + "     " +
                    "科室：" + vm.CurrentRegistration.SignalSource.DepartmentID + "     " +
                    "看诊状态：" + vm.CurrentRegistration.SeeDoctorStatus.ToString() + "     " +
                    "看诊时间：" + vm.CurrentRegistration.SignalSource.VistDate.Value.Date.ToString("yyyy-MM-dd") + "     " +
                    "费用：" + vm.CurrentRegistration.RegisterFee + "元     " +
                    "挂号经办人：" + vm.CurrentRegistration.RegisterUser.LoginName + "     " +
                    "经办时间：" + vm.CurrentRegistration.RegisterTime.Value.Date + "     " ;
                PatientMsg.Inlines.Add(new Run(str));
            }
            else
            {
                PatientMsg.Inlines.Clear();

                if (vm.CurrentInHospital == null)
                    return;
                if (vm.CurrentInHospital.Patient == null)
                    return;

                string str =
                    "姓名：" + vm.CurrentInHospital.Patient.Name + "     " +
                    "性别：" + vm.CurrentInHospital.Patient.Gender + "     " +
                    "生日：" + vm.CurrentInHospital.Patient.BirthDay + "     " +
                    "身份证号：" + vm.CurrentInHospital.Patient.ZhengJianNum + "     " +
                    "民族：" + vm.CurrentInHospital.Patient.Volk + "     " +
                    "籍贯：" + vm.CurrentInHospital.Patient.JiGuan_Sheng + "     " +
                    "电话：" + vm.CurrentInHospital.Patient.Tel + "\n";
                ;
                PatientMsg.Inlines.Add(new Run(str));
            }
        }
    }
}
