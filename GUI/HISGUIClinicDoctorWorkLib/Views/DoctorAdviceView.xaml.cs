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
    /// <summary>
    /// DoctorAdviceView.xaml 的交互逻辑
    /// </summary>
    public partial class DoctorAdviceView : UserControl
    {
        public bool IsChecked { get; set; }
        public CommContracts.ClinicDoctorAdvice ClinicDoctorAdvice { get; set; }
        public DoctorAdviceView(CommContracts.ClinicDoctorAdvice clinicDoctorAdvice)
        {
            InitializeComponent();
            ClinicDoctorAdvice = clinicDoctorAdvice;

            m_开医嘱时间Text.Text = clinicDoctorAdvice.StartTime.ToString();
            m_医嘱单Text.Text = clinicDoctorAdvice.ID.ToString();

            m_myGridView.ItemsSource = clinicDoctorAdvice.DoctorAdviceDetailGroups;
        }

        private void m_选择CheckBo_Checked(object sender, RoutedEventArgs e)
        {
            IsChecked = m_选择CheckBo.IsChecked.Value;
        }
    }
}
