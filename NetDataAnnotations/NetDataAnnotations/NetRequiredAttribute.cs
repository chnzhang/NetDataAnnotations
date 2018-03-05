using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace NetDataAnnotations
{
   public class NetRequiredAttribute: ValidationAttribute
    {
        /// <summary>
        /// 错误消息key
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 验证规则
        /// </summary>
        public BaseModelType[] Groups { get; set; }



        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null && IsValidate(Groups, NetValidateAttribute.Model))
            {
                string tips = Message;//Common.XMLConfiguartionService.GetXmlConfig(Message);
                return new ValidationResult(tips);
            }
            return ValidationResult.Success;
        }

        public bool IsValidate(BaseModelType[] groups, BaseModelType model)
        {
            foreach (var item in groups)
            {
                if (item == model)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
