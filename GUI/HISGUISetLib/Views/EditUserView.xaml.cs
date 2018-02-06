﻿using System;
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
    /// <summary>
    /// EditUserView.xaml 的交互逻辑
    /// </summary>
    public partial class EditUserView : UserControl
    {
        private bool bIsEdit;
        private CommContracts.User User;
        public EditUserView(CommContracts.User user = null)
        {
            InitializeComponent();
            CommClient.Employee myd = new CommClient.Employee();
            EmployeeCombo.ItemsSource = myd.GetAllEmployee();

            StatusCombo.ItemsSource = Enum.GetValues(typeof(CommContracts.LoginStatus));
            StatusCombo.SelectedItem = CommContracts.LoginStatus.logout;

            PasswordLabel.Content = "密码：";
            bIsEdit = false;
            if (user != null)
            {
                PasswordLabel.Content = "新密码：";
                this.User = user;
                this.NameEdit.Text = user.Username;
                this.Password.Password = "";
                
                this.StatusCombo.SelectedItem = user.Status;
                this.EmployeeCombo.SelectedItem = user.Employee; // 不起作用，未知原因
                bIsEdit = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameEdit.Text.Trim()))
            {
                return;
            }

            if (this.StatusCombo.SelectedItem == null)
            {
                return;
            }

            if (this.EmployeeCombo.SelectedItem == null)
                return;

            if (bIsEdit)
            {
                User.Username = this.NameEdit.Text.Trim();

                if(!string.IsNullOrEmpty(this.Password.Password.Trim()))
                {
                    byte[] result = Encoding.Default.GetBytes(this.Password.Password.Trim());    //tbPass为输入密码的文本框  
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] output = md5.ComputeHash(result);
                    string strPassWrod = BitConverter.ToString(output);

                    User.Password = strPassWrod;
                }
                

                User.Status = (CommContracts.LoginStatus)this.StatusCombo.SelectedItem;
                User.EmployeeID = ((CommContracts.Employee)this.EmployeeCombo.SelectedItem).ID;

                CommClient.User myd = new CommClient.User();
                if (myd.UpdateLoginUser(User))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.User user = new CommContracts.User();
                user.Username = this.NameEdit.Text.Trim();
                byte[] result = Encoding.Default.GetBytes(this.Password.Password.Trim());    //tbPass为输入密码的文本框  
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] output = md5.ComputeHash(result);
                string strPassWrod = BitConverter.ToString(output);

                user.Password = strPassWrod;
                user.Status = (CommContracts.LoginStatus)this.StatusCombo.SelectedItem;
                user.EmployeeID = ((CommContracts.Employee)this.EmployeeCombo.SelectedItem).ID;

                CommClient.User myd = new CommClient.User();
                if (myd.SaveLoginUser(user))
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
