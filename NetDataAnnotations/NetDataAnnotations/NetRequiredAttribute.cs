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
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //数据及分组判断
            if (value == null && IsValidate(Groups, NetValidateAttribute.Model))
            {
                string tips = Message;//Common.XMLConfiguartionService.GetXmlConfig(Message);
                return new ValidationResult(tips);
            }
            return ValidationResult.Success;
        }

    }
}
