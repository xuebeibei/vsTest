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
    /// EditDepartmentView.xaml 的交互逻辑
    /// </summary>
    public partial class EditDepartmentView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.Department Department;
        public EditDepartmentView(CommContracts.Department department = null)
        {
            InitializeComponent();

            DepartmentCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.DepartmentEnum));
            DepartmentCombo.SelectedItem = CommContracts.DepartmentEnum.其他科室;
            bIsEdit = false;
            if (department != null)
            {
                this.Department = department;
                this.NameEdit.Text = department.Name;
                this.AbbrEdit.Text = department.Abbr;
                this.DepartmentCombo.SelectedItem = department.DepartmentEnum;
                bIsEdit = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(this.NameEdit.Text.Trim()))
            {
                return;
            }

            if(this.DepartmentCombo.SelectedItem == null)
            {
                return;
            }
            if(bIsEdit)
            {
                Department.Name = this.NameEdit.Text.Trim();
                Department.Abbr = this.AbbrEdit.Text.Trim();
                Department.DepartmentEnum = (CommContracts.DepartmentEnum)this.DepartmentCombo.SelectedItem;

                CommClient.Department myd = new CommClient.Department();
                if (myd.UpdateDepartment(Department))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.Department department = new CommContracts.Department();
                department.Name = this.NameEdit.Text.Trim();
                department.Abbr = this.AbbrEdit.Text.Trim();
                department.DepartmentEnum = (CommContracts.DepartmentEnum)this.DepartmentCombo.SelectedItem;

                CommClient.Department myd = new CommClient.Department();
                if (myd.SaveDepartment(department))
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
