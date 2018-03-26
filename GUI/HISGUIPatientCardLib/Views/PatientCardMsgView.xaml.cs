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
using HISGUIPatientCardLib.ViewModels;
using System.Data;
using Newtonsoft.Json;
using System.IO;

namespace HISGUIPatientCardLib.Views
{

    [Export]
    [Export("PatientCardMsgView", typeof(PatientCardMsgView))]
    public partial class PatientCardMsgView : HISGUIViewBase
    {
        CommContracts.PatientCardManage PatientCardManage;
        
        public PatientCardMsgView()
        {
            InitializeComponent();
            this.YBCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.YbEnum));

            PatientCardManage = new CommContracts.PatientCardManage();
            this.Loaded += PatientCardMsgView_Loaded;
        }

        [Import]
        private HISGUIPatientCardVM ImportVM
        {
            set { this.VM = value; }
        }

        private void PatientCardMsgView_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIPatientCardVM;

            CommContracts.Patient patient = new CommContracts.Patient();
            vm.CurrentPatient = patient;

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIPatientCardVM;

            // 办理普通卡
            VisualStateManager.GoToState(this, "VisualState", false);
            YBCombo.SelectedItem = null;
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            // 办理临时卡
            VisualStateManager.GoToState(this, "VisualState1", false);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateYbType();
        }

        private void updateYbType()
        {
            if (YBCombo.SelectedItem == null)
            {
                VisualStateManager.GoToState(this, "VisualState2", false);
                return;
            }
                

            var current = (CommContracts.YbEnum)YBCombo.SelectedItem;

            if (current == CommContracts.YbEnum.自费)
            {
                VisualStateManager.GoToState(this, "VisualState2", false);
            }
            else if (current == CommContracts.YbEnum.城镇职工 || current == CommContracts.YbEnum.城乡居民)
            {
                VisualStateManager.GoToState(this, "VisualState3", false);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 保存
            var vm = this.DataContext as HISGUIPatientCardVM;
            var temp = vm.CurrentPatient;
            temp.Name += "";

            PatientCardManage.CardNo = temp.PatientCardNo;
            PatientCardManage.CardManageEnum = CommContracts.CardManageEnum.eNew;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // 取消
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
