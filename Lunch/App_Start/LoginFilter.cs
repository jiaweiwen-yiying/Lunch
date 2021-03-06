﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lunch.App_Start
{
    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var filter = filterContext;
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }
            else
            {
                if (filter.HttpContext.Request.RawUrl.Contains("AdminList") && HttpContext.Current.User.Identity.Name.ToLower() != "admin")
                {
                    filterContext.Result = new RedirectResult("/Order/List");
                }
            }
        }
    }
}