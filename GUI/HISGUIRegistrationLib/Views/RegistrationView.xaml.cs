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
using HISGUIRegistrationLib.ViewModels;
using System.Data;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic;

namespace HISGUIRegistrationLib.Views
{
    public class TimeBucket
    {
        public string TimeBucketName { get; set; }
        public string DepartmentName { get; set; }
        public DateTime KanZhenDate { get; set; }

        public ObservableCollection<SourceType> SourceTypes { get; set; }
    }

    public class SourceType
    {
        public string SourceTypeName { get; set; }
        public ObservableCollection<SourceDetail> Details { get; set; }
    }

    public class SourceDetail
    {
        public int ID { get; set; }
        public string DoctorName { get; set; }
        public int NumberRemaining { get; set; }
        public string OperationString { get; set; }
    }

    [Export]
    [Export("RegistrationView", typeof(RegistrationView))]
    public partial class RegistrationView : HISGUIViewBase
    {
        public RegistrationView()
        {
            InitializeComponent();
            this.Loaded += RegistrationView_Loaded;
        }

        private void RegistrationView_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDepartment();
            LoadRegistrationSource();
            updateAllClinicRegistrationList();
        }

        private void LoadRegistrationSource()
        {
            this.m_myGridView.ItemsSource = null;
            if (m_allDepartmentTree == null)
                return;

            var selectItem = m_allDepartmentTree.SelectedItem as CommContracts.LevelTwoDepartment;
            if (selectItem == null)
                return;

            var selectDate = m_SelectDateEdit.SelectedDate;
            if (selectDate == null)
                return;

            var vm = this.DataContext as HISGUIRegistrationVM;
            List<CommContracts.DoctorClinicWorkPlan> doctorClinicWorkPlanList = new List<CommContracts.DoctorClinicWorkPlan>();
            doctorClinicWorkPlanList = vm.GetAllDoctorClinicWorkPlan();

            string[] strTimes = "上午 下午 晚上".Split(' ');
            string[] sourceTypes = "普通 专家".Split(' ');

            ObservableCollection<TimeBucket> timeBucketList = new ObservableCollection<TimeBucket>();

            int nZhou = (int)selectDate.Value.DayOfWeek+1;

            foreach (var strTime in strTimes)
            {
                TimeBucket timeBucketTemp = new TimeBucket();
                timeBucketTemp.TimeBucketName = strTime;
                timeBucketTemp.DepartmentName = selectItem.Name;
                timeBucketTemp.KanZhenDate = selectDate.Value.Date;

                ObservableCollection<SourceType> souceTypeOb = new ObservableCollection<SourceType>();
                foreach (var strSourcetype in sourceTypes)
                {
                    if (strTime == "晚上")
                    {
                        continue;
                    }

                    var query1 = from x in doctorClinicWorkPlanList
                                 where x.Zhou == nZhou && x.TimeBucket.StartsWith(strTime)
                                 && x.LevelTwoDepartmentID == selectItem.ID && x.SourceType.StartsWith(strSourcetype)
                                 select x;
                    SourceType souceType = new SourceType();
                    souceType.SourceTypeName = strSourcetype;

                    ObservableCollection<SourceDetail> tempDetails = new ObservableCollection<SourceDetail>();

                    foreach (var tem in query1)
                    {

                        tempDetails.Add(new SourceDetail() { ID = tem.ID, DoctorName = tem.Doctor, NumberRemaining = tem.MaxNum, OperationString = "挂号" });
                        tempDetails.Add(new SourceDetail() { ID = tem.ID, DoctorName = tem.Doctor, NumberRemaining = tem.MaxNum, OperationString = "挂号" });

                        souceType.Details = tempDetails;


                    }
                    souceTypeOb.Add(souceType);

                }
                timeBucketTemp.SourceTypes = souceTypeOb;
                timeBucketList.Add(timeBucketTemp);
            }
            this.m_myGridView.ItemsSource = timeBucketList;
        }

        [Import]
        private HISGUIRegistrationVM ImportVM
        {
            set { this.VM = value; }
        }

        private void LoadDepartment()
        {
            this.m_allDepartmentTree.ItemsSource = null;

            var vm = this.DataContext as HISGUIRegistrationVM;


            List<CommContracts.LevelOneDepartment> levalOneDepartmentList = new List<CommContracts.LevelOneDepartment>();
            levalOneDepartmentList = vm.GetAllLevelOneDepartment();

            this.m_allDepartmentTree.ItemsSource = levalOneDepartmentList;
        }

        private void DepartmentTreeSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            LoadRegistrationSource();
        }

        private void KanZhenDateSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadRegistrationSource();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object ID = ((Button)sender).CommandParameter;
            if (ID == null)
            {
                MessageBox.Show("请选择有效的号源挂号！");
                
                return;
            }
            var vm = this.DataContext as HISGUIRegistrationVM;
            if (vm == null)
                return;

            CommContracts.ClinicRegistration registration = new CommContracts.ClinicRegistration();
            registration.DoctorClinicWorkPlanID = int.Parse(ID.ToString());
            registration.PatientID = 1;
            registration.VistDoctorDate = this.m_SelectDateEdit.SelectedDate.Value;
            registration.RegistrationTime = DateTime.Now;
            if(vm.SaveClinicRegistration(registration))
            {
                MessageBox.Show("挂号成功！");
                updateAllClinicRegistrationList();
            }
            else
            {
                MessageBox.Show("挂号失败！");
            }
        }

        private void updateAllClinicRegistrationList()
        {
            var vm = this.DataContext as HISGUIRegistrationVM;
            if (vm == null)
                return;

            List<CommContracts.ClinicRegistration> list = vm.GetAllClinicRegistration();
            this.m_AllGuahaoList.ItemsSource = list;
        }

        private void TuiFeiBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIRegistrationVM;
            if (vm == null)
                return;
            String strPatientCardNum = Interaction.InputBox("请输入退号单ID", "退号", "", 100, 100);
            if (string.IsNullOrEmpty(strPatientCardNum))
                return;
            bool? result = vm.DeleteClinicRegistration(int.Parse(strPatientCardNum));
            if(result.HasValue)
            {
                if(result.Value)
                {
                    MessageBox.Show("退号成功!");
                    updateAllClinicRegistrationList();
                    return;
                }
            }

            MessageBox.Show("退号失败!");

        }
    }
}
