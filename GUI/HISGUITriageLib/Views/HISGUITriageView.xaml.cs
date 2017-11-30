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
    [Export("HISGUITriageView", typeof(HISGUITriageView))]
    public partial class HISGUITriageView : HISGUIViewBase
    {
        public HISGUITriageView()
        {
            InitializeComponent();
            this.Loaded += Triage_Loaded;
        }

        [Import]
        private HISGUITriageVM ImportVM
        {
            set { this.VM = value; }
        }

        private void Triage_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUITriageVM;

            Dictionary<int, string> list = new Dictionary<int, string>();
            list = vm?.GetAllUnTriagePatient();

            if (list != null)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    // 实例化一个控件
                    PatientMsgBox msgBox = new PatientMsgBox(list.ElementAt(i).Value);

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
