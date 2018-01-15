using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mef.Modularity;
using Prism.Modularity;
using HISGUICore;
using HISGUISetLib.Views;

namespace HISGUISetLib
{
    [ModuleExport(typeof(HISGUISetModule))]
    class HISGUISetModule : HISGUIMoudleBase
    {
        public override void RegisterEvents()
        {
            base.RegisterEvents();
            this.RegionManger.RegisterViewWithRegion("DownRegion", typeof(HISGUISetView));
        }
    }
}
