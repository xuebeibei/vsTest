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
using HISGUITriageLib.ViewModels;
using System.Data;

namespace HISGUITriageLib.Views
{
    [Export]
    [Export("TriageView", typeof(TriageView))]
    public partial class TriageView : HISGUIViewBase
    {
        public TriageView()
        {
            InitializeComponent();
            this.Loaded += Triage_Loaded;
        }

        [Import]
        private TriageVM ImportVM
        {
            set { this.VM = value; }
        }

        private void Triage_Loaded(object sender, RoutedEventArgs e)
        {
            ShowAllRegistration();
        }

        private void ShowAllRegistration()
        {
            var vm = this.DataContext as TriageVM;

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary = vm?.GetAllUnTriagePatient();

            List<PatientMsgBox> list = new List<PatientMsgBox>();
            if (dictionary != null)
            {
                for (int i = 0; i < dictionary.Count(); i++)
                {
                    // 实例化一个控件
                    list.Add(new PatientMsgBox(dictionary.ElementAt(i).Key, dictionary.ElementAt(i).Value));
                }

                this.aaa.ItemsSource = list;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.aaa.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择患者!");
                return;
            }

            var vm = this.DataContext as TriageVM;
            //if(vm?.CurrentPatientList == null)
            //{

            //}
            //vm?.CurrentPatientList.Clear();
            List<int> list = new List<int>();
            for (int i = 0; i < this.aaa.SelectedItems.Count; i++)
            {
                PatientMsgBox aa = this.aaa.SelectedItems[i] as PatientMsgBox;
                if (aa != null)
                {
                    list.Add(aa.ID);
                }
            }

            vm?.setList(list);

            vm?.SelectDoctor();
        }
    }
}
