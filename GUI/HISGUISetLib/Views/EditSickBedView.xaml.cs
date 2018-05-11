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
    /// EditSickBed.xaml 的交互逻辑
    /// </summary>
    public partial class EditSickBedView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.SickBed SickBed;
        public EditSickBedView(CommContracts.SickBed sickBed = null)
        {
            InitializeComponent();
            CommClient.Department myd = new CommClient.Department();
            CommClient.SickRoom myd1 = new CommClient.SickRoom();

            DepartmentCombo.ItemsSource = myd.getALLDepartment("");
            SickRoomCombo.ItemsSource = myd1.GetAllSickRoom();
            bIsEdit = false;
            if (sickBed != null)
            {
                this.SickBed = sickBed;
                this.NameEdit.Text = sickBed.Name;
                this.RemarksEdit.Text = sickBed.Remarks;
                this.DepartmentCombo.SelectedItem = sickBed.SickRoom.Department;
                this.SickRoomCombo.SelectedItem = sickBed.SickRoom;
                bIsEdit = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameEdit.Text.Trim()))
            {
                return;
            }

            if (this.DepartmentCombo.SelectedItem == null)
            {
                return;
            }

            if (this.SickRoomCombo.SelectedItem == null)
            {
                return;
            }

            if (bIsEdit)
            {
                SickBed.Name = this.NameEdit.Text.Trim();
                SickBed.Remarks = this.RemarksEdit.Text.Trim();
                SickBed.SickRoomID = ((CommContracts.SickRoom)this.SickRoomCombo.SelectedItem).ID;


                CommClient.SickBed myd = new CommClient.SickBed();
                if (myd.UpdateSickBed(SickBed))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.SickBed sickBed = new CommContracts.SickBed();
                sickBed.Name = this.NameEdit.Text.Trim();
                sickBed.Remarks = this.RemarksEdit.Text.Trim();
                sickBed.SickRoomID = ((CommContracts.SickRoom)this.SickRoomCombo.SelectedItem).ID;


                CommClient.SickBed myd = new CommClient.SickBed();
                if (myd.SaveSickBed(sickBed))
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
