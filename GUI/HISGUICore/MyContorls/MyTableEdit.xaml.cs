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
    public enum UsageEnum
    {
        口服,
        注射
    }

    //数据类
    public class MyDetail : INotifyPropertyChanged
    {
        public int DrugID { get; set; }
        public string GroupNum { set; get; }
        public string DrugName { set; get; }
        public int SingleDose { get; set; }
        public string SingleDoseUnit { get; set; }
        public UsageEnum Usage { get; set; }
        public string DDDS { get; set; }
        public int DaysNum { get; set; }
        public int IntegralDose { get; set; }
        public string IntegralDoseUnit { get; set; }
        public string Illustration { get; set; }
        public string MedicinePacking { get; set; }
        public string Specifications { get; set; }

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

        public MyTableTittle(
            string name,
            string bindingname,
            int width = 50,
            bool bReadonly = true,
            bool bIsCombo = false,
            Visibility visibility = Visibility.Visible)
        {
            this.TittleWidth = width;
            this.TittleName = name;
            this.IsReadOnly = bReadonly;
            this.TittleBinding = bindingname;
            this.Visibility = visibility;
            this.bIsCombo = bIsCombo;
        }
        public int TittleWidth { get; set; }
        public string TittleName { get; set; }
        public bool IsReadOnly { get; set; }
        public string TittleBinding { get; set; }
        public Visibility Visibility { get; set; }
        public bool bIsCombo { get; set; }
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

        List<MyTableTittle> GetList()
        {
            List<MyTableTittle> list = new List<MyTableTittle>();
            if (myTableEditEnum == MyTableEditEnum.xichengyao)
            {
                list.Add(new MyTableTittle("ID", "DrugID", 40, true, false, Visibility.Hidden));
                list.Add(new MyTableTittle("名称", "DrugName", 150));
                list.Add(new MyTableTittle("规格", "Specifications", 80));
                list.Add(new MyTableTittle("包装", "MedicinePacking", 80));
                list.Add(new MyTableTittle("单次剂量*", "SingleDose", 80, false));
                list.Add(new MyTableTittle("单位", "SingleDoseUnit"));
                list.Add(new MyTableTittle("关联", "GroupNum", 50, false));
                list.Add(new MyTableTittle("频次*", "DDDS", 80, false, true));
                list.Add(new MyTableTittle("用法*", "Usage", 80, false, true));
                list.Add(new MyTableTittle("天数*", "DayNum", 80, false));
                list.Add(new MyTableTittle("总量", "IntegralDose"));
                list.Add(new MyTableTittle("单位", "IntegralDoseUnit"));
                list.Add(new MyTableTittle("备注", "Illustration", 120, true));
            }
            else if (myTableEditEnum == MyTableEditEnum.zhongyao)
            {
                list.Add(new MyTableTittle("药品名称", "DrugName", 100, false));
                list.Add(new MyTableTittle("剂量", "SingleDose"));
                list.Add(new MyTableTittle("单位", "SingleDoseUnit"));
                list.Add(new MyTableTittle("特殊要求", "Usage"));
            }
            else if (myTableEditEnum == MyTableEditEnum.zhiliao ||
                myTableEditEnum == MyTableEditEnum.jianyan ||
                myTableEditEnum == MyTableEditEnum.jiancha)
            {
                list.Add(new MyTableTittle("名称", "Name", 100, false));
                list.Add(new MyTableTittle("单位", "Unit", 80, false));
                list.Add(new MyTableTittle("次数", "Num", 50, false));
                list.Add(new MyTableTittle("说明", "Illustration"));
            }
            return list;
        }

        public void initTable()
        {
            List<MyTableTittle> list = GetList();

            for (int i = 0; i < list.Count(); i++)
            {
                if(list.ElementAt(i).bIsCombo)
                {
                    this.MyDataGrid.Columns.Add(new DataGridComboBoxColumn()
                    {
                        Header = list.ElementAt(i).TittleName,
                        SelectedItemBinding = new Binding(list.ElementAt(i).TittleBinding),
                        ItemsSource = Enum.GetValues(typeof(UsageEnum))
                    });
                }
                else
                {
                    this.MyDataGrid.Columns.Add(new DataGridTextColumn()
                    {
                        Header = list.ElementAt(i).TittleName,
                        Binding = new Binding(list.ElementAt(i).TittleBinding),
                        Width = list.ElementAt(i).TittleWidth,
                        IsReadOnly = list.ElementAt(i).IsReadOnly,
                        Visibility = list.ElementAt(i).Visibility

                    });
                }
            }

            MyDataGrid.ItemsSource = items;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = this.MyDataGrid.SelectedIndex;
            if (temp < items.Count && temp >= 0)
            {
                items.RemoveAt(temp);
            }
        }

        private void MyDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            // 添加行号, 不智能，删除时候行号会乱
            //e.Row.Header = e.Row.GetIndex() + 1; 
        }

        private void MyDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                DataGrid dg = sender as DataGrid;
                if (dg.SelectedCells.Count <= 0)
                {
                    this.FindNameEdit.Focus();
                    return;
                }


                int columnIndex = dg.SelectedCells[0].Column.DisplayIndex;  // 列坐标
                int rowIdnex = int.Parse(dg.Items.IndexOf(dg.SelectedCells[0].Item).ToString()); // 行坐标

                if (columnIndex == 4)
                {
                    GridSkipTo(rowIdnex, 6);
                }
                else if (columnIndex == 6)
                {
                    GridSkipTo(rowIdnex, 7);
                }
                else if (columnIndex == 7)
                {
                    this.MyDataGrid.SelectedCells.Clear();
                    //this.FindNameEdit.Focus();
                }
            }
        }

        private void FindNameEdit_KeyDown(object sender, KeyEventArgs e)
        {
            this.DeleteBtn.Focus();

            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                var window = new Window();
                SelectItemsList list = new SelectItemsList();
                window.Content = list;
                bool? bResult = window.ShowDialog();

                if (bResult.Value)
                {
                    this.FindNameEdit.Text = "";
                    InsertIntoMedicine(list.CurrentMedicine);
                }
            }
        }

        private void InsertIntoMedicine(CommContracts.Medicine medicine)
        {

            //public int DrugID { get; set; }
            //public string GroupNum { set; get; }
            //public string DrugName { set; get; }
            //public int SingleDose { get; set; }
            //public string SingleDoseUnit { get; set; }
            //public string Usage { get; set; }
            //public string DDDS { get; set; }
            //public int DaysNum { get; set; }
            //public int IntegralDose { get; set; }
            //public string IntegralDoseUnit { get; set; }
            //public string Illustration { get; set; }
            //public string MedicinePacking { get; set; }
            //public string Specifications { get; set; }

            dynamic item = new MyDetail();
            item.DrugID = medicine.ID;
            item.DrugName = medicine.Name;
            item.Usage = UsageEnum.口服;
            item.Specifications = medicine.Specifications;


            items.Add(item);
            // 设置该行单次剂量默认选中可填
            GridSkipTo(items.Count - 1, 4);
        }

        private void GridSkipTo(int row, int column)
        {
            var Dg = this.MyDataGrid;
            Dg.SelectedCells.Clear();
            Dg.Focus();
            Dg.CurrentCell = new DataGridCellInfo(Dg.Items[row], Dg.Columns[column]);
            Dg.SelectedCells.Add(Dg.CurrentCell);
        }
    }
}
