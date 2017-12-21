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
using System.Windows.Threading;

namespace HISGUICore.MyContorls
{
    public enum UsageEnum
    {
        口服,
        注射
    }

    public enum DDDSEnum
    {
        一日1次,
        一日2次,
        一日3次
    }

    //数据类
    public class MyDetail : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string GroupNum { set; get; }
        public string Name { set; get; }
        public int SingleDose { get; set; }
        public string SingleDoseUnit { get; set; }
        public UsageEnum Usage { get; set; }
        public DDDSEnum DDDS { get; set; }
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
            Visibility visibility = Visibility.Visible)
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
        private ObservableCollection<dynamic> m_items = new ObservableCollection<dynamic>();

        private MyTableEditEnum m_myTableEditEnum { get; set; }

        private int m_nIDIndex = -1;
        private int m_nSingleDoseIndex = -1;
        private int m_nDDDSIndex = -1;
        private int m_nUsageIndex = -1;
        private int m_nDayNumIndex = -1;
        private int m_nIllustrationIndex = -1;
        private int m_nGroupNumIndex = -1;

        private List<int> m_skipList = new List<int>();

        public MyTableEdit(MyTableEditEnum editEnum)
        {
            InitializeComponent();
            m_myTableEditEnum = editEnum;
            initTable();
        }

        private List<MyTableTittle> GetList()
        {
            List<MyTableTittle> list = new List<MyTableTittle>();
            m_skipList.Clear();
            if (m_myTableEditEnum == MyTableEditEnum.xichengyao || m_myTableEditEnum == MyTableEditEnum.zhongyao)
            {
                list.Add(new MyTableTittle("ID", "ID", 40, true, Visibility.Hidden));
                list.Add(new MyTableTittle("名称", "Name", 150));
                list.Add(new MyTableTittle("规格", "Specifications", 80));
                list.Add(new MyTableTittle("包装", "MedicinePacking", 80));
                list.Add(new MyTableTittle("单次剂量*", "SingleDose", 80, false));
                list.Add(new MyTableTittle("单位", "SingleDoseUnit"));
                list.Add(new MyTableTittle("频次*", "DDDS", 80, false));
                list.Add(new MyTableTittle("天数*", "DaysNum", 80, false));
                list.Add(new MyTableTittle("总量", "IntegralDose"));
                list.Add(new MyTableTittle("单位", "IntegralDoseUnit"));
                list.Add(new MyTableTittle("关联", "GroupNum", 50, false));
                list.Add(new MyTableTittle("用法*", "Usage", 80, false));
                list.Add(new MyTableTittle("备注", "Illustration", 120, true));

                m_nIDIndex = 0;
                m_nSingleDoseIndex = 4;
                m_nDDDSIndex = 6;
                m_nDayNumIndex = 7;
                m_nGroupNumIndex = 10;
                m_nUsageIndex = 11;
                m_nIllustrationIndex = 12;

                m_skipList.Add(m_nSingleDoseIndex);
                m_skipList.Add(m_nDDDSIndex);
                m_skipList.Add(m_nDayNumIndex);
                m_skipList.Add(m_nGroupNumIndex);
                m_skipList.Add(m_nUsageIndex);
                m_skipList.Add(m_nIllustrationIndex);

            }
            else if (m_myTableEditEnum == MyTableEditEnum.zhiliao ||
                m_myTableEditEnum == MyTableEditEnum.jianyan ||
                m_myTableEditEnum == MyTableEditEnum.jiancha)
            {
                list.Add(new MyTableTittle("ID", "ID", 40, true, Visibility.Hidden));
                list.Add(new MyTableTittle("名称", "Name", 150));
                list.Add(new MyTableTittle("单位", "SingleDoseUnit"));
                list.Add(new MyTableTittle("次数", "SingleDose", 80, false));
                list.Add(new MyTableTittle("备注", "Illustration", 120, true));


                m_nIDIndex = 0;
                m_nSingleDoseIndex = 3;
                m_nIllustrationIndex = 4;

                m_skipList.Add(m_nSingleDoseIndex);
                m_skipList.Add(m_nIllustrationIndex);

            }
            m_skipList.Sort();
            return list;
        }

        public void initTable()
        {
            List<MyTableTittle> list = GetList();

            for (int i = 0; i < list.Count(); i++)
            {

                if (i == m_nDDDSIndex) // 频率
                {
                    this.MyDataGrid.Columns.Add(new DataGridComboBoxColumn()
                    {
                        Header = list.ElementAt(i).TittleName,
                        SelectedItemBinding = new Binding(list.ElementAt(i).TittleBinding),
                        ItemsSource = Enum.GetValues(typeof(DDDSEnum))
                    });
                }
                else if (i == m_nUsageIndex) // 用法
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

            MyDataGrid.ItemsSource = m_items;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = this.MyDataGrid.SelectedIndex;
            if (temp < m_items.Count && temp >= 0)
            {
                m_items.RemoveAt(temp);
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
                    return;
                }


                int columnIndex = dg.SelectedCells[0].Column.DisplayIndex;  // 列坐标
                int rowIdnex = int.Parse(dg.Items.IndexOf(dg.SelectedCells[0].Item).ToString()); // 行坐标

                if (m_skipList.Count > 0)
                {
                    int nIndex = m_skipList.IndexOf(columnIndex);
                    if (nIndex >= 0 && nIndex < m_skipList.Count)
                    {
                        if (nIndex == m_skipList.Count - 1)
                        {
                            this.MyDataGrid.SelectedCells.Clear();
                            this.Dispatcher.BeginInvoke(DispatcherPriority.Background, 
                                (Action)(() => { Keyboard.Focus(FindNameEdit); }));
                        }
                        else
                        {
                            GridSkipTo(rowIdnex, m_skipList.ElementAt(nIndex + 1));
                        }
                    }
                }
            }
        }

        private void FindNameEdit_KeyDown(object sender, KeyEventArgs e)
        {
            // 移出焦点的作用，防止事件循环
            this.DeleteBtn.Focus();

            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                var window = new Window();
                SelectItemsList list = new SelectItemsList();
                window.Content = list;
                bool? bResult = window.ShowDialog();

                if (bResult.Value)
                {
                    this.FindNameEdit.Clear();
                    InsertIntoMedicine(list.CurrentMedicine);
                }
            }
        }

        private void InsertIntoMedicine(CommContracts.Medicine medicine)
        {
            if (medicine == null)
                return;

            dynamic item = new MyDetail();
            item.ID = medicine.ID;
            item.Name = medicine.Name;
            item.Usage = UsageEnum.口服;
            item.Specifications = medicine.Specifications;

            m_items.Add(item);
            // 跳转到单次剂量
            if (m_skipList.Count > 0)
            {
                GridSkipTo(m_items.Count - 1, m_skipList.ElementAt(0));
            }
        }

        private void GridSkipTo(int row, int column)
        {
            var Dg = this.MyDataGrid;
            Dg.SelectedCells.Clear();
            Dg.Focus();
            Dg.CurrentCell = new DataGridCellInfo(Dg.Items[row], Dg.Columns[column]);
            Dg.SelectedCells.Add(Dg.CurrentCell);
        }

        public List<CommContracts.Medicine> GetAllDetails()
        {
            List<CommContracts.Medicine> list = new List<CommContracts.Medicine>();
            return list;
        }

        private void SelectTempletBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
