/*
* ==============================================================================
*
* File name: MyDescriptionAttribute
* Description: 枚举对应中文值获取
*
* Version: 1.0
* Created: 2018年3月7日
*
* Author: GuangZhi.Zhang
* Company: 四川易讯通健康医疗技术发展有限公司
*
* ==============================================================================
*/

using System.ComponentModel;


namespace NetDataAnnotations
{
    public class MyDescriptionAttribute: DescriptionAttribute
    {
        
        public MyDescriptionAttribute(string key)
        {
            base.DescriptionValue = XMLConfiguartionService.GetXmlConfig(key);
        }

    }
}
