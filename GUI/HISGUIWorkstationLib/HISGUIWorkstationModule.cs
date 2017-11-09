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
using HISGUIWorkstationLib.View;

namespace HISGUIWorkstationLib
{
    [ModuleExport(typeof(HISGUIWorkstationModule))]
    public class HISGUIWorkstationModule : HISGUIMoudleBase
    {
        public override void RegisterViews()
        {
            base.RegisterViews();
            this.RegionManger.RegisterViewWithRegion("MainRegion", typeof(HISGUIWorkstationView));
        }
    }
}
