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
using HISGUINurseLib.ViewModels;
using System.Data;

namespace HISGUINurseLib.Views
{
    [Export]
    [Export("InjectionView", typeof(InjectionView))]
    public partial class InjectionView : HISGUIViewBase
    {
        private int MyCurrentRegistrationID { get; set; }
        private int myCurrentPatientID{ get; set; }
        public InjectionView()
        {
            InitializeComponent();
            this.Loaded += InjectionView_Loaded;
        }

        private void InjectionView_Loaded(object sender, RoutedEventArgs e)
        {
            ShowAllPatient();
        }

        private void ShowAllPatient()
        {
            this.AllPatientList.ItemsSource = null;
            var vm = this.DataContext as HISGUINurseVM;
            if (this.ClinicRadio.IsChecked.Value)
            {
                this.AllPatientList.ItemsSource = vm?.GetAllClinicPatients(DateTime.Now, DateTime.Now);
            }
            else if (this.HospitalRadio.IsChecked.Value)
            {
                this.AllPatientList.ItemsSource = vm?.GetAllInHospitalChargePatient();
            }
        }

        [Import]
        private HISGUINurseVM ImportVM
        {
            set { this.VM = value; }
        }

        private void AllPatientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vm = this.DataContext as HISGUINurseVM;
            if (this.ClinicRadio.IsChecked.Value)
            {
                var re = this.AllPatientList.SelectedItem as CommContracts.Registration;
                if (re == null)
                    return;
                MyCurrentRegistrationID = re.PatientID;
                vm.CurrentRegistration = re;
                vm.IsClinicOrInHospital = true;
            }
            else if (this.HospitalRadio.IsChecked.Value)
            {
                var inp = this.AllPatientList.SelectedItem as CommContracts.InHospital;
                if (inp == null)
                    return;
                myCurrentPatientID = inp.PatientID;
                vm.CurrentInpatient = inp;
                vm.IsClinicOrInHospital = false;
            }

            ShowPatientMsg();
            UpdateAllChage();
        }

        private void ShowPatientMsg()
        {
            var vm = this.DataContext as HISGUINurseVM;
            CommContracts.Patient tempPatient = vm?.ReadCurrentPatient(myCurrentPatientID);
            decimal? dBalance = vm?.GetCurrentPatientBalance(myCurrentPatientID);

            PatientMsg.Inlines.Clear();
            string str =
                "姓名：" + tempPatient.Name + " " +
                "性别：" + tempPatient.Gender + " " +
                "生日：" + tempPatient.BirthDay + " " +
                "身份证号：" + tempPatient.ZhengJianNum + " " +
                "民族：" + tempPatient.Volk + " " +
                "籍贯：" + tempPatient.JiGuan_Sheng + " " +
                "电话：" + tempPatient.Tel + " "
                ;
            PatientMsg.Inlines.Add(new Run(str));
            PatientMsg.Inlines.Add(new Run("账户余额：" + dBalance.Value) { Foreground = Brushes.Green, FontSize = 25 });
        }

        public void UpdateAllChage()
        {
            var vm = this.DataContext as HISGUINurseVM;
            if (this.HaveDoneCheck.IsChecked.Value)
            {
                // 得到所有已收费单据
                List<CommContracts.InjectionBill> listAllCharge = new List<CommContracts.InjectionBill>();
                listAllCharge.AddRange(vm?.GetAllInjectionBill());

                this.AllHaveDoneList.ItemsSource = listAllCharge;
            }
            else if (this.unDoCheck.IsChecked.Value)
            {
                List<CommContracts.DoctorAdviceBase> listAllAdvice = new List<CommContracts.DoctorAdviceBase>();

                listAllAdvice.AddRange(vm?.GetAllMedicineDoctorAdvice());

                var query = from u in listAllAdvice
                            where u.ChargeStatusEnum == CommContracts.ChargeStatusEnum.全部收费 &&
                            u.ExecuteEnum == CommContracts.ExecuteEnum.未执行
                            select u;

                this.AllUnDoList.ItemsSource = query;
            }

            this.DetailGrid.Visibility = Visibility.Collapsed;
        }
        private void ReadCard_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void unDoCheck_Click(object sender, RoutedEventArgs e)
        {
            this.AllUnDoList.Visibility = Visibility.Visible;
            this.AllHaveDoneList.Visibility = Visibility.Collapsed;
            this.DoBtn.Visibility = Visibility.Visible;
            UpdateAllChage();
        }

