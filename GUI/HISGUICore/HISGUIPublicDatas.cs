using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HISGUICore
{
    public class HISGUIPublicDatas : DependencyObject
    {              

        #region MainData

        public static readonly DependencyProperty MainDataProperty = DependencyProperty.Register("MainData",
            typeof(JObject), typeof(HISGUIPublicDatas), new PropertyMetadata((sender, e) => { }));

        public JObject MainData
        {
            get { return GetValue(MainDataProperty) as JObject; }
            set { SetValue(MainDataProperty, value); }
        }

        #endregion


        public static HISGUIPublicDatas Instance { get; } = new HISGUIPublicDatas();

        private HISGUIPublicDatas()
        {
            MainData = new JObject();          
        }
    }
}