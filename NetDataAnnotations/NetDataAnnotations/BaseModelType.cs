using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetDataAnnotations
{
    public class BaseModelType
    {
        public class BaseModelType : Attribute
        {
            public class Insert : BaseModelType { };
            public class Update : BaseModelType { };
            public class SelectOne : BaseModelType { };
            public class Delete : BaseModelType { };
        }


    }
}

