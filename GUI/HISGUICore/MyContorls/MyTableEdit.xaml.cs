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
    //编辑内容控件数据类
    public class MyDetail : INotifyPropertyChanged
    {
        public int ID { get; set; }                                    // 药品等编码
        public string GroupNum { set; get; }                           // 组别
        public string Name { set; get; }                               // 名称
        public int SingleDose { get; set; }                            // 数量  
        public string SingleDoseUnit { get; set; }                     // 单位 
        public CommContracts.UsageEnum Usage { get; set; }             // 用法 
        public CommContracts.DDDSEnum DDDS { get; set; }               // 频次
        public int DaysNum { get; set; }                               // 天数
        public int IntegralDose { get; set; }                          // 总量
        public string IntegralDoseUnit { get; set; }                   // 总量单位
        public string Illustration { get; set; }                       // 解释说明
        public string MedicinePacking { get; set; }                    // 药品包装
        public string Specifications { get; set; }                     // 规格

        public string Manufacturer { get; set; }                       // 厂家
        public decimal SellPrice { get; set; }                         // 售价
        public decimal StockPrice { get; set; }                        // 成本价
        private decimal TotalValue;                                    // 单项成本合计
        public decimal Total
        {
            get { return TotalValue; }
            set
            {
                TotalValue = value;
                // Call NotifyPropertyChanged when the property is updated
                Changed("Total");
            }
        }
        public string BatchID { get; set; }                            // 批次 
        public DateTime ExpirationDate { get; set; }                   // 有效日期   

        public int StoreRoomMedicineNumID { get; set; }                // 库存ID
        public int BeforeOutNum { get; set; }                          // 出库前库存
        public string Supplier { get; set; }                           // 供应商
        public int Rebate { get; set; }                                // 折扣  

        #region 属性更改通知
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion
    }

    //编辑内容控件数据类
    public class MySum : INotifyPropertyChanged
    {
        public string Name { set; get; }
        public int SumNum { get; set; }
        private decimal SumMoneyValue;
        public decimal SumMoney
        {
            get { return SumMoneyValue; }
            set
            {
                SumMoneyValue = value;
                // Call NotifyPropertyChanged when the property is updated
                Changed("SumMoney");
            }
        }

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
        xichengyao,              // 西/成药处方
        zhongyao,                // 中药处方
        zhiliao,                 // 治疗
        jianyan,                 // 检验
        jiancha,                 // 检查
        cailiao,                 // 材料
        qita,                    // 其他
        medicineInStock,         // 药品入库
        medicineOutStock,        // 药品出库  
        medicineCheckStock,      // 药品盘库
        materialInStock,         // 物资入库
        materialOutStock,        // 物资出库
        materialCheckStock,       // 物资盘库
        chargeDetail
    }

    public partial class MyTableEdit : UserControl
    {
        private ObservableCollection<dynamic> m_contentItems = new ObservableCollection<dynamic>();
        private ObservableCollection<dynamic> m_sumItems = new ObservableCollection<dynamic>();

        private MyTableEditEnum editEnum { get; set; }

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
            this.editEnum = editEnum;
            InitContentTable();
            InitSumTable();
            this.Loaded += View_Loaded;
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.editEnum == MyTableEditEnum.materialInStock ||
                this.editEnum == MyTableEditEnum.materialOutStock ||
                this.editEnum == MyTableEditEnum.medicineInStock ||
                this.editEnum == MyTableEditEnum.medicineOutStock)
            {
                SelectTempletBtn.Visibility = Visibility.Collapsed;
            }

            if (this.editEnum == MyTableEditEnum.medicineCheckStock ||
                this.editEnum == MyTableEditEnum.materialCheckStock)
            {
                FindNameEdit.Visibility = Visibility.Collapsed;
                SelectTempletBtn.Visibility = Visibility.Collapsed;
                DeleteBtn.Visibility = Visibility.Collapsed;
            }

            ShowAllDetails();
        }

        private void ShowAllDetails()
        {
            if (this.editEnum == MyTableEditEnum.medicineCheckStock)
            {
                m_contentItems.Clear();
                m_sumItems.Clear();
                CommClient.StoreRoomMedicineNum storeRoomMedicineNum = new CommClient.StoreRoomMedicineNum();
                List<CommContracts.StoreRoomMedicineNum> temp = storeRoomMedicineNum.getAllMedicineItemNum(1, "", 0, -1, true, true, false, false);
                foreach (var sto in temp)
                {
                    InsertIntoStoreRoomMedicineNum(sto);
                }
            }
        }

        private List<MyTableTittle> GetContentList()
        {
            List<MyTableTittle> list = new List<MyTableTittle>();
            m_skipList.Clear();
            if (editEnum == MyTableEditEnum.xichengyao || editEnum == MyTableEditEnum.zhongyao)
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
            else if (editEnum == MyTableEditEnum.zhiliao ||
                editEnum == MyTableEditEnum.jianyan ||
                editEnum == MyTableEditEnum.jiancha ||
                editEnum == MyTableEditEnum.cailiao ||
                editEnum == MyTableEditEnum.qita)
            {
                list.Add(new MyTableTittle("ID", "ID", 40, true, Visibility.Hidden));
                list.Add(new MyTableTittle("名称", "Name", 150));
                list.Add(new MyTableTittle("数量", "SingleDose", 80, false));
                list.Add(new MyTableTittle("单位", "SingleDoseUnit"));
                list.Add(new MyTableTittle("备注", "Illustration", 120, false));


                m_nIDIndex = 0;
                m_nSingleDoseIndex = 2;
                m_nIllustrationIndex = 4;

                m_skipList.Add(m_nSingleDoseIndex);
                m_skipList.Add(m_nIllustrationIndex);

            }
            else if (editEnum == MyTableEditEnum.medicineInStock)
            {
                list.Add(new MyTableTittle("ID", "ID", 40, true, Visibility.Hidden));
                list.Add(new MyTableTittle("名称", "Name", 150));
                list.Add(new MyTableTittle("单位", "SingleDoseUnit"));
                list.Add(new MyTableTittle("生产厂商", "Manufacturer", 150));
                list.Add(new MyTableTittle("数量*", "SingleDose", 80, false));
                list.Add(new MyTableTittle("零售价(¥)", "SellPrice", 80));
                list.Add(new MyTableTittle("成本价(¥)*", "StockPrice", 80, false));
                list.Add(new MyTableTittle("合计成本(¥)", "Total", 80));
                list.Add(new MyTableTittle("批号*", "BatchID", 80, false));
                list.Add(new MyTableTittle("有效期*", "ExpirationDate", 80, false));

                m_nIDIndex = 0;
                m_skipList.Add(4);
                m_skipList.Add(6);

                m_skipList.Add(8);
                m_skipList.Add(9);
            }
            else if (editEnum == MyTableEditEnum.medicineOutStock)
            {
                list.Add(new MyTableTittle("StoreRoomMedicineNumID", "StoreRoomMedicineNumID", 40, true, Visibility.Hidden));
                list.Add(new MyTableTittle("名称", "Name", 150));
                list.Add(new MyTableTittle("单位", "SingleDoseUnit"));
                list.Add(new MyTableTittle("生产厂商", "Manufacturer", 150));
                list.Add(new MyTableTittle("零售价(¥)", "SellPrice", 80));
                list.Add(new MyTableTittle("成本价(¥)", "StockPrice", 80, false));
                list.Add(new MyTableTittle("批号", "BatchID", 80, false));
                list.Add(new MyTableTittle("有效期*", "ExpirationDate", 80, false));
                list.Add(new MyTableTittle("库存数量", "BeforeOutNum", 80, false));
                list.Add(new MyTableTittle("出库数量*", "SingleDose", 80, false));
                list.Add(new MyTableTittle("合计成本(¥)", "Total", 80));

                m_skipList.Add(9);
            }
            else if (editEnum == MyTableEditEnum.medicineCheckStock)
            {
                list.Add(new MyTableTittle("StoreRoomMedicineNumID", "StoreRoomMedicineNumID", 40, true, Visibility.Hidden));
                list.Add(new MyTableTittle("名称", "Name", 150));
                list.Add(new MyTableTittle("规格", "Specifications"));
                list.Add(new MyTableTittle("单位", "SingleDoseUnit"));
                list.Add(new MyTableTittle("生产厂商", "Manufacturer", 150));
                list.Add(new MyTableTittle("供应商", "Supplier"));
                list.Add(new MyTableTittle("批号", "BatchID", 80, false));
                list.Add(new MyTableTittle("有效期*", "ExpirationDate", 80, false));
                list.Add(new MyTableTittle("库存数量", "BeforeOutNum", 80, false));
                list.Add(new MyTableTittle("实际数量*", "SingleDose", 80, false));
                list.Add(new MyTableTittle("盘存盈亏(¥)", "Total", 80));

                m_skipList.Add(9);
            }
            else if (editEnum == MyTableEditEnum.chargeDetail)
            {
                list.Add(new MyTableTittle("StoreRoomMedicineNumID", "StoreRoomMedicineNumID", 40, true, Visibility.Hidden)); // 库存ID
                list.Add(new MyTableTittle("名称", "Name", 150));
                list.Add(new MyTableTittle("规格", "Specifications", 80));
                list.Add(new MyTableTittle("单位", "SingleDoseUnit"));
                list.Add(new MyTableTittle("批号", "BatchID", 80, false));
                list.Add(new MyTableTittle("库存数量", "BeforeOutNum", 80, false));
                list.Add(new MyTableTittle("数量*", "SingleDose", 80, false));
                list.Add(new MyTableTittle("零售价(¥)", "SellPrice", 80));
                list.Add(new MyTableTittle("折扣%", "Rebate", 80));
                list.Add(new MyTableTittle("合计(¥)", "Total", 80));
                list.Add(new MyTableTittle("备注", "Illustration", 120, true));

                m_skipList.Add(6);
            }
            m_skipList.Sort();
            return list;
        }

        private List<MyTableTittle> GetSumList()
        {
            List<MyTableTittle> list = new List<MyTableTittle>();

            list.Add(new MyTableTittle("合计", "Name", 590));
            list.Add(new MyTableTittle("名称", "SumMoney", 80));
            return list;
        }

        public void InitContentTable()
        {
            List<MyTableTittle> list = GetContentList();

            for (int i = 0; i < list.Count(); i++)
            {

                if (editEnum == MyTableEditEnum.xichengyao || editEnum == MyTableEditEnum.zhongyao)
                {
                    if (i == m_nDDDSIndex) // 频率
                    {
                        this.MyDataGrid.Columns.Add(new DataGridComboBoxColumn()
                        {
                            Header = list.ElementAt(i).TittleName,
                            SelectedItemBinding = new Binding(list.ElementAt(i).TittleBinding),
                            ItemsSource = Enum.GetValues(typeof(CommContracts.DDDSEnum))
                        });
                        continue;
                    }
                    else if (i == m_nUsageIndex) // 用法
                    {
                        this.MyDataGrid.Columns.Add(new DataGridComboBoxColumn()
                        {
                            Header = list.ElementAt(i).TittleName,
                            SelectedItemBinding = new Binding(list.ElementAt(i).TittleBinding),
                            ItemsSource = Enum.GetValues(typeof(CommContracts.UsageEnum))
                        });
                        continue;
                    }
                }

                this.MyDataGrid.Columns.Add(new DataGridTextColumn()
                {
                    Header = list.ElementAt(i).TittleName,
                    Binding = new Binding(list.ElementAt(i).TittleBinding),
                    Width = list.ElementAt(i).TittleWidth,
                    IsReadOnly = list.ElementAt(i).IsReadOnly,
                    Visibility = list.ElementAt(i).Visibility

                });
            }

            MyDataGrid.ItemsSource = m_contentItems;
        }

        private void InitSumTable()
        {
            List<MyTableTittle> list = GetSumList();
            for (int i = 0; i < list.Count(); i++)
            {
                this.SumNumGrid.Columns.Add(new DataGridTextColumn()
                {
                    Header = list.ElementAt(i).TittleName,
                    Binding = new Binding(list.ElementAt(i).TittleBinding),
                    Width = list.ElementAt(i).TittleWidth,
                    IsReadOnly = list.ElementAt(i).IsReadOnly,
                    Visibility = list.ElementAt(i).Visibility,
                });
            }

            SumNumGrid.ItemsSource = m_sumItems;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = this.MyDataGrid.SelectedIndex;
            if (temp < m_contentItems.Count && temp >= 0)
            {
                m_contentItems.RemoveAt(temp);
            }
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
                int columnIndex = dg.SelectedCells[0].Column.DisplayIndex;                       // 得到当前选中单元格列坐标
                int rowIdnex = int.Parse(dg.Items.IndexOf(dg.SelectedCells[0].Item).ToString()); // 得到当前选中单元格行坐标

                if (m_skipList.Count > 0)                                                        // 如果当前表格有需要待跳转的列 
                {
                    int nIndex = m_skipList.IndexOf(columnIndex);                                // 得到当前单元格在跳转队列中的顺序 
                    if (nIndex >= 0 && nIndex < m_skipList.Count)                                // 如果未超出了跳转队列范围
                    {
                        if (nIndex == m_skipList.Count - 1)                                      // 如果是最后一列，则跳转到搜索内容框 
                        {
                            if(this.editEnum == MyTableEditEnum.chargeDetail)
                            {
                                GridSkipTo(rowIdnex+1, columnIndex);
                            }
                            else
                            {
                                this.MyDataGrid.SelectedCells.Clear();
                                this.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                                    (Action)(() => { Keyboard.Focus(FindNameEdit); }));
                            }
                            
                            UpdateSumTable();
                        }
                        else                                                                     // 如果不是最后一列，则跳转到下一列
                        {
                            GridSkipTo(rowIdnex, m_skipList.ElementAt(nIndex + 1));
                        }
                    }
                }
            }
        }

        private bool IsColumnCalculate(int columnIndex)
        {
            if (editEnum == MyTableEditEnum.medicineInStock)
            {
                if (columnIndex == 6)
                    return true;
            }
            else if (editEnum == MyTableEditEnum.medicineOutStock)
            {
                if (columnIndex == 9)
                    return true;
            }
            else if (editEnum == MyTableEditEnum.medicineCheckStock)
            {
                if (columnIndex == 9)
                    return true;
            }

            return false;
        }

        private void FindNameEdit_KeyDown(object sender, KeyEventArgs e)
        {
            // 移出焦点的作用，防止事件循环
            this.DeleteBtn.Focus();

            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                var window = new Window();

                SelectItemsList list = new SelectItemsList(editEnum);
                window.Content = list;
                bool? bResult = window.ShowDialog();

                if (bResult.Value)
                {
                    this.FindNameEdit.Clear();
                    if (editEnum == MyTableEditEnum.xichengyao || editEnum == MyTableEditEnum.zhongyao)
                    {
                        InsertIntoMedicine(list.CurrentMedicine);
                    }
                    else if (editEnum == MyTableEditEnum.zhiliao)
                    {
                        InsertIntoTherapyItem(list.CurrentTherapyItem);
                    }
                    else if (editEnum == MyTableEditEnum.jianyan)
                    {
                        InsertIntoAssayItem(list.CurrentAssayItem);
                    }
                    else if (editEnum == MyTableEditEnum.jiancha)
                    {
                        InsertIntoInspectItem(list.CurrentInspectItem);
                    }
                    else if (editEnum == MyTableEditEnum.cailiao)
                    {
                        InsertIntoMaterialItem(list.CurrentMaterialItem);
                    }
                    else if (editEnum == MyTableEditEnum.qita)
                    {
                        InsertIntoOtherServiceItem(list.CurrentOtherServiceItem);
                    }
                    else if (editEnum == MyTableEditEnum.medicineInStock)
                    {
                        InsertIntoMedicine(list.CurrentMedicine);
                    }
                    else if (editEnum == MyTableEditEnum.medicineOutStock)
                    {
                        InsertIntoStoreRoomMedicineNum(list.CurrentStoreRoomMedicineNum);
                    }
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
            item.Usage = CommContracts.UsageEnum.口服;
            item.Specifications = medicine.Specifications;
            item.Manufacturer = medicine.Manufacturer;
            item.SingleDoseUnit = medicine.Unit;
            item.SellPrice = medicine.SellPrice;

            m_contentItems.Add(item);
            // 跳转到单次剂量
            if (m_skipList.Count > 0)
            {
                GridSkipTo(m_contentItems.Count - 1, m_skipList.ElementAt(0));
            }
        }

        private void InsertIntoTherapyItem(CommContracts.TherapyItem therapyItem)
        {
            if (therapyItem == null)
                return;

            dynamic item = new MyDetail();
            item.ID = therapyItem.ID;
            item.Name = therapyItem.Name;
            item.SingleDoseUnit = therapyItem.Unit;

            m_contentItems.Add(item);
            // 跳转到单次剂量
            if (m_skipList.Count > 0)
            {
                GridSkipTo(m_contentItems.Count - 1, m_skipList.ElementAt(0));
            }
        }

        private void InsertIntoAssayItem(CommContracts.AssayItem assayItem)
        {
            if (assayItem == null)
                return;

            dynamic item = new MyDetail();
            item.ID = assayItem.ID;
            item.Name = assayItem.Name;
            item.SingleDoseUnit = assayItem.Unit;

            m_contentItems.Add(item);
            // 跳转到单次剂量
            if (m_skipList.Count > 0)
            {
                GridSkipTo(m_contentItems.Count - 1, m_skipList.ElementAt(0));
            }
        }

        private void InsertIntoInspectItem(CommContracts.InspectItem inspectItem)
        {
            if (inspectItem == null)
                return;

            dynamic item = new MyDetail();
            item.ID = inspectItem.ID;
            item.Name = inspectItem.Name;
            item.SingleDoseUnit = inspectItem.Unit;

            m_contentItems.Add(item);
            // 跳转到单次剂量
            if (m_skipList.Count > 0)
            {
                GridSkipTo(m_contentItems.Count - 1, m_skipList.ElementAt(0));
            }
        }

        private void InsertIntoMaterialItem(CommContracts.MaterialItem materialItem)
        {
            if (materialItem == null)
                return;

            dynamic item = new MyDetail();
            item.ID = materialItem.ID;
            item.Name = materialItem.Name;
            item.SingleDoseUnit = materialItem.Unit;

            m_contentItems.Add(item);
            // 跳转到单次剂量
            if (m_skipList.Count > 0)
            {
                GridSkipTo(m_contentItems.Count - 1, m_skipList.ElementAt(0));
            }
        }

        private void InsertIntoOtherServiceItem(CommContracts.OtherServiceItem otherServiceItem)
        {
            if (otherServiceItem == null)
                return;

            dynamic item = new MyDetail();
            item.ID = otherServiceItem.ID;
            item.Name = otherServiceItem.Name;
            item.SingleDoseUnit = otherServiceItem.Unit;

            m_contentItems.Add(item);
            // 跳转到单次剂量
            if (m_skipList.Count > 0)
            {
                GridSkipTo(m_contentItems.Count - 1, m_skipList.ElementAt(0));
            }
        }

        private void InsertIntoStoreRoomMedicineNum(CommContracts.StoreRoomMedicineNum storeRoomMedicineNum)
        {
            if (storeRoomMedicineNum == null)
                return;

            dynamic item = new MyDetail();

            item.StoreRoomMedicineNumID = storeRoomMedicineNum.ID;
            item.Name = storeRoomMedicineNum.Medicine.Name;
            item.SingleDoseUnit = storeRoomMedicineNum.Medicine.Unit;
            item.Specifications = storeRoomMedicineNum.Medicine.Specifications;
            item.Supplier = storeRoomMedicineNum.Supplier.Name;
            item.Manufacturer = storeRoomMedicineNum.Medicine.Manufacturer;
            item.SellPrice = storeRoomMedicineNum.Medicine.SellPrice;
            item.StockPrice = storeRoomMedicineNum.StorePrice;
            item.BatchID = storeRoomMedicineNum.Batch;
            item.ExpirationDate = storeRoomMedicineNum.ExpirationDate;
            item.BeforeOutNum = storeRoomMedicineNum.Num;


            m_contentItems.Add(item);
            // 跳转到单次剂量
            if (m_skipList.Count > 0)
            {
                GridSkipTo(m_contentItems.Count - 1, m_skipList.ElementAt(0));
            }
        }

        private void GridSkipTo(int row, int column)
        {
            var Dg = this.MyDataGrid;
            Dg.SelectedCells.Clear();                                                  // 清除所有选择的单元格
            Dg.Focus();                                                                // 选中表格
            Dg.CurrentCell = new DataGridCellInfo(Dg.Items[row], Dg.Columns[column]);  // 得到需要选中的单元格
            Dg.SelectedCells.Add(Dg.CurrentCell);                                      // 将其添加到选中队列中去
        }

        public List<MyDetail> GetAllDetails()
        {
            List<MyDetail> list = new List<MyDetail>();

            for (int i = 0; i < m_contentItems.Count; i++)
            {
                var tem = m_contentItems.ElementAt(i) as MyDetail;
                list.Add(tem);
            }
            return list;
        }

        public void SetAllDetails(List<MyDetail> list)
        {
            ClearAllDetails();

            for (int i = 0; i < list.Count; i++)
            {
                m_contentItems.Add(list.ElementAt(i));
            }

            UpdateSumTable();
        }

        private void UpdateSumTable()
        {
            if (editEnum == MyTableEditEnum.medicineInStock)
            {
                decimal sum = 0.0m;
                foreach (var tem in m_contentItems)
                {
                    tem.Total = tem.SingleDose * tem.StockPrice;
                    sum += tem.Total;
                }

                if (m_sumItems.Count > 0)
                    m_sumItems.ElementAt(0).SumMoney = sum;
                else
                {
                    dynamic item = new MySum();
                    item.Name = "合计";
                    item.SumMoney = sum;
                    m_sumItems.Add(item);
                }
            }
            else if (editEnum == MyTableEditEnum.medicineOutStock)
            {

            }
            else if (editEnum == MyTableEditEnum.medicineCheckStock)
            {

            }
            if (editEnum == MyTableEditEnum.chargeDetail)
            {
                decimal sum = 0.0m;
                foreach (var tem in m_contentItems)
                {
                    tem.Total = tem.SingleDose * tem.SellPrice;
                    sum += tem.Total;
                }

                if (m_sumItems.Count > 0)
                    m_sumItems.ElementAt(0).SumMoney = sum;
                else
                {
                    dynamic item = new MySum();
                    item.Name = "合计";
                    item.SumMoney = sum;
                    m_sumItems.Add(item);
                }
            }
        }

        private void SelectTempletBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        public void ClearAllDetails()
        {
            m_contentItems.Clear();
            m_sumItems.Clear();
            UpdateSumTable();
        }

        private void MyDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void MyDataGrid_UnloadingRow(object sender, DataGridRowEventArgs e)
        {
            MyDataGrid_LoadingRow(sender, e);
            if (MyDataGrid.Items != null)
            {
                for (int i = 0; i < MyDataGrid.Items.Count; i++)
                {
                    try
                    {
                        DataGridRow row = MyDataGrid.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
                        if (row != null)
                        {
                            row.Header = (i + 1).ToString();
                        }
                    }
                    catch { }
                }
            }
        }
    }
}
