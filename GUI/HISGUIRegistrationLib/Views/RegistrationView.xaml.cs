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

    public class RegistrationSource
    {
        public int ID { get; set; }
        public string DoctorName { get; set; }
        public string DepartmentName { get; set; }
        public string SourceType { get; set; }
        public string TimeBucket { get; set; }
        public int NumberRemaining { get; set; }
        public decimal Fee { get; set; }
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

            string[] strDepartments = "骨科 妇科".Split(' ');
            string[] strTimes = "上午 下午 晚上".Split(' ');
            string[] sourceTypes = "普通 专家".Split(' ');

            ObservableCollection<TimeBucket> timeBucketList = new ObservableCollection<TimeBucket>();

            int nNum = 1;
            for (int i = 0; i < 7; i++)
            {
                foreach (var strDepartment in strDepartments)
                {
                    foreach (var strTime in strTimes)
                    {
                        TimeBucket timeBucketTemp = new TimeBucket();
                        timeBucketTemp.TimeBucketName = strTime;
                        timeBucketTemp.DepartmentName = strDepartment;
                        timeBucketTemp.KanZhenDate = DateTime.Now.Date.AddDays(i);

                        ObservableCollection<SourceType> souceTypeOb = new ObservableCollection<SourceType>();
                        foreach (var strSourcetype in sourceTypes)
                        {
                            if (strTime == "晚上")
                            {
                                continue;
                            }
                            SourceType souceType = new SourceType();
                            souceType.SourceTypeName = strSourcetype;

                            ObservableCollection<SourceDetail> tempDetails = new ObservableCollection<SourceDetail>();
                            tempDetails.Add(new SourceDetail() { ID = nNum++, DoctorName = strDepartment + "医生1", NumberRemaining = i + 1, OperationString = "挂号" });
                            tempDetails.Add(new SourceDetail() { ID = nNum++, DoctorName = strDepartment + "医生2", NumberRemaining = i + 1, OperationString = "挂号" });

                            souceType.Details = tempDetails;

                            souceTypeOb.Add(souceType);
                        }
                        timeBucketTemp.SourceTypes = souceTypeOb;
                        timeBucketList.Add(timeBucketTemp);
                    }
                }

            }

            var query = from u in timeBucketList
                        where u.DepartmentName == selectItem.Name && u.KanZhenDate == selectDate
                        select u;

            this.m_myGridView.ItemsSource = query;
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
            if(ID == null)
            {
                MessageBox.Show("null  -----   dd");
                return;
            }

            MessageBox.Show("挂号成功！");
        }
    }
}
