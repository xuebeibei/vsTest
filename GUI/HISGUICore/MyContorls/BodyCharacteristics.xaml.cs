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
    /// <summary>
    /// BodyCharacteristics.xaml 的交互逻辑
    /// </summary>
    public partial class BodyCharacteristics : UserControl
    {
        public BodyCharacteristics()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 对体温输入的控制
            bool bIsError = true;
            String strTemperature = TemperatureBox.Text;
            double dTemperature = 0.0;
            if (!String.IsNullOrEmpty(strTemperature))
            {
                try
                {
                    dTemperature = Math.Round(double.Parse(strTemperature), 2);
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    TemperatureError.Content = "请输入数字";
                    bIsError = false;
                }
            }

            double nMax = 45.00;
            double nMin = 30.00;
            if (dTemperature > nMax || dTemperature < nMin)
            {
                TemperatureError.Content = "请输入有效值(" + Convert.ToString(nMin) + "-" + Convert.ToString(nMax) + ")";
                bIsError = false;
            }

            var visualUsername = bIsError ? "TemperatureNormalState" : "TemperatureErrorState";
            VisualStateManager.GoToState(this, visualUsername, false);

        }

        private void WeightEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 对体重输入的控制
            bool bIsError = true;
            String strWeight = WeightEdit.Text;
            double dWeight = 0.0;
            if (!String.IsNullOrEmpty(strWeight))
            {
                try
                {
                    dWeight = Math.Round(double.Parse(strWeight), 2);
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    WeightError.Content = "请输入数字";
                    bIsError = false;
                }
            }

            var visualUsername = bIsError ? "WeightNormalState" : "WeightErrorState";
            VisualStateManager.GoToState(this, visualUsername, false);
        }

        private void HeightEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 对身高输入的控制
            bool bIsError = true;
            String strHeight = HeightEdit.Text;
            double dHeight = 0.0;
            if (!String.IsNullOrEmpty(strHeight))
            {
                try
                {
                    dHeight = Math.Round(double.Parse(strHeight), 2);
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    HeightError.Content = "请输入数字";
                    bIsError = false;
                }
            }

            var visualUsername = bIsError ? "HeightNormalState" : "HeightErrorState";
            VisualStateManager.GoToState(this, visualUsername, false);
        }

        private void BMIEdit_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BreathEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 对呼吸输入的控制
            bool bIsError = true;
            String strBreath = BreathEdit.Text;
            int nBreath = 0;
            if (!String.IsNullOrEmpty(strBreath))
            {
                try
                {
                    nBreath = int.Parse(strBreath);
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    BreathErrorLabel.Content = "请输入整数";
                    bIsError = false;
                }
            }

            var visualUsername = bIsError ? "BreathNormalState" : "BreathErrorState";
            VisualStateManager.GoToState(this, visualUsername, false);
        }

        private void PulseEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 对脉搏输入的控制
            bool bIsError = true;
            String strPulse = PulseEdit.Text;
            int nBreath = 0;
            if (!String.IsNullOrEmpty(strPulse))
            {
                try
                {
                    nBreath = int.Parse(strPulse);
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    PulseError.Content = "请输入整数";
                    bIsError = false;
                }
            }

            var visualUsername = bIsError ? "PulseNormalState" : "PulseErrorState";
            VisualStateManager.GoToState(this, visualUsername, false);
        }

        private void BloodPressure()
        {
            // 对收缩压输入的控制
            bool bSystolicPressure = true;
            int nNumber = 0;
            if (!String.IsNullOrEmpty(SystolicPressureEdit.Text))
            {
                try
                {
                    nNumber = int.Parse(SystolicPressureEdit.Text);
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    BloodPressureError.Content = "请输入整数";
                    bSystolicPressure = false;
                }
            }

            // 对舒张压输入的控制
            bool bDiastolicPressure = true;
            int nBreath = 0;
            if (!String.IsNullOrEmpty(DiastolicPressureEdit.Text))
            {
                try
                {
                    nBreath = int.Parse(DiastolicPressureEdit.Text);
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    BloodPressureError.Content = "请输入整数";
                    bDiastolicPressure = false;
                }
            }
            var visualUsername = "BloodPressureNormalState";
            if (!bSystolicPressure && bDiastolicPressure)
            {
                visualUsername = "SystolicPressureErrorState";
            }
            else if (bSystolicPressure && !bDiastolicPressure)
            {
                visualUsername = "DiastolicPressureErrorState";
            }
            else if (!bSystolicPressure && !bDiastolicPressure)
            {
                visualUsername = "BloodPressureErrorState";
            }

            VisualStateManager.GoToState(this, visualUsername, false);
        }

        private void SystolicPressureEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            BloodPressure();
        }

        private void DiastolicPressureEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            BloodPressure();
        }

        private void BloodGlucoseEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 对血糖浓度输入的控制
            bool bIsError = true;
            int nBreath = 0;
            if (!String.IsNullOrEmpty(BloodGlucoseEdit.Text))
            {
                try
                {
                    nBreath = int.Parse(BloodGlucoseEdit.Text);
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    BloodGlucoseError.Content = "请输入整数";
                    bIsError = false;
                }
            }

            var visualUsername = bIsError ? "BloodGlucoseNormalState" : "BloodGlucoseErrorState";
            VisualStateManager.GoToState(this, visualUsername, false);
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            // 对左眼输入的控制

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            // 对右眼输入的控制

        }

        private void OxygenSaturationEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 对氧饱和度输入的控制
            bool bIsError = true;
            double dNumber = 0.0;
            if (!String.IsNullOrEmpty(OxygenSaturationEdit.Text))
            {
                try
                {
                    dNumber = Math.Round(double.Parse(OxygenSaturationEdit.Text), 2);
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    OxygenSaturationError.Content = "请输入数字";
                    bIsError = false;
                }
            }

            var visualUsername = bIsError ? "OxygenSaturationNormalState" : "OxygenSaturationErrorState";
            VisualStateManager.GoToState(this, visualUsername, false);
        }

        private void PainGradeEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 对血糖浓度输入的控制
            bool bIsError = true;
            int nNumber = 0;
            if (!String.IsNullOrEmpty(PainGradeEdit.Text))
            {
                try
                {
                    nNumber = int.Parse(PainGradeEdit.Text);
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    PainGradeError.Content = "请输入整数";
                    bIsError = false;
                }
            }

            var visualUsername = bIsError ? "PainGradeNormalState" : "PainGradeErrorState";
            VisualStateManager.GoToState(this, visualUsername, false);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
