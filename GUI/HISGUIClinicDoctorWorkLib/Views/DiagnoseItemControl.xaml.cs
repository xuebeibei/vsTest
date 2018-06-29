using System;
using System.Collections.Generic;
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

namespace HISGUIClinicDoctorWorkLib.Views
{
    public partial class DiagnoseItemControl : UserControl
    {
        public CommContracts.DiagnoseItem CurrentDiagnoseItem { get; set; }

        public DiagnoseItemControl(CommContracts.DiagnoseItem DiagnoseItem)
        {
            InitializeComponent();
            CurrentDiagnoseItem = DiagnoseItem;
            this.m_ContentText.Text = CurrentDiagnoseItem.Name;
        }

        private void ClearBtnClicked(object sender, RoutedEventArgs e)
        {
            var parent = this.Parent as WrapPanel;
            if (parent == null)
                return;
            else
            {
                parent.Children.Remove(this);
            }
        }
    }
}
