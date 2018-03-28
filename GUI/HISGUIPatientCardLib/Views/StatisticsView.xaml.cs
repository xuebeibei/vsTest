using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition;
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
using Microsoft.Practices.ServiceLocation;
using Prism.Regions;
using HISGUICore;
using HISGUICore.MyContorls;
using HISGUIPatientCardLib.ViewModels;
using System.Data;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HISGUIPatientCardLib.Views
{
    public class ValuesCollection : ObservableCollection<Value> { };

    public class Value : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        Double _yValue;
        String _label;

        public String Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Label"));
            }
        }

        public Double YValue
        {
            get
            {
                return _yValue;
            }
            set
            {
                _yValue = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("YValue"));
            }
        }
    }

    [Export]
    [Export("StatisticsView", typeof(StatisticsView))]
    public partial class StatisticsView : HISGUIViewBase
    {
        ObservableCollection<Value> values = new ObservableCollection<Value>();

        public StatisticsView()
        {
            InitializeComponent();
        }

        [Import]
        private HISGUIPatientCardVM ImportVM
        {
            set { this.VM = value; }
        }

        private void UpdateChart()
        {
            CommClient.PatientCardManage manage = new CommClient.PatientCardManage();
            List<CommContracts.PatientCardManage> list = manage.GetAllPatientCardManage();

            var queryAdd = from u in list
                           where u.CardManageEnum == CommContracts.CardManageEnum.eNew
                           select u;

            var queryReturn = from u in list
                              where u.CardManageEnum == CommContracts.CardManageEnum.eReturn
                              select u;

            var queryLost = from u in list
                            where u.CardManageEnum == CommContracts.CardManageEnum.eLost
                            select u;


            values.Add(new Value() { Label = "办理新卡", YValue = queryAdd.Count() });
            values.Add(new Value() { Label = "退卡", YValue = queryReturn.Count() });
            values.Add(new Value() { Label = "挂失补办", YValue = queryLost.Count() });
            values.Add(new Value() { Label = "充值", YValue = 0 });

            MyChart.Series[0].DataSource = values;
        }
    }
}
