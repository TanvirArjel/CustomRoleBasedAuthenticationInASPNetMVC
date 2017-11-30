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
            ControllerAction controllerAction = _dbContext.ControllerActions.FirstOrDefault(x => x.ActionCategory.ActionCategoryName == controllerName && x.ActionName == actionName);
            //bool userAuthorizationStatus = _dbContext.Users.Where(x => x.UserId == userId).Any(x => x.ControllerActions.Any(y => y.ActionId == controllerAction.ActionId));
            return false;
        }

        public static bool IsUserSuperAdmin(int userId)
        {
            bool roleStatus = _dbContext.Users.Where(x => x.UserId == userId).SelectMany(x => x.Roles).Any(x => x.RoleName == "SuperAdmin");
            return roleStatus;
        }
    }
}