using System.Web;
using System.Web.Mvc;
using CustomRoleBasedAuthenticationInASPNetMVC.CustomAttributes;

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
