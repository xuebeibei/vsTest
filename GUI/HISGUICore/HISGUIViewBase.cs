using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.ServiceLocation;
using Prism.Regions;
using System.Windows.Threading;
using Prism.Modularity;

namespace HISGUICore
{
    public class HISGUIViewBase : UserControl, INavigationAware, IRegionMemberLifetime
    {
        public HISGUIViewBase()
        {

        }

        private HISGUIVMBase _VM;

        public HISGUIVMBase VM
        {
            get { return _VM; }
            set
            {
                _VM = value;
                this.DataContext = _VM;
            }
        }

        public bool KeepAlive
        {
            get
            {
                return false;
            }
        }


        bool IsSameSource
        {
            get
            {
                try
                {
                    if (this.VM == null) return false;
                    var reg = ServiceLocator.Current.GetInstance<IRegionManager>();

                    var viewname = this.GetType().Name.TrimEndString("View");
                    var vmname = this.VM.GetType().Name.TrimEndString("VM");
                    var rst = string.Equals(viewname, vmname, StringComparison.CurrentCultureIgnoreCase);
                    return rst;
                }
                catch
                {
                    return false;
                }
            }
        }

        #region INavigationAware
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {

            //if (!IsSameSource) return;
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                this.VM.OnNavigatedTo(navigationContext);
            }));
        }
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //if (!IsSameSource) return;
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                this.VM.OnNavigatedFrom(navigationContext);
            }));
        }
        #endregion
    }

    public static class StringHelper
    {
        //在字符串结尾去掉指定子字符串,isForce表示是否将子串后的也删除 
        public static string TrimEndString(this string oraStr, string trimEnd, bool isForce = true)
        {
            try
            {
                if ((!isForce) && (!oraStr.EndsWith(trimEnd))) return oraStr;

                int index = oraStr.LastIndexOf(trimEnd);
                if (index == -1) return oraStr;
                var rst = oraStr.Substring(0, index);
                return rst;
            }
            catch
            {
                return oraStr;
            }
        }
    }
}
