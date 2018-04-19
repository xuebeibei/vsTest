using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommContracts;
using System.ServiceModel;

using System.IO;
using System.Collections;

namespace CommClient
{
    public class Log
    {
        private static Log m_log = null;
        private string m_LogFilePath = "";
        private string m_logPath = "";
        private string m_logFilePrefix = "";
        private Hashtable fosws = null;
        private Log(string filePath, string logFilePrefix)
        {
            m_logPath = filePath;
            m_logFilePrefix = logFilePrefix;
            fosws = new Hashtable();
        }
        public static Log getInstance(string filePath = null, string logFilePrefix = "log")
        {
            if (m_log == null)
            {
                if (filePath == null)
                {
                    filePath = System.AppDomain.CurrentDomain.BaseDirectory == null ? "c://" : System.AppDomain.CurrentDomain.BaseDirectory;
                }
                m_log = new Log(filePath, logFilePrefix);
            }
            return m_log;
        }
        public void write(string logstr, string logtype = "all")
        {
            string logTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            write(logTime, logstr, logtype);
            logstr = null;
        }
        public void write(string logTime, string logstr, string logtype = "all")
        {
            logtype = logtype.ToLower();
            try
            {
                //一小时写一个文件
                string strNowY = DateTime.Now.Year.ToString();
                string strNowM = DateTime.Now.Month.ToString();
                string strNowD = DateTime.Now.Day.ToString();
                string strNowH = DateTime.Now.Hour.ToString();
                string fileName = m_logFilePrefix + "_" + strNowH + "0000_" + logtype + ".log";
                string filePath = m_logPath + "\\logs\\" + strNowY + "-" + strNowM + "-" + strNowD + "\\";
                if (logTime != "")
                {
                    logTime = "[" + logTime + "] ";
                }
                //LOG目录不存在，则创建
                if (Directory.Exists(filePath) == false)
                {
                    Directory.CreateDirectory(filePath);
                }
                m_LogFilePath = filePath + fileName;
                //日志文件不存在，则创建
                if (File.Exists(filePath + fileName) == false)
                {
                    File.Create(filePath + fileName).Close();
                }
                StreamWriter fosw = null;
                if (fosws.Contains(logtype))
                {
                    fosw = (StreamWriter)fosws[logtype];
                }
                else
                {
                    fosw = new StreamWriter(filePath + fileName, true, Encoding.UTF8);
                    fosws.Add(logtype, fosw);
                };
                //创建实例
                if (fosw == null)
                {
                    fosw = new StreamWriter(filePath + fileName, true, Encoding.UTF8);
                    fosws.Add(logtype, fosw);
                }
                //将内容写到log文件中
                fosw.WriteLine(logTime + logstr);
                //刷新，实时保存
                fosw.Flush();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Log Error:" + ex.Message.ToString());
            }
        }
    }
}
