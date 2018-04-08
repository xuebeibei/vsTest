using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using CommContracts;

namespace CommServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“RegistrationService”。
    public class RegistrationService : IRegistrationService
    {
        private MainWindow hostApp;
        public RegistrationService(MainWindow hostApp)
        {
            this.hostApp = hostApp;
        }

        public bool DeleteRegistrationDitch(int RegistrationDitchID)
        {
            BLL.RegistrationDitch temp = new BLL.RegistrationDitch();
            return temp.DeleteRegistrationDitch(RegistrationDitchID);
        }

        public List<RegistrationDitch> GetAllRegistrationDitch(string strName)
        {
            BLL.RegistrationDitch temp = new BLL.RegistrationDitch();
            return temp.GetAllRegistrationDitch(strName);
        }

        public bool SaveRegistrationDitch(RegistrationDitch RegistrationDitch)
        {
            BLL.RegistrationDitch temp = new BLL.RegistrationDitch();
            return temp.SaveRegistrationDitch(RegistrationDitch);
        }

        public bool UpdateRegistrationDitch(RegistrationDitch RegistrationDitch)
        {
            BLL.RegistrationDitch temp = new BLL.RegistrationDitch();
            return temp.UpdateRegistrationDitch(RegistrationDitch);
        }
    }
}
