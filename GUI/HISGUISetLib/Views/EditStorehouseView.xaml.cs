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
    /// EditStorehouseView.xaml 的交互逻辑
    /// </summary>
    public partial class EditStorehouseView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.StoreRoom StoreRoom;
        public EditStorehouseView(CommContracts.StoreRoom storeRoom = null)
        {
            InitializeComponent();
            StoreRoomCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.StoreRoomEnum));
            StoreRoomCombo.SelectedItem = CommContracts.StoreRoomEnum.一级库;
            bIsEdit = false;
            if (storeRoom != null)
            {
                this.StoreRoom = storeRoom;
                this.NameEdit.Text = storeRoom.Name;
                this.StoreRoomCombo.SelectedItem = storeRoom.StoreRoomEnum;
                bIsEdit = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameEdit.Text.Trim()))
            {
                return;
            }

            if (this.StoreRoomCombo.SelectedItem == null)
            {
                return;
            }
            if (bIsEdit)
            {
                StoreRoom.Name = this.NameEdit.Text.Trim();
                StoreRoom.StoreRoomEnum = (CommContracts.StoreRoomEnum)this.StoreRoomCombo.SelectedItem;

                CommClient.StoreRoom myd = new CommClient.StoreRoom();
                if (myd.UpdateStoreRoom(StoreRoom))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.StoreRoom department = new CommContracts.StoreRoom();
                department.Name = this.NameEdit.Text.Trim();
                department.StoreRoomEnum = (CommContracts.StoreRoomEnum)this.StoreRoomCombo.SelectedItem;

                CommClient.StoreRoom myd = new CommClient.StoreRoom();
                if (myd.SaveStoreRoom(department))
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
