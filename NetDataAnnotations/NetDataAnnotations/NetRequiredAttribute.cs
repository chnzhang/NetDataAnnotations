using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace NetDataAnnotations
{
    public class NetRequiredAttribute : BaseValidate
    {
        
        /// <summary>
        /// 验证数据
        /// </summary>
        /// <param name="value">模型属性值</param>
        /// <param name="validationContext">模型验证上下文类</param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //数据及分组判断
            if (value == null && IsValidate(Groups, NetValidateAttribute.Model))
            {
                string tips = XMLConfiguartionService.GetXmlConfig(Message);
                return new ValidationResult(tips);
            }
            return ValidationResult.Success;
        }

    }
}
