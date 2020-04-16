using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetDataAnnotations
{
    public class NetCompareAttribute : CompareAttribute
    {
        public NetCompareAttribute(string otherProperty) : base(otherProperty)
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
        public System.Type[] Groups { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (validationContext.Items.Count > 0)
            {
                var Model = validationContext.Items["Model"];

                if (ValidateTypeHander.IsValidate(Groups, Model))
                {
                    string tips = string.Empty;

                    var otherProperty = validationContext.ObjectInstance.GetType().GetProperty(OtherProperty);
                    var otherPropertyValue = otherProperty.GetValue(validationContext.ObjectInstance, null);

                    if (value == null && otherPropertyValue == null)
                    {
                        return ValidationResult.Success;
                    }
                    if (value == null && otherPropertyValue != null)
                    {
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
                    if (value != null && otherPropertyValue == null)
                    {
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

                    if (value.GetType() == typeof(string))
                    {
                        string v = value.ToString();
                        if (!v.Equals(otherPropertyValue.ToString()))
                        {

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
                    else if (value.GetType() == typeof(int))
                    {
                        int v = Convert.ToInt32(value);
                        if (v != Convert.ToInt32(otherPropertyValue))
                        {
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
                    else if (value.GetType() == typeof(double))
                    {
                        double v = Convert.ToDouble(value);
                        if (v != Convert.ToDouble(otherPropertyValue))
                        {
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
                    else if (value.GetType() == typeof(DateTime))
                    {
                        DateTime v = Convert.ToDateTime(value);
                        if (v != Convert.ToDateTime(otherPropertyValue))
                        {
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
            }
            return ValidationResult.Success;
        }
    }
}
