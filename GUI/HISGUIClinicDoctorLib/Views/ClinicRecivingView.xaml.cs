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
using Microsoft.VisualBasic;

namespace HISGUIDoctorLib.Views
{
    [Export]
    [Export("ClinicRecivingView", typeof(ClinicRecivingView))]
    public partial class ClinicRecivingView : HISGUIViewBase
    {

        public ClinicRecivingView()
        {
            InitializeComponent();
            this.Loaded += ClinicRecivingView_Loaded;
        }

        [Import]
        private HISGUIDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void ClinicRecivingView_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void CallBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            vm.IsClinicOrInHospital = true;
            String strPatientCardNum = Interaction.InputBox("请输入就诊卡卡号", "读卡", "", 100, 100);
            if (string.IsNullOrEmpty(strPatientCardNum))
                return;
            CommClient.Patient patientClient = new CommClient.Patient();
            string ErrorMsg = "";
            CommContracts.Patient patient = patientClient.ReadCurrentPatientByPatientCardNum(strPatientCardNum, ref ErrorMsg);



            CommClient.Registration registrationClient = new CommClient.Registration();
            List<CommContracts.Registration> list = registrationClient.GetPatientRegistrations(patient.ID, DateTime.Now);

            if (list == null || list.Count() <= 0)
                return;
            vm.CurrentRegistration = list.ElementAt(0);
            
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            //var vm = this.DataContext as HISGUIDoctorVM;
            //var tempRegistration = this.AllPatientList.SelectedItem as CommContracts.Registration;

            //if (tempRegistration == null)
            //    return;

            //tempRegistration.StartSeeDoctorTime = DateTime.Now;
            //tempRegistration.SeeDoctorStatus = CommContracts.SeeDoctorStatusEnum.接诊中;
            //vm.UpdateRegistration(tempRegistration);

            //this.PatientMsgView.SetMyEnable(true);
            //this.PatientMsgView.ShowClinicMsg(tempRegistration);
            //this.PatientMsgView.Visibility = Visibility.Visible;
            //this.TipMsgLabel.Visibility = Visibility.Collapsed;
            //this.StartBtn.IsEnabled = false;
            //this.OverBtn.IsEnabled = true;
            //this.TurnToInHospitalBtn.IsEnabled = true;
            //UpdateAllRegistration();
        }

        private void OverBtn_Click(object sender, RoutedEventArgs e)
        {
            //var vm = this.DataContext as HISGUIDoctorVM;
            //var tempRegistration = this.AllPatientList.SelectedItem as CommContracts.Registration;

            //if (tempRegistration == null)
            //    return;

            //tempRegistration.EndSeeDoctorTime = DateTime.Now;
            //tempRegistration.SeeDoctorStatus = CommContracts.SeeDoctorStatusEnum.接诊结束;
            //vm.UpdateRegistration(tempRegistration);

            //this.PatientMsgView.SetMyEnable(false);
            //this.PatientMsgView.ShowClinicMsg(tempRegistration);
            //this.PatientMsgView.Visibility = Visibility.Visible;
            //this.TipMsgLabel.Visibility = Visibility.Collapsed;
            //this.StartBtn.IsEnabled = false;
            //this.OverBtn.IsEnabled = false;
            //this.TurnToInHospitalBtn.IsEnabled = false;
            //UpdateAllRegistration();
        }

        private void TurnToInHospitalBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            var tempRegistration = vm.CurrentRegistration;

            if (tempRegistration == null)
                return;



            CommContracts.InHospitalApply inHospitalApply = new CommContracts.InHospitalApply();
            inHospitalApply.PatientID = vm.CurrentRegistration.PatientID;
            inHospitalApply.UserID = vm.CurrentUser.ID;

            bool? result = vm.SaveInHospitalApply(inHospitalApply);
            if (result.HasValue)
            {
                if (result.Value)
                {
                    MessageBox.Show("入院申请成功！");
                    tempRegistration.EndSeeDoctorTime = DateTime.Now;
                    tempRegistration.SeeDoctorStatus = CommContracts.SeeDoctorStatusEnum.申请入院;
                    vm.UpdateRegistration(tempRegistration);

                    //this.PatientMsgView.SetMyEnable(false);
                    //this.PatientMsgView.ShowClinicMsg(tempRegistration);
                    //this.PatientMsgView.Visibility = Visibility.Visible;
                    //this.TipMsgLabel.Visibility = Visibility.Collapsed;
                    //this.StartBtn.IsEnabled = false;
                    //this.OverBtn.IsEnabled = false;
                    this.TurnToInHospitalBtn.IsEnabled = false;
                    //UpdateAllRegistration();
                    return;
                }
            }
            MessageBox.Show("入院申请失败！");
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            NewFileView newFile = new NewFileView();
            var window = new Window();
            window.Width = 530;
            window.Height = 350;
            window.Content = newFile;
            bool? bResult = window.ShowDialog();
            if(bResult.Value == true)
            {
                string strHeader = newFile.GetHeader;
                NewTabItem(strHeader);
            }
        }

        private void NewTabItem(string strHeader)
        {
           
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //var temp = this.DoctorDocsTree.SelectedItem as TreeViewItem;
            //if (temp == null)
            //    return;

            //if (temp.Items.Count > 0)
            //{
            //    MessageBox.Show("不能删除父节点！");
            //}
            //else
            //{
            //    var pa = temp.Parent as TreeViewItem;
            //    if(pa != null)
            //    {
            //        pa.Items.Remove(temp);
            //    }
            //}
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BingLiBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "病历";

            foreach (TabItem mytabItem in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = mytabItem.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = mytabItem;
                    return;
                }
            }

            ClinicMedicalRecordView eidtInspect = new ClinicMedicalRecordView();

            CloseableTabItem myTabItem = new CloseableTabItem(header);

            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void JianChaBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "检查";

            foreach (TabItem mytabItem in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = mytabItem.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = mytabItem;
                    return;
                }
            }

            InspectDoctorAdviceView eidtInspect = new InspectDoctorAdviceView();

            CloseableTabItem myTabItem = new CloseableTabItem(header);

            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void HuaYanBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "化验";

            foreach (TabItem mytabItem in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = mytabItem.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = mytabItem;
                    return;
                }
            }

            AssayDoctorAdviceView eidtInspect = new AssayDoctorAdviceView();

            CloseableTabItem myTabItem = new CloseableTabItem(header);

            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void ChuFangBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "处方";

            foreach (TabItem mytabItem in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = mytabItem.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = mytabItem;
                    return;
                }
            }

            MedicineDoctorAdviceView eidtInspect = new MedicineDoctorAdviceView();

            CloseableTabItem myTabItem = new CloseableTabItem(header);

            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void ZhiLiaoBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "治疗";

            foreach (TabItem mytabItem in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = mytabItem.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = mytabItem;
                    return;
                }
            }

            TherapyDoctorAdviceView eidtInspect = new TherapyDoctorAdviceView();

            CloseableTabItem myTabItem = new CloseableTabItem(header);

            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void QiTaBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
