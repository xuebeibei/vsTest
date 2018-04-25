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
using Microsoft.VisualBasic;

namespace HISGUINurseLib.Views
{
    public class WaitMsg
    {
        public string Department { get; set; }
        public CommContracts.SignalTime ClinicVistTime { get; set; }
        public string Doctor { get; set; }
        public int WaitNum { get; set; }
    }

    [Export]
    [Export("TriagePatientsView", typeof(TriagePatientsView))]
    public partial class TriagePatientsView : HISGUIViewBase
    {
        private CommContracts.Registration currentRegistration;
        public TriagePatientsView()
        {
            InitializeComponent();
            currentRegistration = new CommContracts.Registration();
            
            this.Loaded += Triage_Loaded;
        }

        [Import]
        private HISGUINurseVM ImportVM
        {
            set { this.VM = value; }
        }

        private void Triage_Loaded(object sender, RoutedEventArgs e)
        {
            InitCombo();
            updateAllWaitGrid();
        }

        private void WaitingGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
        }

        private void InitCombo()
        {
            this.FeeTypeCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.FeeTypeEnum));
            this.FeeTypeCombo.SelectedIndex = 0;

            this.ZJCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.ZhengJianEnum));
            this.ZJCombo.SelectedIndex = 0;

            this.CardTypeCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.PatientCardEnum));
            this.CardTypeCombo.SelectedIndex = 0;
        }

        private void ReadCardBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUINurseVM;
            String strPatientCardNum = Interaction.InputBox("请输入就诊卡卡号", "读卡", "", 100, 100);
            if (string.IsNullOrEmpty(strPatientCardNum))
                return;

            updatePatientsMsg(strPatientCardNum);

            currentRegistration = vm?.GetPatientRegistrations(vm.CurrentPatient.ID, DateTime.Now);
            if(currentRegistration != null)
            {
                this.DepartmentBox.Text = currentRegistration.Department.Name;
                this.VistDateBox.Text = currentRegistration.SignalDate.Date.ToString("yyyy-MM-dd");
                this.ClinicVistTimeBox.Text = currentRegistration.SignalTime.Shift.Name;
                this.SignalItemBox.Text = currentRegistration.SignalType.Name;
                this.StatusBox.Text = currentRegistration.SeeDoctorStatus.ToString();
            }
        }

        private void updatePatientsMsg(String strPatientCardNum)
        {
            var vm = this.DataContext as HISGUINurseVM;
            CommContracts.Patient patient = new CommContracts.Patient();
            string strAge = "";
            if (string.IsNullOrEmpty(strPatientCardNum))
            {
                vm.CurrentPatient = patient;
                this.AgeBox.Text = strAge;
                return;
            }

            CommClient.Patient patientClient = new CommClient.Patient();

            string ErrorMsg = "";
            patient = patientClient.ReadCurrentPatientByPatientCardNum(strPatientCardNum, ref ErrorMsg);

            if (patient == null)
            {
                MessageBox.Show(ErrorMsg);
            }
            else
            {
                vm.CurrentPatient = patient;

                strAge = IDCardHellper.GetAge(patient.BirthDay.Value.Year, patient.BirthDay.Value.Month, patient.BirthDay.Value.Day);
                this.AgeBox.Text = strAge;
            }
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ArriveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(currentRegistration.SeeDoctorStatus == CommContracts.SeeDoctorStatusEnum.未到诊)
            {
                var vm = this.DataContext as HISGUINurseVM;
                currentRegistration.SeeDoctorStatus = CommContracts.SeeDoctorStatusEnum.候诊中;
                currentRegistration.ArriveTime = DateTime.Now;
                currentRegistration.ArriveUserID = vm.CurrentUser.ID;

                bool? result = vm.UpdateRegistration(currentRegistration);
                if (result.HasValue)
                {
                    if (result.Value)
                    {
                        MessageBox.Show("到诊成功！");
                        updateAllWaitGrid();
                        this.ArriveBtn.IsEnabled = false;
                        return;
                    }
                }
                MessageBox.Show("到诊失败！");
            }
            else
            {
                MessageBox.Show("到诊失败，就诊状态为：" + currentRegistration.SeeDoctorStatus.ToString());
            }
        }

        private void updateAllWaitGrid()
        {
            this.AllWaitGrid.ItemsSource = updateAllWait();
        }


        private List<WaitMsg> updateAllWait()
        {
            List<WaitMsg> waitList = new List<WaitMsg>();

            var vm = this.DataContext as HISGUINurseVM;
            CommClient.Employee employeeClient = new CommClient.Employee();
            
            var department = employeeClient.GetCurrentDepartment(vm.CurrentUser.ID);
            if (department == null)
                return null;


            // 得到该科室所有已到诊患者
            List<CommContracts.Registration> registrationList = vm?.GetOneDayRegistrationList(department.ID, DateTime.Now.Date);

            foreach(var aa in registrationList)
            {
                WaitMsg waitMsg = new WaitMsg();
                waitMsg.Department = aa.Department.Name;
                waitMsg.ClinicVistTime = aa.SignalTime;
                //waitMsg.Doctor = doc.EmployeeID.ToString();

                var numQuery = (from u in registrationList
                                where
                                //u.SignalSourceID == doc.ID &&
                                u.ArriveTime.HasValue &&
                                u.SeeDoctorStatus == CommContracts.SeeDoctorStatusEnum.候诊中
                                select u).Count();

                waitMsg.WaitNum = numQuery;
                waitList.Add(waitMsg);
            }

            return waitList;


        }

        private void AllWaitGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void EditBMIBtn_Click(object sender, RoutedEventArgs e)
        {
            //EditPatientMsgView
            // 新增化验项目
            var window = new Window();

            EditPatientMsgView eidtAssayItem = new EditPatientMsgView();
            window.Content = eidtAssayItem;
            window.Width = 400;
            window.Height = 500;
            //window.ResizeMode = ResizeMode.NoResize;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                //MessageBox.Show("化验项目新建完成！");
                //UpdateAllDate();
            }
        }
    }
}