        private void HaveDoneCheck_Click(object sender, RoutedEventArgs e)
        {
            this.AllUnDoList.Visibility = Visibility.Collapsed;
            this.AllHaveDoneList.Visibility = Visibility.Visible;
            this.DoBtn.Visibility = Visibility.Collapsed;
            UpdateAllChage();
        }

        private void DetailGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void AllUnDoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var doctorAdvice = this.AllUnDoList.SelectedItem as CommContracts.DoctorAdviceBase;
            if (doctorAdvice == null)
                return;

            switch (doctorAdvice.DoctorAdviceEnum)
            {
                case CommContracts.DoctorAdviceBaseEnum.处方:
                    {
                        ShowMedicineAdviceDetails((CommContracts.MedicineDoctorAdvice)doctorAdvice);
                        this.DetailGrid.Visibility = Visibility.Visible;
                        break;
                    }
                default:
                    break;
            }
        }

        private void AllHaveDoneList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var doctorAdvice = this.AllHaveDoneList.SelectedItem as CommContracts.InjectionBill;
            if (doctorAdvice == null)
                return;

            ShowMedicineAdviceDetails((CommContracts.MedicineDoctorAdvice)doctorAdvice.MedicineDoctorAdvice);
            this.DetailGrid.Visibility = Visibility.Visible;
        }

        private void ShowMedicineAdviceDetails(CommContracts.MedicineDoctorAdvice medicineDoctorAdvice)
        {
            if (medicineDoctorAdvice == null)
            {
                return;
            }

            if (medicineDoctorAdvice.MedicineDoctorAdviceDetails == null)
            {
                return;
            }
            this.DetailGrid.ItemsSource = medicineDoctorAdvice.MedicineDoctorAdviceDetails;
            this.DetailGrid.IsEnabled = true;
        }

        private void SaveMedicineCharge(CommContracts.DoctorAdviceBase tempAdvice)
        {
            var vm = this.DataContext as HISGUINurseVM;

            var advice = tempAdvice as CommContracts.MedicineDoctorAdvice;
            if (advice == null)
                return;

            CommContracts.InjectionBill injectionBill = new CommContracts.InjectionBill();
            injectionBill.MedicineDoctorAdviceID = advice.ID;
            injectionBill.UserID = vm.CurrentUser.ID;
            injectionBill.CurrentTime = DateTime.Now;

            CommClient.InjectionBill myd = new CommClient.InjectionBill();
            if (myd.SaveInjectionBill(injectionBill))
            {
                tempAdvice.ExecuteEnum = CommContracts.ExecuteEnum.已执行;
                bool? bResult = vm?.UpdateDoctorAdvice(tempAdvice);
                if (bResult.HasValue && bResult.Value)
                {
                    MessageBox.Show("保存成功！");
                    UpdateAllChage();
                    return;
                }
            }
            else
            {
                MessageBox.Show("保存失败！");
                return;
            }
        }

        private void DoBtn_Click(object sender, RoutedEventArgs e)
        {
            var tempAdvice = this.AllUnDoList.SelectedItem as CommContracts.DoctorAdviceBase;
            if (tempAdvice == null)
                return;

            switch (tempAdvice.DoctorAdviceEnum)
            {
                case CommContracts.DoctorAdviceBaseEnum.处方:
                    {
                        SaveMedicineCharge(tempAdvice);
                        break;
                    }
                //case CommContracts.DoctorAdviceBaseEnum.材料:
                //    {
                //        SaveMaterialCharge(tempAdvice);
                //        break;
                //    }
                //case CommContracts.DoctorAdviceBaseEnum.治疗:
                //    {
                //        SaveTherapyCharge(tempAdvice);
                //        break;
                //    }
                //case CommContracts.DoctorAdviceBaseEnum.化验:
                //    {
                //        SaveAssayCharge(tempAdvice);
                //        break;
                //    }
                //case CommContracts.DoctorAdviceBaseEnum.检查:
                //    {
                //        SaveInspectCharge(tempAdvice);
                //        break;
                //    }
                //case CommContracts.DoctorAdviceBaseEnum.其他:
                //    {
                //        SaveOtherServiceCharge(tempAdvice);
                //        break;
                //    }
                default:
                    break;
            }
        }

        private void ClinicRadio_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUINurseVM;
            vm.IsClinicOrInHospital = true;
            ShowAllPatient();
        }

        private void HospitalRadio_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUINurseVM;
            vm.IsClinicOrInHospital = false;
            ShowAllPatient();
        }
    }
}
