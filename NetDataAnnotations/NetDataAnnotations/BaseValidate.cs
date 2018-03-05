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
        /// 分组规则
        /// </summary>
        public BaseModelType[] Groups { get; set; }



        /// <summary>
        /// 验证分组
        /// </summary>
        /// <param name="groups">分组规则</param>
        /// <param name="model">当前规则</param>
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

