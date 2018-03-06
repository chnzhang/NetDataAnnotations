using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using NetDataAnnotations;
using NetDataAnnotats.CoreTest.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetDataAnnotats.CoreTest.Filter
{
    public class GlobalActionFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {

            //判断Action是否有参数
            if (actionContext.ActionDescriptor.Parameters.Any())
            {

                //获取验证模型
                var mytype = ((ControllerActionDescriptor)actionContext.ActionDescriptor).MethodInfo.CustomAttributes
                                        .Where(w => w.AttributeType.BaseType == typeof(BaseModelType)).FirstOrDefault();

                //判断是否有验证模型
                if (mytype != null)
                {

                    //组装当前使用的验证模式
                    IDictionary<object, object> dic = new Dictionary<object, object>
                    {
                        { "Model", mytype.AttributeType }
                    };

                    //组装验证类，并触发模型验证
                    ValidationContext context = new ValidationContext(actionContext.ActionArguments.FirstOrDefault().Value, dic);
                    List<ValidationResult> results = new List<ValidationResult>();
                    bool isValid = Validator.TryValidateObject(actionContext.ActionArguments.FirstOrDefault().Value, context, results, false);

                    //根据返回结果 判断是否验证成功 未成功则返回错误信息 已成功则进入方法执行
                    if (isValid == false)
                    {
                        HResult hr = new HResult
                        {
                            Code =200,
                            Msg = results.FirstOrDefault().ErrorMessage
                        };
                        actionContext.Result = new ApplicationErrorResult(hr);

                    }
                }
            }
        }

        public class ApplicationErrorResult : Microsoft.AspNetCore.Mvc.ObjectResult
        {
            public ApplicationErrorResult(object value) : base(value)
            {
            }
        }
    }
}
