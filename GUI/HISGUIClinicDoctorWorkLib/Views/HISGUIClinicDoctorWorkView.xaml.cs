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
using HISGUIClinicDoctorWorkLib.ViewModels;
using System.Data;
using System.IO;
using System.Configuration;
using System.Collections.ObjectModel;
namespace HISGUIClinicDoctorWorkLib.Views
{
    [Export]
    [Export("HISGUIClinicDoctorWorkView", typeof(HISGUIClinicDoctorWorkView))]
    public partial class HISGUIClinicDoctorWorkView : HISGUIViewBase
    {
        private List<CommContracts.ClinicDoctorAdvice> ClinicDoctorAdviceList;
        public HISGUIClinicDoctorWorkView()
        {
            InitializeComponent();
            this.Loaded += HISGUIClinicDoctorWorkView_Loaded;
        }

        private void HISGUIClinicDoctorWorkView_Loaded(object sender, RoutedEventArgs e)
        {
            ClinicDoctorAdviceList = new List<CommContracts.ClinicDoctorAdvice>();

            LoadAllRegistration();
            LoadAllClinicDoctorAdvices();


        }

        private void LoadAllClinicDoctorAdvices()
        {
            var vm = this.DataContext as HISGUIClinicDoctorWorkVM;
            if (vm == null)
                return;

            //ClinicDoctorAdviceList = vm.getAllClinicDoctorAdvice();
            if (vm.ClinicDoctorAdviceList != null)
                ClinicDoctorAdviceList = vm.ClinicDoctorAdviceList;
            else
                return;


            m_DoctorAdvicePanel.Children.Clear();

            if (ClinicDoctorAdviceList == null)
                return;
            else
            {
                foreach (var tem in ClinicDoctorAdviceList)
                {
                    DoctorAdviceView adviceView = new DoctorAdviceView(tem);
                    m_DoctorAdvicePanel.Children.Add(adviceView);
                }
            }

        }

        [Import]
        private HISGUIClinicDoctorWorkVM ImportVM
        {
            set { this.VM = value; }
        }

        private void LoadAllRegistration()
        {
            var vm = this.DataContext as HISGUIClinicDoctorWorkVM;
            if (vm == null)
                return;

            // 链接数据库，wcf报错，未解决，改用假数据暂时支撑。
            //List<CommContracts.ClinicRegistration> list = vm.getAllClinicRegistration();
            //this.m_候诊List.ItemsSource = list;

            List<CommContracts.ClinicRegistration> list = new List<CommContracts.ClinicRegistration>();
            for (int i = 0; i < 10; i++)
            {
                CommContracts.Patient patient = new CommContracts.Patient();
                patient.Name = "患者" + (i + 1);
                patient.ID = i + 1;
                patient.Gender = CommContracts.GenderEnum.男;

                CommContracts.ClinicRegistration clinic = new CommContracts.ClinicRegistration();
                clinic.ID = i + 1;
                clinic.PatientID = patient.ID;
                clinic.RegistrationTime = DateTime.Now;
                clinic.VistDoctorDate = DateTime.Now; ;
                clinic.Patient = patient;

                list.Add(clinic);
            }

            this.m_候诊List.ItemsSource = list;
        }

        private void 候诊ListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vm = this.DataContext as HISGUIClinicDoctorWorkVM;
            if (vm == null)
                return;

            var selectItem = this.m_候诊List.SelectedItem as CommContracts.ClinicRegistration;
            if (selectItem == null)
            {
                return;
            }

            vm.CurrentClinicRegistration = selectItem;
            if (selectItem.Patient == null)
                return;
            if (selectItem.Patient.BirthDay != null)
                this.m_AgeText.Text = (DateTime.Now.Year - selectItem.Patient.BirthDay.Value.Year).ToString() + "岁";
        }

        private void NewBtnClicked(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIClinicDoctorWorkVM;
            if (vm == null)
                return;

            var selectItem = this.m_候诊List.SelectedItem as CommContracts.ClinicRegistration;
            if (selectItem == null)
            {
                MessageBox.Show("请选择患者");
                return;
            }
            var window = new Window();
            DoctorAdviceEditView doctorAdviceEditView = new DoctorAdviceEditView();
            doctorAdviceEditView.DataContext = this.DataContext;

            // 这里最好能够让界面弹出在父窗口正中心位置
            window.Content = doctorAdviceEditView;
            window.Width = 880;
            window.Height = 700;

            if (window.ShowDialog().Value == true)
            {
                //var tem = doctorAdviceEditView.CurrentClinicDoctorAdvice;
                //ClinicDoctorAdviceList.Add(tem);
                LoadAllClinicDoctorAdvices();
            }
        }

        private void m_deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIClinicDoctorWorkVM;
            if (vm == null)
                return;

            if (m_DoctorAdvicePanel.Children == null)
                return;
            foreach (DoctorAdviceView tem in m_DoctorAdvicePanel.Children)
            {
                if (tem.IsChecked)
                {
                    if(vm.ClinicDoctorAdviceList != null)
                        vm.ClinicDoctorAdviceList.Remove(tem.ClinicDoctorAdvice);
                }
            }

            LoadAllClinicDoctorAdvices();
        }

        private void m_editBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIClinicDoctorWorkVM;
            if (vm == null)
                return;

            int SelectNum = 0;
            CommContracts.ClinicDoctorAdvice EditAdvice = new CommContracts.ClinicDoctorAdvice();

            foreach (DoctorAdviceView tem in m_DoctorAdvicePanel.Children)
            {
                if (tem.IsChecked)
                {
                    SelectNum++;
                    EditAdvice = tem.ClinicDoctorAdvice;
                }
            }

            if(SelectNum == 1)
            {
                vm.CurrentClinicDoctorAdvice = EditAdvice;
                var window = new Window();
                DoctorAdviceEditView doctorAdviceEditView = new DoctorAdviceEditView();
                doctorAdviceEditView.DataContext = this.DataContext;

                // 这里最好能够让界面弹出在父窗口正中心位置
                window.Content = doctorAdviceEditView;
                window.Width = 880;
                window.Height = 700;

                if (window.ShowDialog().Value == true)
                {
                    //var tem = doctorAdviceEditView.CurrentClinicDoctorAdvice;
                    //ClinicDoctorAdviceList.Add(tem);
                    LoadAllClinicDoctorAdvices();
                }
            }
            else
            {
                MessageBox.Show("请选择一个医嘱进行修改操作！");
                return;
            }


        }

        private void m_printBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
