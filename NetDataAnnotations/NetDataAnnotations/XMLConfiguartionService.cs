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

        public XMLConfiguartionService()
        {

        }

        /// <summary>
        /// xml配置文件读取
        /// </summary>
        /// <param name="configFileName"></param>
        /// <param name="basePath"></param>
        /// <returns></returns>
        public static string GetXmlConfig(string key, string configFileName = "XMLConfig/message.xml", string basePath = "")
        {
            basePath = string.IsNullOrWhiteSpace(basePath) ? Directory.GetCurrentDirectory() : basePath;
            var builder = new ConfigurationBuilder().         
             AddXmlFile(b =>
             {
                 b.Path = configFileName;
                 b.FileProvider = new PhysicalFileProvider(basePath);
             });
            var config = builder.Build();

            return config[key];
        }

    }
}
