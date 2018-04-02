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
            UpdateChart();
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
                           where u.CardManageEnum == CommContracts.CardManageEnum.新建卡
                           select u;

            var queryLost = from u in list
                              where u.CardManageEnum == CommContracts.CardManageEnum.挂失卡
                              select u;

            var queryReNew = from u in list
                            where u.CardManageEnum == CommContracts.CardManageEnum.补办卡
                            select u;

            CommClient.PatientCardPrePay preClient = new CommClient.PatientCardPrePay();
            List<CommContracts.PatientCardPrePay> list1 = preClient.GetAllPrePay(0);

            var queryAddFee = from p in list1
                              where p.PrePayType == CommContracts.PrePayTypeEnum.缴款
                              select p;

            var queryReturnFee = from p in list1
                              where p.PrePayType == CommContracts.PrePayTypeEnum.退款
                              select p;


            values.Add(new Value() { Label = "办理新卡", YValue = queryAdd.Count() });
            values.Add(new Value() { Label = "挂失", YValue = queryLost.Count() });
            values.Add(new Value() { Label = "补办", YValue = queryReNew.Count() });
            values.Add(new Value() { Label = "缴款", YValue = queryAddFee.Count() });
            values.Add(new Value() { Label = "退款", YValue = queryReturnFee.Count() });

            MyChart.Series[0].DataSource = values;
        }
    }
}
