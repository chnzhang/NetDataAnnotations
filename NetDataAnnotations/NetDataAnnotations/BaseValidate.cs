using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetDataAnnotations
{
    public class BaseValidate: ValidationAttribute
    {
        /// <summary>
        /// 错误消息key
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 验证规则
        /// </summary>
        public BaseModelType[] Groups { get; set; }



        /// <summary>
        /// 验证分组
        /// </summary>
        /// <param name="groups"></param>
        /// <param name="model"></param>
        /// <returns></returns>
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
}
