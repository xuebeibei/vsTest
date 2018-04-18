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

namespace HISGUICore.MyContorls
{
    public partial class DoctorFind : UserControl
    {
        public CommContracts.Employee SelectDoctor { get; set; }
        public DoctorFind()
        {
            InitializeComponent();

            this.Loaded += Button_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CommClient.Employee myd = new CommClient.Employee();
            // 得到医生
            CommClient.EmployeeDepartmentHistory historyClient = new CommClient.EmployeeDepartmentHistory();
            List<CommContracts.Employee> listOfSignalSource = historyClient.GetAllDepartmentEmployee(0);

            this.listView1.ItemsSource = listOfSignalSource;
            SelectDoctor = new CommContracts.Employee();
        }

        private void listView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CommContracts.Employee aa = this.listView1.SelectedItem as CommContracts.Employee;
            SelectDoctor = aa;
            (this.Parent as Window).DialogResult = true;
            (this.Parent as Window).Close();
        }
    }
}
