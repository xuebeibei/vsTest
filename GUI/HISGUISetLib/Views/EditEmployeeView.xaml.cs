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

namespace HISGUISetLib.Views
{
    /// <summary>
    /// EditEmployeeView.xaml 的交互逻辑
    /// </summary>
    public partial class EditEmployeeView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.Employee Employee;
        public EditEmployeeView(CommContracts.Employee employee = null)
        {
            InitializeComponent();
            CommClient.Department myd = new CommClient.Department();
            CommClient.Job myd1 = new CommClient.Job();
            CommClient.Employee myd2 = new CommClient.Employee();

            GenderCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.GenderEnum));
            GenderCombo.SelectedItem = CommContracts.GenderEnum.男;
            DeparmentCombo.ItemsSource = myd.getALLDepartment("");
            JobCombo.ItemsSource = myd1.GetAllJob();
            bIsEdit = false;
            if (employee != null)
            {
                this.Employee = employee;
                this.NameEdit.Text = employee.Name;
                this.GenderCombo.SelectedItem = employee.Gender;
                this.DeparmentCombo.SelectedItem = myd2.GetCurrentDepartment(employee.ID);
                this.JobCombo.SelectedItem = employee.Job;
                bIsEdit = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameEdit.Text.Trim()))
            {
                return;
            }

            if (this.GenderCombo.SelectedItem == null)
            {
                return;
            }

            if (this.DeparmentCombo.SelectedItem == null)
            {
                return;
            }

            if (this.JobCombo.SelectedItem == null)
            {
                return;
            }

            CommClient.EmployeeDepartmentHistory historyClient = new CommClient.EmployeeDepartmentHistory();
            CommContracts.EmployeeDepartmentHistory history = new CommContracts.EmployeeDepartmentHistory();
            history.DepartmentID = ((CommContracts.Department)this.DeparmentCombo.SelectedItem).ID;
            history.EmployeeID = Employee.ID;
            if (!historyClient.SaveEmployeeDepartmentHistory(history))
            {
                return;
            }

            if (bIsEdit)
            {
                Employee.Name = this.NameEdit.Text.Trim();
                Employee.Gender = (CommContracts.GenderEnum)this.GenderCombo.SelectedItem;
                Employee.JobID = ((CommContracts.Job)this.JobCombo.SelectedItem).ID;

                CommClient.Employee myd = new CommClient.Employee();
                if (myd.UpdateEmployee(Employee))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.Employee employee = new CommContracts.Employee();
                employee.Name = this.NameEdit.Text.Trim();
                employee.Gender = (CommContracts.GenderEnum)this.GenderCombo.SelectedItem;
                employee.JobID = ((CommContracts.Job)this.JobCombo.SelectedItem).ID;

                CommClient.Employee myd = new CommClient.Employee();
                if (myd.SaveEmployee(employee))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Window).DialogResult = false;
            (this.Parent as Window).Close();
        }
    }
}
