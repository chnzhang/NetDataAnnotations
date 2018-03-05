using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetDataAnnotats.CoreTest.Filter
{
    public class GlobalActionFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                Dictionary<string, object> hr = new Dictionary<string, object>();
                var Keys = actionContext.ModelState.Keys.ToList(); //获取每一个key对应的ModelStateDictionary 
                foreach (var key in Keys)
                {
                    var erro = actionContext.ModelState[key].Errors.FirstOrDefault();
                    if (erro != null)
                    {
                        hr.Add("code",400);
                        hr.Add("msg",erro.ErrorMessage);
                        break;
                    }                
                }
                actionContext.Result = new ApplicationErrorResult(hr);

                //    actionContext.re = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
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
