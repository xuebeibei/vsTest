using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    public class MyMD5
    {
        public static string strToMD5Str(string str)
        {
            byte[] result = Encoding.Default.GetBytes(str);    //tbPass为输入密码的文本框  
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string strPassWrod = BitConverter.ToString(output);

            return strPassWrod;
        }
    }
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
                this.JobCombo.SelectedItem = myd2.GetCurrentJob(employee.ID);
                this.LoginNameEdit.Text = employee.LoginName;
                this.PasswordEdit.Password = "";
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

            int nCurrentSelectDepartment = ((CommContracts.Department)this.DeparmentCombo.SelectedItem).ID;
            int nCurrentSelectJob = ((CommContracts.Job)this.JobCombo.SelectedItem).ID;

            bool bIsOk = true;
            int employeeID = 0;
            if (bIsEdit)
            {
                employeeID = Employee.ID;
                Employee.Name = this.NameEdit.Text.Trim();
                Employee.Gender = (CommContracts.GenderEnum)this.GenderCombo.SelectedItem;
                Employee.LoginName = this.LoginNameEdit.Text;

                Employee.Password = MyMD5.strToMD5Str(this.PasswordEdit.Password.Trim());

                CommClient.Employee myd = new CommClient.Employee();
                if (!myd.UpdateEmployee(Employee))
                {
                    bIsOk = false;
                }

                if(bIsOk)
                {
                    if (nCurrentSelectDepartment != myd.GetCurrentDepartment(employeeID).ID)
                    {
                        bIsOk = UpdateEmployeeDepartmentHistory(employeeID, nCurrentSelectDepartment);
                    }
                }
               
                if(bIsOk)
                {
                    if (nCurrentSelectJob != myd.GetCurrentJob(employeeID).ID)
                    {
                        bIsOk = UpdateEmployeeJobHistory(employeeID, nCurrentSelectJob);
                    }
                }
            }
            else
            {
                CommContracts.Employee employee = new CommContracts.Employee();
                employee.Name = this.NameEdit.Text.Trim();
                employee.Gender = (CommContracts.GenderEnum)this.GenderCombo.SelectedItem;
                employee.LoginName = this.LoginNameEdit.Text;
                employee.Password = MyMD5.strToMD5Str(this.PasswordEdit.Password.Trim());

                CommClient.Employee myd = new CommClient.Employee();

                if (!myd.SaveEmployee(employee, ref employeeID))
                {
                    bIsOk = false;
                }

                if (bIsOk)
                {
                    bIsOk = UpdateEmployeeDepartmentHistory(employeeID, nCurrentSelectDepartment);
                }

                if (bIsOk)
                {
                    bIsOk = UpdateEmployeeJobHistory(employeeID, nCurrentSelectJob);
                }
            }
            
            
            if (bIsOk)
            {
                (this.Parent as Window).DialogResult = true;
                (this.Parent as Window).Close();
            }
        }

        private bool UpdateEmployeeDepartmentHistory(int employeeID, int demaprtmentID)
        {
            bool bIsOk = true;
            CommContracts.EmployeeDepartmentHistory history = new CommContracts.EmployeeDepartmentHistory();
            history.EmployeeID = employeeID;
            history.DepartmentID = demaprtmentID;

            CommClient.EmployeeDepartmentHistory historyClient = new CommClient.EmployeeDepartmentHistory();
            if (!historyClient.SaveEmployeeDepartmentHistory(history))
            {
                bIsOk = false;
            }

            return bIsOk;
        }

        private bool UpdateEmployeeJobHistory(int employeeID, int JobID)
        {
            bool bIsOk = true;
            CommClient.EmployeeJobHistory jobHistoryClient = new CommClient.EmployeeJobHistory();
            CommContracts.EmployeeJobHistory jobhistory = new CommContracts.EmployeeJobHistory();
            jobhistory.JobID = JobID;
            jobhistory.EmployeeID = employeeID;
            if (!jobHistoryClient.SaveEmployeeJobHistory(jobhistory))
            {
                bIsOk = false;
            }
            return bIsOk;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Window).DialogResult = false;
            (this.Parent as Window).Close();
        }
    }
}
