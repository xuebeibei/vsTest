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
using HISGUITriageLib.Views;

namespace HISGUITriageLib
{
    [ModuleExport(typeof(HISGUITriageModule))]
    class HISGUITriageModule : HISGUIMoudleBase
    {
        public override void RegisterViews()
        {
            base.RegisterViews();
            //this.RegionManger.RegisterViewWithRegion("DownRegion", typeof(HISGUITriageView));
        }
    }
}
