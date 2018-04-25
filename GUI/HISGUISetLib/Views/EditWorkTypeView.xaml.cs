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
    /// EditWorkTypeView.xaml 的交互逻辑
    /// </summary>
    public partial class EditWorkTypeView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.WorkType m_WorkType;
        public EditWorkTypeView(CommContracts.WorkType WorkType = null)
        {
            InitializeComponent();
            bIsEdit = false;
            if (WorkType != null)
            {
                this.m_WorkType = WorkType;
                this.NameEdit.Text = WorkType.Name;
                bIsEdit = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameEdit.Text.Trim()))
            {
                return;
            }


            if (bIsEdit)
            {
                m_WorkType.Name = this.NameEdit.Text;

                CommClient.WorkType WorkTypeClient = new CommClient.WorkType();
                if (WorkTypeClient.UpdateWorkType(m_WorkType))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.WorkType WorkType = new CommContracts.WorkType();
                WorkType.Name = this.NameEdit.Text;

                CommClient.WorkType WorkTypeClient = new CommClient.WorkType();
                if (WorkTypeClient.SaveWorkType(WorkType))
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
