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

namespace HISGUICore.MyContorls
{
    public partial class SelectItemsList : UserControl
    {
        public CommContracts.Medicine CurrentMedicine { get; set; }        // 药品
        public CommContracts.TherapyItem CurrentTherapyItem { get; set; }  // 治疗
        public CommContracts.AssayItem CurrentAssayItem { get; set; }      // 化验
        public CommContracts.InspectItem CurrentInspectItem { get; set; }  // 检查
        public CommContracts.MaterialItem CurrentMaterialItem { get; set; }// 材料
        public CommContracts.OtherServiceItem CurrentOtherServiceItem { get; set; } // 其他服务
        public CommContracts.StoreRoomMedicineNum CurrentStoreRoomMedicineNum { get; set; }  // 药品库存
        public CommContracts.StoreRoomMaterialNum CurrentStoreRoomMaterialNum { get; set; }  // 物资库存

        private MyTableEditEnum editEnum;
        public SelectItemsList(MyTableEditEnum itemEnum)
        {
            InitializeComponent();
            editEnum = itemEnum;
            initGrid();
            getAllData();
        }

        private void initGrid()
        {
            //this.Grid1.Columns.Clear();
            if (editEnum == MyTableEditEnum.xichengyao || editEnum == MyTableEditEnum.zhongyao || editEnum == MyTableEditEnum.medicineInStock)
            {
                this.Grid1.View = this.Resources["haveMedicineColumn"] as GridView;
            }
            else if (editEnum == MyTableEditEnum.zhiliao)
            {
                this.Grid1.View = this.Resources["haveZhiliaoColumn"] as GridView;
            }
            else if (editEnum == MyTableEditEnum.jianyan)
            {
                this.Grid1.View = this.Resources["haveZhiliaoColumn"] as GridView;
            }
            else if (editEnum == MyTableEditEnum.jiancha)
            {
                this.Grid1.View = this.Resources["haveZhiliaoColumn"] as GridView;
            }
            else if (editEnum == MyTableEditEnum.cailiao || editEnum == MyTableEditEnum.materialInStock)
            {
                this.Grid1.View = this.Resources["haveMaterialColumn"] as GridView;
            }
            else if (editEnum == MyTableEditEnum.qita)
            {
                this.Grid1.View = this.Resources["haveZhiliaoColumn"] as GridView;
            }
            else if (editEnum == MyTableEditEnum.medicineOutStock)
            {
                this.Grid1.View = this.Resources["haveMedicineNumsColumn"] as GridView;
            }
            else if(editEnum == MyTableEditEnum.materialOutStock)
            {
                this.Grid1.View = this.Resources["haveMaterialItemNumsColumn"] as GridView;
            }
        }

