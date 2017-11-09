using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;
using Prism.Regions;

namespace HISGUICore
{
    public class HISGUIMoudleBase : IModule
    {
        [Import] public IRegionManager RegionManger;

        public virtual void Initialize()
        {
            this.RegisterViews();
            this.RegisterEvents();
            this.RaiseInitEvents();
        }

        public virtual void RegisterViews()
        {

        }

        public virtual void RegisterEvents()
        {

        }

        public virtual void RaiseInitEvents()
        {

        }
    }
}
