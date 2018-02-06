using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Xml;
using HISGUILoginLib;
using HISGUICore;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace HISGUILoginLib.ViewModels
{
    [Export]
    [Export("HISGUILoginVM", typeof(HISGUIVMBase))]
    public class HISGUILoginVM : HISGUIVMBase
    {


        public static readonly DependencyProperty LogNameProperty = DependencyProperty.Register(
           "LogName", typeof(string), typeof(HISGUILoginVM), new PropertyMetadata((sender, e) => { }));

        public string LogName
        {
            get { return (string)GetValue(LogNameProperty); }
            set { SetValue(LogNameProperty, value); }
        }


        #region UserName
        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register(
            "UserName", typeof(string), typeof(HISGUILoginVM), new PropertyMetadata((sender, e) => { }));

        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        #endregion
        #region PassWord
        public static readonly DependencyProperty PassWordProperty = DependencyProperty.Register(
            "PassWord", typeof(string), typeof(HISGUILoginVM), new PropertyMetadata((sender, e) => { }));

        public string PassWord
        {
            get { return (string)GetValue(PassWordProperty); }
            set { SetValue(PassWordProperty, value); }
        }
        #endregion

        #region CurrentUser
        public static readonly DependencyProperty CurrentUserProperty = DependencyProperty.Register(
            "CurrentUser", typeof(CommContracts.User), typeof(HISGUILoginVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.User CurrentUser
        {
            get { return (CommContracts.User)GetValue(CurrentUserProperty); }
            set { SetValue(CurrentUserProperty, value); }
        }
        #endregion

        public bool Login()
        {
            CommClient.User login = new CommClient.User(UserName, PassWord);

            var tem = login.Authenticate();
            if (tem == null)
            {
                return false;
            }
            else
            {
                CurrentUser = tem;
                return true;
            }
        }
    }
}
