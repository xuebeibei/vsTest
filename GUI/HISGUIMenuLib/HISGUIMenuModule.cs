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
using HISGUIMenuLib.View;

namespace HISGUIMenuLib
{
    [ModuleExport(typeof(HISGUIMenuModule))]
    class HISGUIMenuModule : HISGUIMoudleBase
    {
        public override void RegisterViews()
        {
            base.RegisterViews();
            //this.RegionManger.RegisterViewWithRegion("UpRegion", typeof(HISGUIMenuView));
        }
    }
}
