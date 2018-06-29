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
    [Export("DoctorAdviceEditView", typeof(DoctorAdviceEditView))]
    public partial class DoctorAdviceEditView : HISGUIViewBase
    {
        private List<CommContracts.DoctorAdviceDetailGroup> m_DoctorAdviceGrouplist;
        public DoctorAdviceEditView()
        {
            InitializeComponent();
            this.Loaded += DoctorAdviceEditView_Loaded;
        }

        private void DoctorAdviceEditView_Loaded(object sender, RoutedEventArgs e)
        {
            LoadComboBox();
            LoadDoctorAdvices();
            m_DoctorAdviceGrouplist = new List<CommContracts.DoctorAdviceDetailGroup>();
            
        }

        private void LoadDoctorAdvices()
        {
            var vm = this.DataContext as HISGUIClinicDoctorWorkVM;
            if (vm == null)
                return;

            if (vm.CurrentClinicDoctorAdvice == null)
                return;

            m_DoctorAdviceTypeCombo.SelectedItem = vm.CurrentClinicDoctorAdvice.DoctorAdviceType;
            m_开单日期.SelectedDate = vm.CurrentClinicDoctorAdvice.StartTime;
            m_诊断Panel.Children.Clear();
            if(vm.CurrentClinicDoctorAdvice.ClinicDoctorAdvice_DiagnoseItems != null)
            {
                foreach (CommContracts.ClinicDoctorAdvice_DiagnoseItem dia in vm.CurrentClinicDoctorAdvice.ClinicDoctorAdvice_DiagnoseItems)
                {
                    if (dia.DiagnoseItem == null)
                        continue;

                    DiagnoseItemControl diagnoseItemControl = new DiagnoseItemControl(dia.DiagnoseItem);
                    m_诊断Panel.Children.Add(diagnoseItemControl);
                }
            }
            

            if (vm.CurrentClinicDoctorAdvice != null)
            {
                m_myGridView.ItemsSource = vm.CurrentClinicDoctorAdvice.DoctorAdviceDetailGroups;
            }
        }

        private void LoadComboBox()
        {
            var vm = this.DataContext as HISGUIClinicDoctorWorkVM;
            if (vm == null)
                return;
            m_DoctorAdviceTypeCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.DoctorAdviceItemType));

            List< CommContracts.AdministrationRoute> administrationRoutelist = new List<CommContracts.AdministrationRoute>();
            administrationRoutelist = vm.getAllAdministrationRoute();

            m_AdministrationRouteComBox.ItemsSource = administrationRoutelist;

            List<CommContracts.Frequency> frequencylist = new List<CommContracts.Frequency>();

            frequencylist = vm.getAllFrequency();
            m_FrequencyComBox.ItemsSource = frequencylist;
        }


        [Import]
        private HISGUIClinicDoctorWorkVM ImportVM
        {
            set { this.VM = value; }
        }

        private void 诊断搜索KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string str = this.m_诊断搜索Text.Text;
                DiagnoseItemFindView view = new DiagnoseItemFindView(str);
                //view.WindowStartupLocation = WindowStartupLocation.Manual;
                //view.Left = 0;
                //view.Top = 0;
                // 获得搜索文本控件的屏幕绝对坐标，固定搜索框位置
                view.Focus();
                bool? bResult = view.ShowDialog();


                if (bResult.HasValue)
                {
                    if (bResult.Value == true)
                    {
                        DiagnoseItemControl itemControl = new DiagnoseItemControl(view.CurrentZhenDuan);
                        this.m_诊断Panel.Children.Add(itemControl);
                    }
                }
            }

        }

        private void AdviceFindKeyUp(object sender, KeyEventArgs e)
        {

            var vm = this.DataContext as HISGUIClinicDoctorWorkVM;
            if (vm == null)
                return;

            if (e.Key == Key.Enter)
            {
                string str = this.m_诊断搜索Text.Text;
                DoctorAdviceItemFindView view = new DoctorAdviceItemFindView(str);
                //view.WindowStartupLocation = WindowStartupLocation.Manual;
                //view.Left = 0;
                //view.Top = 0;
                // 获得搜索文本控件的屏幕绝对坐标，固定搜索框位置
                view.Focus();
                bool? bResult = view.ShowDialog();


                if (bResult.HasValue)
                {
                    if (bResult.Value == true)
                    {
                        vm.CurrentAdviceItem = view.CurrentAdviceItem;

                        // 将光标移动到下一个控件上
                        TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);

                        UIElement focusElement = Keyboard.FocusedElement as UIElement;
                        if (focusElement != null)
                        {
                            focusElement.MoveFocus(request);
                        }
                        e.Handled = true;

                        this.m_DayNumText.Text = "1";
                        this.m_SingleDoseText.Text = vm.CurrentAdviceItem.MinPackageNum.ToString();
                    }
                }
            }
        }

        private void 暂存BtnClicked(object sender, RoutedEventArgs e)
        {
            m_myGridView.ItemsSource = null;

            //将数据添加到列表中
            var temAdministrationRoute = this.m_AdministrationRouteComBox.SelectedItem as CommContracts.AdministrationRoute;
            if (temAdministrationRoute == null)
                return;

            var nDay = int.Parse(this.m_DayNumText.Text);
            var temFrequency = this.m_FrequencyComBox.SelectedItem as CommContracts.Frequency;
            if (temFrequency == null)
                return;

            var zongliang = this.m_totalNumText.Text;

            var vm = this.DataContext as HISGUIClinicDoctorWorkVM;
            if (vm == null)
                return;

            if (vm.CurrentAdviceItem == null)
                return;


            CommContracts.DoctorAdviceDetailGroup zu1 = new CommContracts.DoctorAdviceDetailGroup();

            //zu1.Usage = new CommContracts.Usage()
            //{
            //    AdministrationRoute = temAdministrationRoute,
            //    DayNum = nDay,
            //    Frequency = temFrequency
            //};

            zu1.GroupNum = m_DoctorAdviceGrouplist.Count()+1;
            List<CommContracts.DoctorAdviceDetail> items = new List<CommContracts.DoctorAdviceDetail>();
            items.Add(new CommContracts.DoctorAdviceDetail()
            {
                DoctorAdviceItem = vm.CurrentAdviceItem,
                TotalNum = int.Parse(this.m_totalNumText.Text),
                SignalDose = decimal.Parse(this.m_SingleDoseText.Text)
            });
            zu1.DoctorAdviceItems = items;

            m_DoctorAdviceGrouplist.Add(zu1);
            m_myGridView.ItemsSource = m_DoctorAdviceGrouplist;

            vm.CurrentAdviceItem = null;
            this.m_SingleDoseText.Text = "";
            m_AdministrationRouteComBox.SelectedItem = null;
            m_FrequencyComBox.SelectedItem = null;
            m_DayNumText.Text = "";
            m_totalNumText.Text = "";
        }

        private void FrequencySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTotalNumText();
        }

        private void 剂量数Changed(object sender, TextChangedEventArgs e)
        {
            UpdateTotalNumText();
        }

        private void DayNumChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTotalNumText();
        }

        private void UpdateTotalNumText()
        {
            try
            {
                var vm = this.DataContext as HISGUIClinicDoctorWorkVM;

                var frequencyItem = this.m_FrequencyComBox.SelectedItem as CommContracts.Frequency;

                decimal frequencyNum = frequencyItem.CoefficientNum;
                var DayNum = int.Parse(this.m_DayNumText.Text); 
                var SingleDose = decimal.Parse(m_SingleDoseText.Text);
                var SellPackageNum = vm.CurrentAdviceItem.MinPackageNum * vm.CurrentAdviceItem.ScalingFactor;

                var result = Math.Ceiling(SingleDose * frequencyNum * DayNum / SellPackageNum);
                this.m_totalNumText.Text = result.ToString();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void SaveBtnClicked(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIClinicDoctorWorkVM;

            if (vm == null)
                return;

            var DoctorAdviceType = m_DoctorAdviceTypeCombo.SelectedItem;
            if (DoctorAdviceType == null)
                return;

            CommContracts.ClinicDoctorAdvice clinicDoctorAdvice = new CommContracts.ClinicDoctorAdvice();
            if(vm.ClinicDoctorAdviceList != null)
                clinicDoctorAdvice.ID = vm.ClinicDoctorAdviceList.Count+1;
            else
                clinicDoctorAdvice.ID = 1;
            clinicDoctorAdvice.DoctorAdviceType = (CommContracts.DoctorAdviceItemType)DoctorAdviceType;
            clinicDoctorAdvice.StartTime = m_开单日期.SelectedDate.Value;
            clinicDoctorAdvice.DoctorName = m_医生Text.Text;
            clinicDoctorAdvice.DepartmentName = m_科室Text.Text;

            clinicDoctorAdvice.IsExigence = m_紧急CheckBox.IsChecked.Value;
            clinicDoctorAdvice.ClinicRegistrationID = vm.CurrentClinicRegistration.ID;

            List<CommContracts.ClinicDoctorAdvice_DiagnoseItem> DiagnoseItemDetaillist = new List<CommContracts.ClinicDoctorAdvice_DiagnoseItem>();
            foreach(DiagnoseItemControl temItemControl in this.m_诊断Panel.Children)
            {
                var item = temItemControl.CurrentDiagnoseItem;
                CommContracts.ClinicDoctorAdvice_DiagnoseItem detail = new CommContracts.ClinicDoctorAdvice_DiagnoseItem();
                detail.DiagnoseItemID = item.ID;
                detail.DiagnoseItem = item;

                DiagnoseItemDetaillist.Add(detail);
            }
            clinicDoctorAdvice.ClinicDoctorAdvice_DiagnoseItems = DiagnoseItemDetaillist;

            clinicDoctorAdvice.DoctorAdviceDetailGroups = this.m_DoctorAdviceGrouplist;
            clinicDoctorAdvice.UpdateTime = DateTime.Now;

            //CurrentClinicDoctorAdvice = clinicDoctorAdvice;

            //if(vm.SaveClinicDoctorAdvice(clinicDoctorAdvice))
            //{
            //    var window = this.Parent as Window;
            //    window.DialogResult = true;
            //    window.Close();
            //}
            List<CommContracts.ClinicDoctorAdvice> list = new List<CommContracts.ClinicDoctorAdvice>();
            if(vm.ClinicDoctorAdviceList == null)
            {
                list.Add(clinicDoctorAdvice);
                vm.ClinicDoctorAdviceList = list;
            }
            else
            {
                vm.ClinicDoctorAdviceList.Add(clinicDoctorAdvice);
            }

            var window = this.Parent as Window;
            window.DialogResult = true;
            window.Close();
        }

        private void CancelBtnClicked(object sender, RoutedEventArgs e)
        {
            var window = this.Parent as Window;
            window.DialogResult = false;
            window.Close();
        }
    }
}
