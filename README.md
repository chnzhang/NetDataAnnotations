# NetDataAnnotations
自定义注解，可分组，错误信息xml化

 public class InputUser
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [NetRequired(Message = "uservalidate:username.required", Groups = new[] { typeof(BaseModelType.Insert), typeof(BaseModelType.SelectOne) })]
        [NetStringLength(10, MinimumLength = 2, Message = "uservalidate:username.length", Groups = new[] { typeof(BaseModelType.Insert), typeof(BaseModelType.SelectOne) })]
        public string UserName { get; set; }

        /// <summary>
        /// 用户电话号码
        /// </summary>
        [NetRequired(Message = "uservalidate:userphone.required", Groups = new[] { typeof(BaseModelType.Insert), typeof(BaseModelType.Update) })]
        [NetRegularExpression(@"^[1][0-9][0-9]{9}$", Message = "uservalidate:userphone.regex", Groups = new[] { typeof(BaseModelType.Insert), typeof(BaseModelType.Update) })]
        public string UserPhone { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [NetRequired(Message = "uservalidate:useridcard.required", Groups = new[] { typeof(BaseModelType.Insert), typeof(BaseModelType.Update) })]
        [NetStringLength(18, MinimumLength = 15, Message = "uservalidate:useridcard.length",
                                        Groups = new[] { typeof(BaseModelType.Insert), typeof(BaseModelType.Update) })]
        public string UserIdCard { get; set; }

    }
可设置xml的错误信息Message
可分组验证不同属性规则Groups
