using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition;
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
using Microsoft.Practices.ServiceLocation;
using Prism.Regions;
using HISGUICore;
using HISGUISetLib.ViewModels;
using System.Data;
using HISGUICore.MyContorls;
using Microsoft.Win32;

namespace HISGUISetLib.Views
{
    [Export]
    [Export("UserSetView", typeof(UserSetView))]
    public partial class UserSetView : HISGUIViewBase
    {
        public UserSetView()
        {
            InitializeComponent();
            this.Loaded += UserSetView_Loaded;
        }

        private void UserSetView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAllDate();
        }

        [Import]
        private HISGUISetVM ImportVM
        {
            set { this.VM = value; }
        }

        private void AllUserList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void FindItemBtn_Click(object sender, RoutedEventArgs e)
        {
            string strName = this.FindItemNameBox.Text.Trim();
            UpdateAllDate(strName);
        }

        private void NewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            // 新增用户
            var window = new Window();

            EditUserView eidtUser = new EditUserView();
            window.Content = eidtUser;
            window.Width = 400;
            window.Height = 500;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("用户新建完成！");
                UpdateAllDate();
            }
        }

        private void DeleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = this.AllUserList.SelectedItem as CommContracts.User;
            if (currentUser == null)
                return;

            if (MessageBox.Show("确认删除该用户？", "删除", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var vm = this.DataContext as HISGUISetVM;
                bool? bIsOK = vm?.DeleteUser(currentUser.ID);
                if (bIsOK.HasValue)
                {
                    if (bIsOK.Value)
                    {
                        MessageBox.Show("用户删除完成！");
                        UpdateAllDate();
                    }
                }
            }
        }

        private void EditItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = this.AllUserList.SelectedItem as CommContracts.User;
            if (temp == null)
                return;

            // 新增用户
            var window = new Window();

            EditUserView eidtUser = new EditUserView(temp);
            window.Content = eidtUser;
            window.Width = 400;
            window.Height = 500;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("用户修改完成！");
                UpdateAllDate();
            }
        }

        private void ExportItemBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImportItemBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateAllDate(string strName = "")
        {
            var vm = this.DataContext as HISGUISetVM;
            this.AllUserList.ItemsSource = vm?.GetAllUser(strName);
        }
    }
}
