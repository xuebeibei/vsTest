﻿using System;
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
        public bool Login(string UserName, string PassWord)
        {
            CommClient.Log  log = CommClient.Log.getInstance("C://");
            CommClient.User login = new CommClient.User();
            log.write("begin login.Authenticate");
            var tem = login.Authenticate(UserName, PassWord);
            if (tem == null)
            {
                log.write("end login.Authenticate return null return false");
                return false;
            }
            else
            {
                CurrentUser = tem;
                log.write("end login.Authenticate return user return true");
                return true;
            }
        }
    }
}
