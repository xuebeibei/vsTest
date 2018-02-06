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
    /// EditJobView.xaml 的交互逻辑
    /// </summary>
    public partial class EditJobView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.Job Job;
        public EditJobView(CommContracts.Job job = null)
        {
            InitializeComponent();
            JobCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.JobEnum));
            JobCombo.SelectedItem = CommContracts.JobEnum.初级;
            PowerEnum.ItemsSource = Enum.GetValues(typeof(CommContracts.PowerEnum));
            bIsEdit = false;
            if (job != null)
            {
                this.Job = job;
                this.NameEdit.Text = job.Name;
                this.JobCombo.SelectedItem = job.JobEnum;
                this.PowerEnum.SelectedItem = job.PowerEnum;
                bIsEdit = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameEdit.Text.Trim()))
            {
                return;
            }

            if (this.JobCombo.SelectedItem == null)
            {
                return;
            }
            if (this.PowerEnum.SelectedItem == null)
                return;

            if (bIsEdit)
            {
                Job.Name = this.NameEdit.Text.Trim();
                Job.JobEnum = (CommContracts.JobEnum)this.JobCombo.SelectedItem;
                Job.PowerEnum = (CommContracts.PowerEnum)this.PowerEnum.SelectedItem;

                CommClient.Job myd = new CommClient.Job();
                if (myd.UpdateJob(Job))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.Job job = new CommContracts.Job();
                job.Name = this.NameEdit.Text.Trim();
                job.JobEnum = (CommContracts.JobEnum)this.JobCombo.SelectedItem;
                job.PowerEnum = (CommContracts.PowerEnum)this.PowerEnum.SelectedItem;

                CommClient.Job myd = new CommClient.Job();
                if (myd.SaveJob(job))
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
