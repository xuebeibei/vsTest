using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommContracts;
using System.ServiceModel;
using System.Collections;

namespace CommClient
{
    public class RecipeDetail
    {
        private ILoginService client;

        public int ID { get; set; }                               // 处方正文ID
        public string GroupNum { set; get; }                      // 组别
        public int DrugID { get; set; }                           // 药品ID
        public int SingleDose { get; set; }                       // 单次剂量
        public string Usage { get; set; }                         // 用法
        public string DDDS { get; set; }                          // 使用频率
        public int DaysNum { get; set; }                          // 天数
        public int IntegralDose { get; set; }                     // 总量
        public string Illustration { get; set; }                  // 说明

        public int RecipeID { get; set; }                         // 所属处方ID
        public virtual Recipe Recipe { get; set; }

        public RecipeDetail()
        {
            client = ChannelFactory<ILoginService>.CreateChannel(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:50557/LoginService"));
        }

        public bool SaveRecipeDetail()
        {
            return client.SaveRecipeDetail();
        }
    }
}
