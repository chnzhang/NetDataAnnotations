using NetDataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetDataAnnotats.CoreTest.Model.Input
{
    public class Order: BaseValidate
    {
        [NetRequired(Message = "订单号不能为空", Groups = new[] { typeof(BaseModelType.Insert), typeof(BaseModelType.Update) })]
        public string Number { get; set; }
    }
}
