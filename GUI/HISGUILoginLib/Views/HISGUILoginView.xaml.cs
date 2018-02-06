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
using HISGUILoginLib.ViewModels;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

namespace HISGUILoginLib.Views
{
    [Export]
    [Export("HISGUILoginView", typeof(HISGUILoginView))]
    public partial class HISGUILoginView : HISGUIViewBase
    {
        public HISGUILoginView()
        {
            InitializeComponent();
            this.Loaded += Login_Loaded;
        }

        private void Login_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUILoginVM;
            this.UserNameBox.Clear();
            this.passbox.Clear();
            this.loginResult.Text = "";
        }

        [Import]
        private HISGUILoginVM ImportVM
        {
            set { this.VM = value; }
        }


        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUILoginVM;
            this.loginResult.Text = "";
            if (string.IsNullOrEmpty(UserNameBox.Text.Trim()))
            {
                this.loginResult.Text = "用户名不能为空";
                return;
            }

            if(string.IsNullOrEmpty(this.passbox.Password.Trim()))
            {
                this.loginResult.Text = "密码不能为空";
                return;
            }

            byte[] result = Encoding.Default.GetBytes(this.passbox.Password.Trim());    //tbPass为输入密码的文本框  
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string strPassWrod = BitConverter.ToString(output);

            bool? loginResult = vm?.Login(UserNameBox.Text.Trim(), strPassWrod);
            if (!(loginResult.HasValue && loginResult.Value))
            {
                this.loginResult.Text = "用户名或者密码错误";
                return;
            }
            else
            {
                string json_out = JsonConvert.SerializeObject(vm.CurrentUser);
                vm?.MainData.SetToken("LoginUser", json_out);
                vm?.RegionManager.RequestNavigate("DownRegion", "HISGUISetView");
            }
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