        private void getAllData()
        {
            string strFindName = ""; // 暂时先搜索空

            this.Grid1.ItemsSource = null;

            if (editEnum == MyTableEditEnum.xichengyao)
            {
                CommClient.Medicine myd = new CommClient.Medicine();
                List<CommContracts.Medicine> list = myd.GetAllXiChengMedicine(strFindName);

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
            else if (editEnum == MyTableEditEnum.zhongyao)
            {
                CommClient.Medicine myd = new CommClient.Medicine();
                List<CommContracts.Medicine> list = myd.GetOneTypeMedicine(CommContracts.MedicineTypeEnum.中药, strFindName);

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
            else if (editEnum == MyTableEditEnum.medicineInStock)
            {
                CommClient.Medicine myd = new CommClient.Medicine();
                List<CommContracts.Medicine> list = myd.GetAllMedicine(strFindName);

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
            else if (editEnum == MyTableEditEnum.zhiliao)
            {
                CommClient.TherapyItem therapyItem = new CommClient.TherapyItem();
                List<CommContracts.TherapyItem> list = therapyItem.GetAllTherapyItem(strFindName);

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
            else if (editEnum == MyTableEditEnum.jianyan)
            {
                CommClient.AssayItem therapyItem = new CommClient.AssayItem();
                List<CommContracts.AssayItem> list = therapyItem.GetAllAssayItem(strFindName);

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
            else if (editEnum == MyTableEditEnum.jiancha)
            {
                CommClient.InspectItem therapyItem = new CommClient.InspectItem();
                List<CommContracts.InspectItem> list = therapyItem.GetAllInspectItem(strFindName);

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
            else if (editEnum == MyTableEditEnum.cailiao || editEnum == MyTableEditEnum.materialInStock)
            {
                CommClient.MaterialItem therapyItem = new CommClient.MaterialItem();
                List<CommContracts.MaterialItem> list = therapyItem.GetAllMaterialItem(strFindName);

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
            else if (editEnum == MyTableEditEnum.qita)
            {
                CommClient.OtherServiceItem otherServiceItem = new CommClient.OtherServiceItem();
                List<CommContracts.OtherServiceItem> list = otherServiceItem.GetAllOtherServiceItem(strFindName);

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
            else if (editEnum == MyTableEditEnum.medicineOutStock)
            {
                CommClient.StoreRoomMedicineNum storeRoomMedicineNum = new CommClient.StoreRoomMedicineNum();
                List<CommContracts.StoreRoomMedicineNum> list = storeRoomMedicineNum.getAllMedicineItemNum(1, "", 0, -1, true, true, false, false);

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
            else if(editEnum == MyTableEditEnum.materialOutStock)
            {
                CommClient.StoreRoomMaterialNum storeRoomMaterialNum = new CommClient.StoreRoomMaterialNum();
                List<CommContracts.StoreRoomMaterialNum> list = storeRoomMaterialNum.getAllMaterialItemNum(1, "", 0, -1, true, true, false, false);

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
        }


        private void Grid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                if (editEnum == MyTableEditEnum.xichengyao || editEnum == MyTableEditEnum.zhongyao || editEnum == MyTableEditEnum.medicineInStock)
                {
                    CommContracts.Medicine medicine = this.Grid1.SelectedItem as CommContracts.Medicine;

                    CurrentMedicine = medicine;
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
                else if (editEnum == MyTableEditEnum.zhiliao)
                {
                    CommContracts.TherapyItem therapyItem = this.Grid1.SelectedItem as CommContracts.TherapyItem;

                    CurrentTherapyItem = therapyItem;
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
                else if (editEnum == MyTableEditEnum.jianyan)
                {
                    CommContracts.AssayItem therapyItem = this.Grid1.SelectedItem as CommContracts.AssayItem;

                    CurrentAssayItem = therapyItem;
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
                else if (editEnum == MyTableEditEnum.jiancha)
                {
                    CommContracts.InspectItem therapyItem = this.Grid1.SelectedItem as CommContracts.InspectItem;

                    CurrentInspectItem = therapyItem;
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
                else if (editEnum == MyTableEditEnum.cailiao || editEnum == MyTableEditEnum.materialInStock)
                {
                    CommContracts.MaterialItem materialItem = this.Grid1.SelectedItem as CommContracts.MaterialItem;

                    CurrentMaterialItem = materialItem;
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();

                }
                else if (editEnum == MyTableEditEnum.qita)
                {
                    CommContracts.OtherServiceItem otherServiceItem = this.Grid1.SelectedItem as CommContracts.OtherServiceItem;

                    CurrentOtherServiceItem = otherServiceItem;
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
                else if (editEnum == MyTableEditEnum.medicineOutStock)
                {
                    CommContracts.StoreRoomMedicineNum storeRoomMedicineNum = this.Grid1.SelectedItem as CommContracts.StoreRoomMedicineNum;

                    CurrentStoreRoomMedicineNum = storeRoomMedicineNum;
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
                else if(editEnum == MyTableEditEnum.materialOutStock)
                {
                    CommContracts.StoreRoomMaterialNum storeRoomMaterialNum = this.Grid1.SelectedItem as CommContracts.StoreRoomMaterialNum;

                    CurrentStoreRoomMaterialNum = storeRoomMaterialNum;
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
        }
    }
}
