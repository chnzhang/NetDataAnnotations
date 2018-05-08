using System.ComponentModel.DataAnnotations;


namespace NetDataAnnotations
{

    public class NetRequiredAttribute : RequiredAttribute
    {

        /// <summary>
        ///错误消息
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

                if (IsValidate(Groups, Model))
                {
                    if (value == null)
                    {
                        string tips = string.Empty;
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
