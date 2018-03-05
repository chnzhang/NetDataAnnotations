# NetDataAnnotations
自定义注解，可分组，错误信息xml化

 public class UserInput
    {
        public int UserId { get; set; }

        [NetRequired(Message = "uservalidate:usernamempty", Groups = new[] { BaseModelType.Insert, BaseModelType.SelectOne })]
        public string UserName { get; set; }

        [NetRequired(Message = "uservalidate:userphoneempty", Groups = new[] { BaseModelType.Insert, BaseModelType.SelectOne })]
        public string UserPhone { get; set; }
    }

可设置xml的错误信息Message
可分组验证不同属性规则Groups
