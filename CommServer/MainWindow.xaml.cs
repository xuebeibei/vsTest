using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;

namespace CommServer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoginService loginService;
        private ServiceHost loginServiceHost;
        private RegistrationService registrationService;
        private ServiceHost registrationServiceHost;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loginService = new LoginService(this);
            loginServiceHost = new ServiceHost(loginService);
            loginServiceHost.Open();

            registrationService = new RegistrationService(this);
            registrationServiceHost = new ServiceHost(registrationService);
            registrationServiceHost.Open();
        }

        private void Window_Closing(object sender,
            System.ComponentModel.CancelEventArgs e)
        {
            loginServiceHost.Close();
            registrationServiceHost.Close();
        }
    }
}
