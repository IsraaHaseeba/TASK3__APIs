using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace UsersAPI
{
    namespace ActionFilters.Filters
    {
        public class ActionFilterExample : Attribute,IActionFilter
        {
            private string v;

            public ActionFilterExample(string v)
            {
                this.v = v;
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                
                    var param = context.HttpContext.Request.Headers["Roles"];
                if (param == v) { return; }

                else
                {
                    context.Result = new BadRequestObjectResult("Not autherized");
                    return;
                }

            }
            

            public void OnActionExecuted(ActionExecutedContext context)
            {
                // our code after action executes
            }
        }
    }
}
