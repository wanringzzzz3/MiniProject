using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MiniProject.Models;

namespace MiniProject.Controllers
{
    public class BaseController : Controller
    {
        public const string SessionKeyUser = "_User";
        public const string SessionKeyUserName = "_Username";
        public const string UserDefault = "admin";
        public const string PasswordDefault = "1qa2ws3ed4rf";
        public const int PageSize = 8;


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var descriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
            var actionName = descriptor.ActionName;
            //string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            if (actionName.Equals("Login") || (actionName.Equals("Index") && descriptor.ControllerName.Equals("Booking")))
            {
                return;
            }
            if (HttpContext.Session.Get(SessionKeyUser) == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Login",
                    //returnurl = String.Format("/{0}/{1}", descriptor.ControllerName, descriptor.ActionName)
                }));

                base.OnActionExecuting(filterContext);
            }
            else
            {
                var username = HttpContext.Session.GetString(SessionKeyUserName);
                ViewData[SessionKeyUserName] = username;
            }
        }

        public void SetCustomError(string error)
        {
            ViewBag.CustomError = true;
            ModelState.AddModelError("CustomError", error);
        }
        public int UserId => GetDataSession(SessionKeyUser);
        public int Username => GetDataSession(SessionKeyUserName);

        public int GetDataSession(string key)
        {
            if (HttpContext.Session.Get(key) != null)
            {
                var sessionKey =  HttpContext.Session.GetInt32(key);
                return sessionKey.Value;
            }
            return 0;
        }
    }
}
