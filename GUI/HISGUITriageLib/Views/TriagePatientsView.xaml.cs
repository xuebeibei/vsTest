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
        public CommContracts.ClinicVistTime ClinicVistTime { get; set; }
        public string Doctor { get; set; }
        public int WaitNum { get; set; }
    }

    [Export]
    [Export("TriagePatientsView", typeof(TriagePatientsView))]
    public partial class TriagePatientsView : HISGUIViewBase
    {
        private CommContracts.Registration currentRegistration;
        private int currentPatientID;
        private int currentUserID;
        public TriagePatientsView()
        {
            InitializeComponent();
            currentRegistration = new CommContracts.Registration();
            currentPatientID = 0;
            currentUserID = 1;// 默认值
            
            this.Loaded += Triage_Loaded;
        }

        [Import]
        private HISGUINurseVM ImportVM
        {
            set { this.VM = value; }
        }

        private void Triage_Loaded(object sender, RoutedEventArgs e)
        {
            updateAllWaitGrid();
        }

        private void WaitingGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
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
                this.DepartmentBox.Text = currentRegistration.SignalSource.DepartmentID.ToString();
                this.VistDateBox.Text = currentRegistration.SignalSource.VistDate.Value.Date.ToString("yyyy-MM-dd");
                this.ClinicVistTimeBox.Text = "";
                this.SignalItemBox.Text = currentRegistration.SignalSource.SignalItem.Name;
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
            currentRegistration.SeeDoctorStatus = CommContracts.SeeDoctorStatusEnum.候诊中;
            currentRegistration.ArriveTime = DateTime.Now;
            currentRegistration.ArriveUserID = currentUserID;

            var vm = this.DataContext as HISGUINurseVM;
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

        private void updateAllWaitGrid()
        {
            this.AllWaitGrid.ItemsSource = updateAllWait();
        }


        private List<WaitMsg> updateAllWait()
        {
            List<WaitMsg> waitList = new List<WaitMsg>();

            var vm = this.DataContext as HISGUINurseVM;

            List<CommContracts.WorkPlan> sourceList = vm?.GetOneDaySignalSourceList(DateTime.Now.Date);
            if (sourceList == null || sourceList.Count == 0)
                return waitList;

            List<CommContracts.Registration> registrationList = vm?.GetOneDayRegistrationList(DateTime.Now.Date);

            List<CommContracts.ClinicVistTime> vistTimelist = new List<CommContracts.ClinicVistTime>();
            CommClient.ClinicVistTime clinicVistTimeClent = new CommClient.ClinicVistTime();
            vistTimelist = clinicVistTimeClent.GetAllClinicVistTime();


            var departmentQuery = (from u in sourceList
                                   select u.DepartmentID).Distinct();

            foreach (var de in departmentQuery)
            {
                foreach (CommContracts.ClinicVistTime tim in vistTimelist)
                {
                    var doctorQuery = (from u in sourceList
                                       where u.DepartmentID == de
                                       select new { u.EmployeeID, u.ID }).Distinct();

                    foreach (var doc in doctorQuery)
                    {
                        WaitMsg waitMsg = new WaitMsg();
                        waitMsg.Department = de.ToString();
                        waitMsg.ClinicVistTime = tim;
                        waitMsg.Doctor = doc.EmployeeID.ToString();

                        var numQuery = (from u in registrationList
                                        where u.SignalSourceID == doc.ID &&
                                        u.ArriveTime.HasValue &&
                                        u.SeeDoctorStatus == CommContracts.SeeDoctorStatusEnum.候诊中
                                        select u).Count();

                        waitMsg.WaitNum = numQuery;

                        waitList.Add(waitMsg);
                    }
                }
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
            window.ResizeMode = ResizeMode.NoResize;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                //MessageBox.Show("化验项目新建完成！");
                //UpdateAllDate();
            }
        }

        //private void ShowAllRegistration()
        //{
        //    var vm = this.DataContext as NurseVM;

        //    Dictionary<int, string> dictionary = new Dictionary<int, string>();
        //    dictionary = vm?.GetAllUnTriagePatient();

        //    List<PatientMsgBox> list = new List<PatientMsgBox>();
        //    if (dictionary != null)
        //    {
        //        for (int i = 0; i < dictionary.Count(); i++)
        //        {
        //            // 实例化一个控件
        //            list.Add(new PatientMsgBox(dictionary.ElementAt(i).Key, dictionary.ElementAt(i).Value));
        //        }

        //        this.aaa.ItemsSource = list;
        //    }
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (this.aaa.SelectedItems.Count <= 0)
        //    {
        //        MessageBox.Show("请选择患者!");
        //        return;
        //    }

        //    var vm = this.DataContext as NurseVM;
        //    //if(vm?.CurrentPatientList == null)
        //    //{

        //    //}
        //    //vm?.CurrentPatientList.Clear();
        //    List<int> list = new List<int>();
        //    for (int i = 0; i < this.aaa.SelectedItems.Count; i++)
        //    {
        //        PatientMsgBox aa = this.aaa.SelectedItems[i] as PatientMsgBox;
        //        if (aa != null)
        //        {
        //            list.Add(aa.ID);
        //        }
        //    }

        //    vm?.setList(list);

        //    vm?.SelectDoctor();
        //}
    }
}
