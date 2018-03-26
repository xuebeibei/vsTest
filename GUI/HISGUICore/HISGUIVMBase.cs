using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using Prism.Regions;

using System.Management;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace HISGUICore
{
    public class MachineCode
    {
        static MachineCode machineCode;

        public static string GetMachineCodeString()
        {
            string machineCodeString = string.Empty;
            if (machineCode == null)
            {
                machineCode = new MachineCode();
            }
            machineCodeString = "PC." + machineCode.GetCpuInfo() + "." +
                                machineCode.GetHDid() + "." +
                                machineCode.GetMoAddress();
            return machineCodeString;
        }

        ///   <summary>   
        ///   获取cpu序列号       
        ///   </summary>   
        ///   <returns> string </returns>   
        public string GetCpuInfo()
        {
            string cpuInfo = "";
            try
            {
                using (ManagementClass cimobject = new ManagementClass("Win32_Processor"))
                {
                    ManagementObjectCollection moc = cimobject.GetInstances();

                    foreach (ManagementObject mo in moc)
                    {
                        cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                        mo.Dispose();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return cpuInfo.ToString();
        }

        ///   <summary>   
        ///   获取硬盘ID       
        ///   </summary>   
        ///   <returns> string </returns>   
        public string GetHDid()
        {
            string HDid = "";
            try
            {
                using (ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive"))
                {
                    ManagementObjectCollection moc1 = cimobject1.GetInstances();
                    foreach (ManagementObject mo in moc1)
                    {
                        HDid = (string)mo.Properties["Model"].Value;
                        mo.Dispose();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return HDid.ToString();
        }

        ///   <summary>   
        ///   获取网卡硬件地址   
        ///   </summary>   
        ///   <returns> string </returns>   
        public string GetMoAddress()
        {
            string MoAddress = "";
            try
            {
                using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
                {
                    ManagementObjectCollection moc2 = mc.GetInstances();
                    foreach (ManagementObject mo in moc2)
                    {
                        if ((bool)mo["IPEnabled"] == true)
                            MoAddress = mo["MacAddress"].ToString();
                        mo.Dispose();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return MoAddress.ToString();
        }
    }

    public class HISGUIVMBase : DependencyObject
    {
        [Import]
        public IRegionManager RegionManager { get; private set; }

        public virtual void RegisterEvents()
        {

        }

        public virtual void UnRegisterEvents()
        {

        }

        public virtual void RegisterCommands()
        {

        }

        public bool Logout(CommContracts.User user)
        {
            CommClient.User myd = new CommClient.User();
            return myd.Logout(user, MachineCode.GetMachineCodeString());
        }

        #region MainData

        public static readonly DependencyProperty MainDataProperty = DependencyProperty.Register("MainData",
            typeof(JObject), typeof(HISGUIVMBase),
            new PropertyMetadata(HISGUIPublicDatas.Instance.MainData, (sender, e) => { }));

        public JObject MainData
        {
            get { return GetValue(MainDataProperty) as JObject; }
            set { SetValue(MainDataProperty, value); }
        }

        #endregion

        #region CurrentUser
        public static readonly DependencyProperty CurrentUserProperty = DependencyProperty.Register(
            "CurrentUser", typeof(CommContracts.User), typeof(HISGUIVMBase), new PropertyMetadata((sender, e) => { }));

        public CommContracts.User CurrentUser
        {
            get { return (CommContracts.User)GetValue(CurrentUserProperty); }
            set { SetValue(CurrentUserProperty, value); }
        }
        #endregion

        public HISGUIVMBase()
        {
            RegisterCommands();
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.RegisterEvents();
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            this.UnRegisterEvents();
        }
    }
}
