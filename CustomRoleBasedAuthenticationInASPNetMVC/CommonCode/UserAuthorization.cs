using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomRoleBasedAuthenticationInASPNetMVC.DataAccessLayer;
using CustomRoleBasedAuthenticationInASPNetMVC.Models;

namespace CustomRoleBasedAuthenticationInASPNetMVC.CommonCode
{
    public static class UserAuthorization
    {
        private static readonly UserDbContext _dbContext = new UserDbContext();
        public static bool IsUserAthorizedInAction(int  userId,string controllerName, string actionName)
        {
            bool userAuthorizationStatus = false;
            ControllerAction controllerAction = _dbContext.ControllerActions.FirstOrDefault(x => x.ActionCategory.ActionCategoryName == controllerName && x.ActionName == actionName);
            if (controllerAction != null)
            {
                userAuthorizationStatus = _dbContext.Users.Where(u => u.UserId == userId).Any(u => u.Roles.Any(r => r.ControllerActions.Any(ca => ca.ActionName == actionName)));
            }
            
            return userAuthorizationStatus;
        }

        public static bool IsUserSuperAdmin(int userId)
        {
            bool roleStatus = _dbContext.Users.Where(x => x.UserId == userId).Any(u => u.Roles.Any(r => r.RoleName == "SuperAdmin"));
            return roleStatus;
        }
    }
}