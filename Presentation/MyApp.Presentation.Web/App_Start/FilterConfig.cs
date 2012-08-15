﻿using MyApp.Presentation.Web.Infrastructure;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Presentation.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizeAttribute());
            filters.Add(new HandleErrorAttribute());

        }
    }
}