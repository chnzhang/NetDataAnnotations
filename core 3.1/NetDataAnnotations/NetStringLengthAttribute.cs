
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NetDataAnnotations
{
    public class NetStringLengthAttribute : StringLengthAttribute
    {
        public NetStringLengthAttribute(int maximumLength) : base(maximumLength)
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
                    if (value == null || Convert.ToString(value).Length < MinimumLength || Convert.ToString(value).Length > MaximumLength)
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
                            tips = XMLConfiguartionService.GetXmlConfig(MessageKey);
                        }
                        return new ValidationResult(tips);
                    }
                }
            }
            return ValidationResult.Success;
        }


    }
}
