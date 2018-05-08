using System;

namespace NetDataAnnotations
{
    /// <summary>
    /// 基础验证父类
    /// </summary>
    public class BaseValidate
    {

    }

    /// <summary>
    /// 验证规则
    /// </summary>
    public class BaseModelType : Attribute
    {
        public class Insert : BaseModelType { };
        public class Update : BaseModelType { };
        public class SelectOne : BaseModelType { };
        public class Delete : BaseModelType { };
        public class Validate : BaseModelType { };
    }

}

