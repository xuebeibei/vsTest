using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using Prism.Regions;

namespace HISGUICore
{
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
            return myd.Logout(user);
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
