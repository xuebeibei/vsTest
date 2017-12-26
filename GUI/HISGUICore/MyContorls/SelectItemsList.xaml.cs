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
        public CommContracts.Medicine CurrentMedicine { get; set; }
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
        }

        private void getAllData()
        {
            if(editEnum == MyTableEditEnum.xichengyao || editEnum == MyTableEditEnum.zhongyao)
            {
                CommClient.Medicine myd = new CommClient.Medicine();
                List<CommContracts.Medicine> list = myd.getAllMedicine();

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
        }

       
        private void Grid1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter || e.Key == Key.Return)
            {
                if (editEnum == MyTableEditEnum.xichengyao || editEnum == MyTableEditEnum.zhongyao)
                {
                    CommContracts.Medicine medicine = ((sender as DataGrid).CurrentCell.Item as CommContracts.Medicine);

                    CurrentMedicine = medicine;
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
        }
    }
}
