using NetDataAnnotations;
using System.Collections.Generic;

namespace NetDataAnnotats.CoreTest.Model.Input
{
    public class UserInput : BaseValidate
    {
        public int UserId { get; set; }

        /// <summary>
        /// 使用message文件配置消息 key 支持分组规则校验,及一级子类传递
        /// </summary>
        [NetRequired(MessageKey = "uservalidate:usernamempty", Groups = new[] { typeof(BaseModelType.Insert), typeof(BaseModelType.SelectOne) })]
        public string UserName { get; set; }

        /// <summary>
        /// 使用消息 uservalidate:userphoneempty
        /// </summary>
        [NetRequired(Message = "电话号码不能为空", Groups = new[] { typeof(BaseModelType.Insert), typeof(BaseModelType.Update) })]
        [NetRegularExpression(@"^[1][0-9][0-9]{9}$", MessageKey = "uservalidate:userphone.regex", Groups = new[] { typeof(BaseModelType.Insert), typeof(BaseModelType.Update) })]
        public string UserPhone { get; set; }

        /// <summary>
        /// 链表实体验证
        /// </summary>
        [BaseModelType.Validate]
        public Order order { get; set; }

        /// <summary>
        /// List链表实体验证
        /// </summary>
        [BaseModelType.Validate]
        public List<Order> orderList { get; set; }
    }
}
