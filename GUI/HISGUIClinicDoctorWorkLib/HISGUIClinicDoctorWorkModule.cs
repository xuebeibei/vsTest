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
using HISGUIClinicDoctorWorkLib.Views;


namespace HISGUIClinicDoctorWorkLib
{
    [ModuleExport(typeof(HISGUIClinicDoctorWorkModule))]
    class HISGUIClinicDoctorWorkModule : HISGUIMoudleBase
    {
        public override void RegisterViews()
        {
            base.RegisterViews();
            this.RegionManger.RegisterViewWithRegion("DownRegion", typeof(HISGUIClinicDoctorWorkView));
        }
    }
}
