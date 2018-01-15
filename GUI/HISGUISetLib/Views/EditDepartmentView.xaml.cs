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
        public EditDepartmentView()
        {
            InitializeComponent();
            DepartmentCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.DepartmentEnum));
            DepartmentCombo.SelectedItem = CommContracts.DepartmentEnum.其他科室;
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

            CommContracts.Department department = new CommContracts.Department();
            department.Name = this.NameEdit.Text.Trim();

            CommClient.Department myd = new CommClient.Department();
            if(myd.SaveDepartment(department))
            {
                (this.Parent as Window).DialogResult = true;
                (this.Parent as Window).Close();
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Window).DialogResult = false;
            (this.Parent as Window).Close();
        }
    }
}
