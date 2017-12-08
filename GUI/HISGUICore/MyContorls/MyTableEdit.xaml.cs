using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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

namespace HISGUICore.MyContorls
{
    //数据类
    public class Dynamic : INotifyPropertyChanged
    {
        public string GroupNum { set; get; }
        public string DrugName { set; get; }

        #region 属性更改通知
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion
    }

    public enum MyTableEditEnum
    {
        xichengyao,            // 西/成药处方
        zhongyao,              // 中药处方
        zhiliao,               // 治疗
        jianyan,               // 检验
        jiancha                // 检查
    }

    public partial class MyTableEdit : UserControl
    {
        private ObservableCollection<dynamic> items = new ObservableCollection<dynamic>();
        private MyTableEditEnum myTableEditEnum { get; set; }

        public MyTableEdit(MyTableEditEnum editEnum)
        {
            InitializeComponent();
            myTableEditEnum = editEnum;
            initTable();
        }
        private void initXiChengYao()
        {
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "组号",
                Binding = new Binding("GroupNum"),
                Width = 40
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "药品名称",
                Binding = new Binding("DrugName"),
                Width = 100
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "单次剂量",
                Binding = new Binding("SingleDose"),
                Width = 80
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "单次量单位",
                Binding = new Binding("SingleDoseUnit"),
                Width = 80,
                IsReadOnly = true
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "用法",
                Binding = new Binding("Usage"),
                Width = 80,
                IsReadOnly = true
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "用药频次",
                Binding = new Binding("DDDS"),
                Width = 80
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "天数",
                Binding = new Binding("DaysNum"),
                Width = 40
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "总量",
                Binding = new Binding("IntegralDose "),
                Width = 80,
                IsReadOnly = true
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "总量单位",
                Binding = new Binding("IntegralDoseUnit"),
                Width = 80,
                IsReadOnly = true
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "说明",
                Binding = new Binding("Illustration"),
                Width = 100
            });
        }

        private void initZhongYao()
        {
            //< !--< DataGrid x: Name = "zhongyao" Margin = "5" ItemsSource = "{Binding}" AutoGenerateColumns = "False" >

            //                             < DataGrid.Columns >

            //                                 < DataGridTextColumn Header = "组号"
            //                                Width = "40"
            //                                Binding = "{Binding Name}" />
            //                        < DataGridTextColumn Header = "药品名"
            //                                Width = "90"
            //                                Binding = "{Binding Unit}" />
            //                        < DataGridTextColumn Header = "单次计量"
            //                                Width = "80"
            //                                Binding = "{Binding Value}" />
            //                        < DataGridTextColumn Header = "用法"
            //                                Width = "80"
            //                                Binding = "{Binding LowerLimit}" />
            //                        < DataGridTextColumn Header = "用药频次"
            //                                Width = "80"
            //                                Binding = "{Binding UpperLimit}" />
            //                        < DataGridTextColumn Header = "天数"
            //                                Width = "40"
            //                                Binding = "{Binding UpperLimit}" />
            //                        < DataGridTextColumn Header = "总量"
            //                                Width = "40"
            //                                Binding = "{Binding UpperLimit}" />
            //                        < DataGridTextColumn Header = "说明"
            //                                Width = "80"
            //                                Binding = "{Binding UpperLimit}" />
            //                    </ DataGrid.Columns >
            //                </ DataGrid >

            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "组号",
                Binding = new Binding("Illustration"),
                Width = 40
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "药品名",
                Binding = new Binding("Illustration"),
                Width = 100
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "单次计量",
                Binding = new Binding("Illustration"),
                Width = 100
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "组号",
                Binding = new Binding("Illustration"),
                Width = 100
            });
        }

        public void initTable()
        {
            if(myTableEditEnum == MyTableEditEnum.xichengyao)
            {
                initXiChengYao();
            }
            else if(myTableEditEnum == MyTableEditEnum.zhongyao)
            {
                initZhongYao();
            }
            MyDataGrid.ItemsSource = items;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            dynamic item = new Dynamic();
            item.GroupNum = "1";
            item.DrugName = "阿莫西林";
            items.Add(item);
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = this.MyDataGrid.SelectedIndex;
            if (temp < items.Count && temp >= 0)
            {
                items.RemoveAt(temp);
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string str = "";
            for (int i = 0; i < items.Count; i++)
            {
                Dynamic dynamic = items.ElementAt(i);
                str += dynamic.GroupNum;
            }
            MessageBox.Show(str);
        }

        private void SaveTempletBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MyDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            // 添加行号, 不智能，删除时候行号会乱
            //e.Row.Header = e.Row.GetIndex() + 1;

            //var drv = e.Row.Item as DataRowView;
            //switch (drv["GroupNum"].ToString())
            //{
            //    case "1":
            //        e.Row.Background = new SolidColorBrush(Colors.Green);
            //        break;
            //    case "2":
            //        e.Row.Background = new SolidColorBrush(Colors.Yellow);
            //        break;
            //    case "3":
            //        e.Row.Background = new SolidColorBrush(Colors.CadetBlue);
            //        break;


            //}
        }
    }
}
