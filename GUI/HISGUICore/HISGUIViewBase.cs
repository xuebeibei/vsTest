using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.ServiceLocation;
using Prism.Regions;
using System.Windows.Threading;
using Prism.Modularity;
using System.Text.RegularExpressions;

namespace HISGUICore
{
    public class HISGUIViewBase : UserControl, INavigationAware, IRegionMemberLifetime
    {
        public HISGUIViewBase()
        {

        }

        private HISGUIVMBase _VM;

        public HISGUIVMBase VM
        {
            get { return _VM; }
            set
            {
                _VM = value;
                this.DataContext = _VM;
            }
        }

        public bool KeepAlive
        {
            get
            {
                return false;
            }
        }


        bool IsSameSource
        {
            get
            {
                try
                {
                    if (this.VM == null) return false;
                    var reg = ServiceLocator.Current.GetInstance<IRegionManager>();

                    var viewname = this.GetType().Name.TrimEndString("View");
                    var vmname = this.VM.GetType().Name.TrimEndString("VM");
                    var rst = string.Equals(viewname, vmname, StringComparison.CurrentCultureIgnoreCase);
                    return rst;
                }
                catch
                {
                    return false;
                }
            }
        }

        #region INavigationAware
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {

            //if (!IsSameSource) return;
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                this.VM.OnNavigatedTo(navigationContext);
            }));
        }
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //if (!IsSameSource) return;
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                this.VM.OnNavigatedFrom(navigationContext);
            }));
        }
        #endregion
    }

    public static class StringHelper
    {
        //在字符串结尾去掉指定子字符串,isForce表示是否将子串后的也删除 
        public static string TrimEndString(this string oraStr, string trimEnd, bool isForce = true)
        {
            try
            {
                if ((!isForce) && (!oraStr.EndsWith(trimEnd))) return oraStr;

                int index = oraStr.LastIndexOf(trimEnd);
                if (index == -1) return oraStr;
                var rst = oraStr.Substring(0, index);
                return rst;
            }
            catch
            {
                return oraStr;
            }
        }
    }

    public static class IDCardHellper
    {
        public static bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;
            }
            return true;//正确
        }

        public static bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;
            }
            return true;//正确
        }

        public static bool IsIDCardNumOk(string strIDCardNum)
        {
            if(string.IsNullOrEmpty(strIDCardNum))
                return false;

            bool bIsIDCardOK = true;

            if (strIDCardNum.Length == 18)
            {
                bIsIDCardOK = CheckIDCard18(strIDCardNum);
            }
            else if (strIDCardNum.Length == 15)
            {
                bIsIDCardOK = CheckIDCard15(strIDCardNum);
            }
            else
            {
                bIsIDCardOK = false;
            }

            return bIsIDCardOK;
        }

        public static void GetBirthAndSexFromIDCard(string strIDCardNum, ref int year, ref int month, ref int day, ref int sex)
        {
            string strBirth = "", strSex = "";
            if (strIDCardNum.Length == 18)
            {
                strBirth = strIDCardNum.Substring(6, 8);
                strSex = strIDCardNum.Substring(16, 1);

                year = int.Parse(strBirth.Substring(0, 4));
                month = int.Parse(strBirth.Substring(4, 2));
                day = int.Parse(strBirth.Substring(6, 2));
            }
            else if (strIDCardNum.Length == 15)
            {
                strBirth = strIDCardNum.Substring(6, 6);
                strSex = strIDCardNum.Substring(14, 1);

                year = int.Parse("19" + strBirth.Substring(0, 2));
                month = int.Parse(strBirth.Substring(2, 2));
                day = int.Parse(strBirth.Substring(4, 2));
            }

            sex = int.Parse(strSex);
        }

        public static string GetAge(int year, int month, int day)
        {
            DateTime CurrentDate = DateTime.Now;
            DateTime BirthDate = new DateTime(year, month, day);

            int days = ((TimeSpan)(CurrentDate - BirthDate)).Days;


            int iyears = days / 365;


            string result = String.Format("{0}周岁", iyears);


            if (iyears <= 0)
            {
                int month1 = days / 31;
                int adays = days % 31;


                if (month1 > 0)
                    result = String.Format("{0}月{1}天", month1, adays);
                else
                    result = String.Format("{0}天", adays);
            }

            return result;
        }
    } 
}
