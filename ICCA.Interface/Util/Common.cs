using ICCA.Interface.Log;
using ICCA.Interface.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ICCA.Interface.Util
{
    public class Common
    {
        public static ConfigInfo LoadServiceConfig()
        {
            ConfigInfo config = new ConfigInfo();

            config.InInterval = Convert.ToInt32(ConfigurationManager.AppSettings["InInterval"].Trim().ToString());
            config.LogLevel = ConfigurationManager.AppSettings["LogLevel"].Trim().ToString();
            config.LogFilePath = string.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["LogFilePath"].Trim().ToString());
            config.LogFileKeepDay = Convert.ToInt32(ConfigurationManager.AppSettings["LogFileKeepDay"].Trim().ToString());
            config.XmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"].Trim().ToString();
            config.EnableUpload = ConfigurationManager.AppSettings["EnableUpload"].Trim().ToString();
            config.EnableRemove = ConfigurationManager.AppSettings["EnableRemove"].Trim().ToString();
            config.Doctypename = ConfigurationManager.AppSettings["Doctypename"].Trim().ToString();

            LogUtil.Initialize(config.LogFilePath, config.LogLevel, config.LogFileKeepDay);

            return config;
        }

        public static string GetText(string filePath,string fileName)
        {
            // var path = Path.Combine(System.Environment.CurrentDirectory, "Data\\" + fileName);
            var path = filePath + fileName;
            var str = File.ReadAllText(path, Encoding.UTF8);
            return str;
        }


    }

    public class ConfigInfo
    {
        public int InInterval { get; set; }
        public string LogFilePath { get; set; }
        public string LogLevel { get; set; }
        public int LogFileKeepDay { get; set; }

        public string EnableUpload { get; set; }
        public string EnableRemove { get; set; }
        public string Doctypename { get; set; }

        public string XmlFilePath { get; set; }
    }
}
