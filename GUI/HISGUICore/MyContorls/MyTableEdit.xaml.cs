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
    public class DynamicXiYao : INotifyPropertyChanged
    {
        public int DrugID { get; set; }
        public string GroupNum { set; get; }
        public string DrugName { set; get; }
        public int SingleDose { get; set; }
        public string SingleDoseUnit { get; set; }
        public string Usage { get; set; }
        public string DDDS { get; set; }
        public int DaysNum { get; set; }
        public int IntegralDose { get; set; }
        public string IntegralDoseUnit { get; set; }
        public string Illustration { get; set; }

        #region 属性更改通知
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion
    }

    public class MyTableTittle
    {
        public MyTableTittle()
        {

        }

        public MyTableTittle( string name, string bindingname, bool bReadonly = true, int width = 50, Visibility visibility = Visibility.Visible)
        {
            this.TittleWidth = width;
            this.TittleName = name;
            this.IsReadOnly = bReadonly;
            this.TittleBinding = bindingname;
            this.Visibility = visibility;
        }
        public int TittleWidth { get; set; }
        public string TittleName { get; set; }
        public bool IsReadOnly { get; set; }
        public string TittleBinding { get; set; }
        public Visibility Visibility { get; set; }
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

        private void initDrugTable()
        {
            List<MyTableTittle> list = new List<MyTableTittle>();
            list.Add(new MyTableTittle("药品ID", "DrugID", true, 40,  Visibility.Hidden));
            list.Add(new MyTableTittle("组号", "GroupNum", false));
            list.Add(new MyTableTittle("药品名称", "DrugName", false, 100));
            list.Add(new MyTableTittle("单次剂量", "SingleDose", false));
            list.Add(new MyTableTittle("单次量单位", "SingleDoseUnit"));
            list.Add(new MyTableTittle("用法", "Usage", false));
            list.Add(new MyTableTittle("用药频次", "DDDS", false));
            list.Add(new MyTableTittle("天数", "DaysNum"));
            list.Add(new MyTableTittle("总量", "IntegralDose"));
            list.Add(new MyTableTittle("总量单位", "IntegralDoseUnit"));
            list.Add(new MyTableTittle("说明", "Illustration"));

            for (int i = 0; i<list.Count();i++)
            {
                this.MyDataGrid.Columns.Add(new DataGridTextColumn()
                {
                    Header = list.ElementAt(i).TittleName,
                    Binding = new Binding(list.ElementAt(i).TittleBinding),
                    Width = list.ElementAt(i).TittleWidth,
                    Visibility = list.ElementAt(i).Visibility
                });
            }
        }

        private void initZhiLiao()
        {

            List<MyTableTittle> list = new List<MyTableTittle>();
            list.Add(new MyTableTittle("名称", "Name", false, 100));
            list.Add(new MyTableTittle("单位", "Unit", false));
            list.Add(new MyTableTittle("次数", "Num", false));
            list.Add(new MyTableTittle("说明", "Illustration"));

            for (int i = 0; i < list.Count(); i++)
            {
                this.MyDataGrid.Columns.Add(new DataGridTextColumn()
                {
                    Header = list.ElementAt(i).TittleName,
                    Binding = new Binding(list.ElementAt(i).TittleBinding),
                    Width = list.ElementAt(i).TittleWidth,
                    Visibility = list.ElementAt(i).Visibility
                });
            }
        }

        private void initJianYan()
        {
            List<MyTableTittle> list = new List<MyTableTittle>();
            list.Add(new MyTableTittle("名称", "Name", false, 100));
            list.Add(new MyTableTittle("单位", "Unit", false));
            list.Add(new MyTableTittle("次数", "Num", false));
            list.Add(new MyTableTittle("说明", "Illustration"));

            for (int i = 0; i < list.Count(); i++)
            {
                this.MyDataGrid.Columns.Add(new DataGridTextColumn()
                {
                    Header = list.ElementAt(i).TittleName,
                    Binding = new Binding(list.ElementAt(i).TittleBinding),
                    Width = list.ElementAt(i).TittleWidth,
                    Visibility = list.ElementAt(i).Visibility
                });
            }
        }

        private void initJianCha()
        {
            List<MyTableTittle> list = new List<MyTableTittle>();
            list.Add(new MyTableTittle("名称", "Name", false, 100));
            list.Add(new MyTableTittle("单位", "Unit", false));
            list.Add(new MyTableTittle("次数", "Num", false));
            list.Add(new MyTableTittle("说明", "Illustration"));

            for (int i = 0; i < list.Count(); i++)
            {
                this.MyDataGrid.Columns.Add(new DataGridTextColumn()
                {
                    Header = list.ElementAt(i).TittleName,
                    Binding = new Binding(list.ElementAt(i).TittleBinding),
                    Width = list.ElementAt(i).TittleWidth,
                    Visibility = list.ElementAt(i).Visibility
                });
            }
        }

        private void initXiChengYao()
        {
            initDrugTable();
        }

        private void initZhongYao()
        {
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "药品名称",
                Binding = new Binding("DrugName"),
                Width = 100
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "剂量",
                Binding = new Binding("SingleDose"),
                Width = 80
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "单位",
                Binding = new Binding("SingleDoseUnit"),
                Width = 80,
                IsReadOnly = true
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "特殊要求",
                Binding = new Binding("Usage"),
                Width = 80,
                IsReadOnly = true
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "总量",
                Binding = new Binding("DDDS"),
                Width = 80
            });
            this.MyDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "状态",
                Binding = new Binding("DaysNum"),
                Width = 40
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
            else if(myTableEditEnum == MyTableEditEnum.zhiliao)
            {
                initZhiLiao();
            }
            else if(myTableEditEnum == MyTableEditEnum.jianyan)
            {
                initJianYan();
            }
            else if(myTableEditEnum == MyTableEditEnum.jiancha)
            {
                initJianCha();
            }
            MyDataGrid.ItemsSource = items;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            dynamic item = new DynamicXiYao();
            item.DrugID = 0;
            item.GroupNum = "1";
            item.DrugName = "阿莫西林";
            item.SingleDose = 3;

            item.SingleDoseUnit = "片";
            item.Usage = "口服";
            item.DaysNum = 1;
            item.DDDS = "一日三次";
            item.IntegralDose = 1;
            item.IntegralDoseUnit = "盒";
            item.Illustration = "饭后温水送服";

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
                DynamicXiYao dynamic = items.ElementAt(i);
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
