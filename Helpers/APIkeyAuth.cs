//using System;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;

//namespace project.Helpers
//{
//    public class APIkeyAuth
//    {
//        private readonly RequestDelegate next;
//        private readonly string relm;

//        public APIkeyAuth(RequestDelegate next,string relm)
//        {
//            this.next = next;
//            this.relm = relm;
//        }
//        public async Task InvokeAsync (HttpContext context)
//        {
//            if (!context.Request.Headers.ContainsKey("Authorization"))
//            {
//                context.Response.StatusCode = 401;
//                await context.Response.WriteAsync("Unauthorized");
//                return;
//            }

//            //Basic userid:password

//            var header = context.Response.Headers["Authorization"];
//            var encodedCreds = header.Substring(6);
//            var creds = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCreds));
//            string[] uidpw = creds.Split(":");
//            var uid = uidpw[0];
//            var password = uidpw[1];

//            if (uid != "Anushka" && password != "password")
//            {
//                context.Response.StatusCode = 401;
//                await context.Response.WriteAsync("Unauthorized");
//                return;
//            }

//            await next(context);

//        }
//    }


using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
namespace project.Helpers
{
    public class APIKeyAuth : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeaderName = "Authorization";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var potentialApiKey))
            {
                context.Result = new BadRequestResult();
                return;
            }
            else
            {
                var check = CheckAPIkey(potentialApiKey);
                if (!check)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
            await next();
        }
        public static bool CheckAPIkey(string Key)
        {
            if (Key != null)
            {
                return true;
            }
            return false;
        }
    }
}
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//namespace project.Helpers
//{
//    public class APIKeyAuth : Attribute, IAsyncActionFilter
//    {
//        private const string ApiUsername = "user";
//        private const string ApiPassword = "pass";
//        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
//        {
//            if (!context.HttpContext.Request.Headers.TryGetValue(ApiUsername, out var username) || !context.HttpContext.Request.Headers.TryGetValue(ApiPassword, out var passkey))
//            {
//                context.Result = new BadRequestResult();
//                return;
//            }
//            else
//            {
//                bool check = PasswordVerify(username, passkey);
//                if (!check)
//                {
//                    context.Result = new UnauthorizedResult();
//                    return;
//                }
//            }
//            await next();
//        }
//        public static bool PasswordVerify(String user, String passkey)
//        {
//            if (user == "Anushka" && passkey == "123")
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//    }

//}


