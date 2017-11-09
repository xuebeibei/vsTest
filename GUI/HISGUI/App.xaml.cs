using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace HISGUI
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
            System.Environment.CurrentDirectory = System.AppDomain.CurrentDomain.BaseDirectory.Trim('\\');
            this.Init(e);
        }

        void Init(StartupEventArgs e)
        {
            var bootstrapper = new HisGUIBootstrapper();
            bootstrapper.Run();
        }
    }
}
