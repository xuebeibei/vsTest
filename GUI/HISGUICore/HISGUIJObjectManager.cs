using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HISGUICore
{
    public delegate void iSagyJObjectPropertyChangedHandler(JToken item);
    public static class HISGUIJObjectManager
    {
        //关注固定路径改变
        static List<iSagyBindObj> LstiSagyBindObj = new List<iSagyBindObj>();

        public static void RegisterMainPropertyEvent(string path, Action<JToken> callBack)
        {
            //try
            //{
            //    var data = PublicDatas.Instance.MainData;
            //    if (data == null) return;
            //    if (string.IsNullOrEmpty(path)) return;
            //    var iSagyObj = LstiSagyBindObj.FirstOrDefault(x => string.Equals(x.Path, path));
            //    if (iSagyObj == null)
            //    {
            //        Binding binding = new Binding();
            //        binding.Source = data;
            //        if (path.Contains("@"))
            //        {
            //            binding.Converter = new JPathConverter();
            //            binding.ConverterParameter = path;
            //        }
            //        else
            //        {
            //            binding.Path = new PropertyPath(path, null);
            //        }
            //        iSagyBindObj obj = new iSagyBindObj();
            //        obj.Path = path;
            //        obj.SetBinding(iSagyBindObj.iSagyPtProperty, binding);
            //        LstiSagyBindObj.Add(obj);
            //        iSagyObj = obj;
            //    }
            //    if (callBack == null) return;
            //    if (!iSagyObj.CallbackList.Contains(callBack))
            //        iSagyObj.CallbackList.Add(callBack);
            //}
            //catch (Exception exp)
            //{
                
            //}
        }
        public static void UnRegisterMainPropertyEvent(string path, Action<JToken> callBack)
        {
            try
            {
                var data = HISGUIPublicDatas.Instance.MainData;
                if (data == null) return;
                if (string.IsNullOrEmpty(path)) return;
                if (callBack == null) return;
                var iSagyObj = LstiSagyBindObj.FirstOrDefault(x => string.Equals(x.Path, path));
                if (iSagyObj == null) return;
                if (iSagyObj.CallbackList.Contains(callBack))
                    iSagyObj.CallbackList.Remove(callBack);
            }
            catch (Exception exp)
            {
                
            }
        }
        //按照路径设置值,遇到空就创建
        public static void SetToken(this JToken root, string path, JToken value)
        {
            try
            {
                if (root == null) return;
                var first = root.SelectToken(path);
                if (first == null)
                {
                    var aim = root.CreateIfEmpty(path);
                    aim.Replace(value ?? JValue.CreateNull());
                }
                else
                {
                    string ppath = path;
                    string name = path;
                    JToken parent = null;
                    int index = path.LastIndexOf('.');
                    if (index == -1)
                    {
                        parent = root;
                    }
                    else
                    {
                        ppath = path.Substring(0, index);
                        name = path.Substring(index + 1, path.Length - index - 1);
                        parent = root.SelectToken(ppath) ?? root.CreateIfEmpty(ppath);
                    }
                    parent[name] = value;
                }
                //else
                //{
                //    var prop = first.Parent as JProperty;
                //    if (prop != null)
                //    {
                //        var name = prop.Name;
                //        var parent = prop.Parent;
                //        parent[name] = value;
                //    }
                //    else
                //    {
                //        first.Replace(value == null ? JValue.CreateNull() : value);
                //    }
                //}
            }
            catch (Exception exp)
            {
            }
        }

        //保证指定路径取值不为空
        public static JToken CreateIfEmpty(this JToken root, string path)
        {
            try
            {
                JToken item = root;
                var lstPath = path.Split('.');
                for (int i = 0; i < lstPath.Length; i++)
                {
                    var subPath = lstPath[i];
                    var subItem = item.SelectToken(subPath);
                    if (subItem == null)
                    {
                        if (i < lstPath.Length - 1 && lstPath[i + 1].StartsWith("["))
                            subItem = new JArray();
                        else
                            subItem = new JObject();
                        var arr = item as JArray;
                        if (arr != null)
                        {
                            int len = int.Parse(subPath.TrimStart('[').TrimEnd(']'));
                            for (int j = arr.Count; j < len; j++)
                            {
                                arr.Add(new JObject());
                            }
                            if (arr.Count < len + 1) arr.Add(subItem);
                            else arr[len] = subItem;
                        }
                        else
                        {
                            item[subPath] = subItem;
                        }
                    }
                    item = subItem;
                }
                return item;
            }
            finally
            {
            }
        }
        //复制
        public static JToken Clone(this JToken obj)
        {
            if (obj == null) return null;
            var jvalue = obj as JValue;
            if (jvalue != null)
            {
                var rst = JValue.CreateString(obj + "");
                return rst;
            }
            else
            {
                var rst = JToken.Parse(obj + "");
                return rst;
            }
        }
        //是否值相等
        public static bool iSagyEquals(this JToken a, JToken b)
        {
            if (a == null || b == null) return false;
            var rst = string.Equals(a + "", b + "");
            return rst;
        }
    }

    public class iSagyBindObj : FrameworkElement
    {
        #region iSagyPt
        public static readonly DependencyProperty iSagyPtProperty = DependencyProperty.Register(
            "iSagyPt", typeof(JToken), typeof(iSagyBindObj), new PropertyMetadata((sender, e) =>
            {
                var vm = sender as iSagyBindObj;
                if (vm == null) return;
                var jt = e.NewValue as JToken;
                if (jt == null) return;
                if (vm.CallbackList == null || vm.CallbackList.Count == 0) return;
                foreach (var callback in vm.CallbackList.ToList())
                {
                    try
                    {
                        callback(jt);
                    }
                    catch { }
                }
            }));
        public JToken iSagyPt
        {
            get { return (JToken)GetValue(iSagyPtProperty); }
            set { SetValue(iSagyPtProperty, value); }
        }

        #endregion
        public string Path { get; set; }
        public List<Action<JToken>> CallbackList { get; set; } = new List<Action<JToken>>();
    }
}
