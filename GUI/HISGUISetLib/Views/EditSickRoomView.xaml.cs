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
    /// EditSickRoomView.xaml 的交互逻辑
    /// </summary>
    public partial class EditSickRoomView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.SickRoom SickRoom;
        public EditSickRoomView(CommContracts.SickRoom sickroom = null)
        {
            InitializeComponent();
            SickRoomCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.SickRoomEnum));
            SickRoomCombo.SelectedItem = CommContracts.SickRoomEnum.普通病房;

            CommClient.Department myd = new CommClient.Department();
            DepartmentCombo.ItemsSource = myd.getALLDepartment();

            bIsEdit = false;
            if (sickroom != null)
            {
                this.SickRoom = sickroom;
                this.NameEdit.Text = sickroom.Name;
                this.SickRoomCombo.SelectedItem = sickroom.SickRoomEnum;
                this.DepartmentCombo.SelectedItem = sickroom.Department;
                this.AddressEdit.Text = sickroom.Address;
                bIsEdit = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameEdit.Text.Trim()))
            {
                return;
            }

            if (this.SickRoomCombo.SelectedItem == null)
            {
                return;
            }

            if (this.DepartmentCombo.SelectedItem == null)
                return;

            if (bIsEdit)
            {
                SickRoom.Name = this.NameEdit.Text.Trim();
                SickRoom.SickRoomEnum = (CommContracts.SickRoomEnum)this.SickRoomCombo.SelectedItem;
                var department = (CommContracts.Department)this.DepartmentCombo.SelectedItem;
                SickRoom.DepartmentID = department.ID;
                SickRoom.Address = this.AddressEdit.Text.Trim();

                CommClient.SickRoom myd = new CommClient.SickRoom();
                if (myd.UpdateSickRoom(SickRoom))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.SickRoom sickroom = new CommContracts.SickRoom();
                sickroom.Name = this.NameEdit.Text.Trim();
                sickroom.SickRoomEnum = (CommContracts.SickRoomEnum)this.SickRoomCombo.SelectedItem;
                var department = (CommContracts.Department)this.DepartmentCombo.SelectedItem;
                sickroom.DepartmentID = department.ID;
                sickroom.Address = this.AddressEdit.Text.Trim();

                CommClient.SickRoom myd = new CommClient.SickRoom();
                if (myd.SaveSickRoom(sickroom))
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
