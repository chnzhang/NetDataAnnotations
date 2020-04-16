using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetDataAnnotations
{
    public class XMLConfiguartionService
    {
        public static string configFileName = "xml/message.xml";
        public static IConfigurationRoot config;
        public XMLConfiguartionService()
        {

        }

        /// <summary>
        /// xml配置文件读取
        /// </summary>
        /// <param name="configFileName"></param>
        /// <param name="basePath"></param>
        /// <returns></returns>
        public static string GetXmlConfig(string key)
        {
            if (config == null)
            {
                string basePath = Directory.GetCurrentDirectory();
                if (!File.Exists(basePath + "\\" + configFileName))
                {
                    return "未找到消息xml";
                }

                var builder = new ConfigurationBuilder().
                 AddXmlFile(b =>
                 {
                     b.Path = configFileName;
                     b.FileProvider = new PhysicalFileProvider(basePath);
                 });
                config = builder.Build();
            }

            return config[key];
        }

    }
}
