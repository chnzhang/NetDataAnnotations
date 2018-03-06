using NetDataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetDataAnnotats.CoreTest.Model.Input
{
    public class UserInput
    {
        public int UserId { get; set; }

        [NetRequired(Message = "uservalidate:usernamempty", Groups = new[] {typeof( BaseModelType.Insert), typeof(BaseModelType.SelectOne) })]
        public string UserName { get; set; }

        [NetRequired(Message = "uservalidate:userphoneempty", Groups = new[] { typeof(BaseModelType.Insert), typeof(BaseModelType.Update) })]
        public string UserPhone { get; set; }
    }
}
