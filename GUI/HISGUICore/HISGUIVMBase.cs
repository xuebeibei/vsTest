using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public HISGUIVMBase()
        {

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
