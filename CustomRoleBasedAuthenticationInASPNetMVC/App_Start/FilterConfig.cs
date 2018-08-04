﻿using System.Web;
using System.Web.Mvc;
using CRBA.Attributes;

namespace CustomRoleBasedAuthenticationInASPNetMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizedUserAttribute());
            filters.Add(new HandleErrorAttribute());
            
        }
    }
}
