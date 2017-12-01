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

            if (dictionary != null)
            {
                for (int i = 0; i < dictionary.Count(); i++)
                {
                    // 实例化一个控件
                    PatientMsgBox msgBox = new PatientMsgBox(dictionary.ElementAt(i).Value);

                    // 添加到布局中去
                    this.aaa.Children.Add(msgBox);

                    // 设置控件在布局中的位置
                    Grid.SetRow(msgBox, i / 3);
                    Grid.SetColumn(msgBox, i % 3);
                }
            }
        }
    }
}
