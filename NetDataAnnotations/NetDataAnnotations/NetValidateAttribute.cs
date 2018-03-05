using System;
using System.Collections.Generic;
using System.Text;

namespace NetDataAnnotations
{
   public class NetValidateAttribute : Attribute
    {
        /// <summary>
        /// 当前正在使用的验证规则
        /// </summary>
        // public   BaseModelType Model { get; set; }
        public static BaseModelType Model;
        public NetValidateAttribute(BaseModelType _model)
        {
            Model = _model;
        }
    }
}
