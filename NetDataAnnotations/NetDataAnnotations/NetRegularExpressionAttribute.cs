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
        /// xml消息key
        /// </summary>
        public string MessageKey { get; set; }

        /// <summary>
        /// 验证规则
        /// </summary>
        public object[] Groups { get; set; }

     
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.Items.Count > 0)
            {
                var Model = validationContext.Items["Model"];

                if (ValidateTypeHander.IsValidate(Groups, Model))
                {
                    Regex regex = new Regex(base.Pattern);
                    if (!regex.IsMatch(Convert.ToString(value)))
                    {
                        string tips = string.Empty;
                        if (!string.IsNullOrEmpty(ErrorMessage))
                        {
                            Message = ErrorMessage;
                        }
                        if (!string.IsNullOrEmpty(Message))
                        {
                            tips = Message;
                        }
                        else if (!string.IsNullOrEmpty(MessageKey))
                        {
                            tips=XMLConfiguartionService.GetXmlConfig(MessageKey);
                        }
                        return new ValidationResult(tips);
                    }
                }
            }
            return ValidationResult.Success;
        }

       
    }
}
