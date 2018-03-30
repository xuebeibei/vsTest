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
using System.IO;

namespace HISGUILoginLib.ViewModels
{
    [Export]
    [Export("HISGUILoginVM", typeof(HISGUIVMBase))]
    public class HISGUILoginVM : HISGUIVMBase
    {
        public bool Login(string UserName, string PassWord)
        {
            CommClient.User login = new CommClient.User();

            try
            {
                var tem = login.Authenticate(UserName, PassWord, MachineCode.GetMachineCodeString());
                if (tem == null)
                {
                    return false;
                }
                else
                {
                    this.CurrentUser = tem;
                    return true;
                }
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch(Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                return false;
            }
            
        }
    }
}
