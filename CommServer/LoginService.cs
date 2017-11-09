using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CommContracts;
using System.Collections;

namespace CommServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“LoginService”。
    public class LoginService : ILoginService
    {
        private MainWindow hostApp;
        public LoginService(MainWindow hostApp)
        {
            this.hostApp = hostApp;
        }

        public bool UserAuthenticate(LoginUser l)
        {
            // 这里调用BLL中的逻辑
            BLL.Login login = new BLL.Login(l.Username, l.Password);
            return login.Authenticate();
        }

        public bool UserLogout(LoginUser l)
        {
            BLL.Login login = new BLL.Login(l.Username, l.Password);
            return login.Logout();
        }

        public int getAllDepartmentNum()
        {
            BLL.Department tempDepart = new BLL.Department();
            return tempDepart.getAllDepartmentNum();
        }

        public List<CommContracts.Department> getALLDepartment()
        {
            BLL.Department tempDepart = new BLL.Department();
            return tempDepart.getALLDepartment();
        }

        public List<CommContracts.SignalSource> getALLSignalSource(int DepartmentID, DateTime dateTime, int timeInterval)
        {
            BLL.SignalSource tempDepart = new BLL.SignalSource();
            return tempDepart.getALLSignalSource(DepartmentID, dateTime, timeInterval);
        }

        public List<DateTime> getAllSignalDate(int DepartmentID)
        {
            BLL.SignalSource tempDepart = new BLL.SignalSource();
            return tempDepart.getAllSignalDate(DepartmentID);
        }

        public List<int> getAllSignalTimeIntival(int DepartmentID)
        {
            BLL.SignalSource tempDepart = new BLL.SignalSource();
            return tempDepart.getAllSignalTimeIntival(DepartmentID);
        }

        public string getSignalSourceTip(int DepartmentID, DateTime dateTime, int TimeIntival)
        {
            BLL.SignalSource temp = new BLL.SignalSource();
            return temp.getSignalSourceTip(DepartmentID, dateTime, TimeIntival);
        }
    }
}
