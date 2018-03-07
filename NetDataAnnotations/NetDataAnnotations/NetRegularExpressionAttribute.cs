using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace NetDataAnnotations
{
   public  class NetRegularExpressionAttribute: RegularExpressionAttribute
    {
        public NetRegularExpressionAttribute(string pattern) : base(pattern)
        {
        }

        /// <summary>
        /// 错误消息key
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 验证规则
        /// </summary>
        public object[] Groups { get; set; }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.Items.Count > 0)
            {
                var Model = validationContext.Items["Model"];

                if (IsValidate(Groups, Model))
                {
                    Regex regex = new Regex(base.Pattern);
                    if (!regex.IsMatch(Convert.ToString(value)))
                    {
                        string tips = XMLConfiguartionService.GetXmlConfig(Message);
                        return new ValidationResult(tips);
                    }
                }
            }
            return ValidationResult.Success;
        }

        public bool IsValidate(object[] groups, object model)
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
