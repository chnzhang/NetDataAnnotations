using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetDataAnnotations
{
    public class NetRangeAttribute : RangeAttribute
    {
        public NetRangeAttribute(double minimum, double maximum) : base(minimum, maximum)
        {
        }
        public NetRangeAttribute(int minimum, int maximum) : base(minimum, maximum)
        {
        }
        public NetRangeAttribute(Type type, string minimum, string maximum) : base(type, minimum, maximum)
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
                    if (Minimum.GetType() == typeof(int))
                    {
                        var v = Convert.ToInt32(value);
                        var min = Convert.ToInt32(Minimum);
                        var max = Convert.ToInt32(Maximum);

                        if (v < min || v > max)
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
                    else if (Minimum.GetType() == typeof(double))
                    {
                        var v = Convert.ToDouble(value);
                        var min = Convert.ToDouble(Minimum);
                        var max = Convert.ToDouble(Maximum);

                        if (v < min || v > max)
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
