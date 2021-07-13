using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetTest_3.Data
{
    public class AccountRoleSeed
    {
        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            var roleMgr = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            foreach (var rolename in RoleNames.AllRoles)
            {
                var role = roleMgr.FindByNameAsync(rolename).Result;

                if(role == null)
                {
                    var result = roleMgr.CreateAsync(new IdentityRole { Name = rolename }).Result;
                    if(!result.Succeeded) throw new Exception(result.Errors.First().Description);
                }
            }

            var userMgr = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var adminResult = await userMgr.CreateAsync(DefaultUsers.Administrator, "User123!");
            var userResult = await userMgr.CreateAsync(DefaultUsers.User, "User123!");
            var moderatorResult = await userMgr.CreateAsync(DefaultUsers.Moderator, "User123!");

            if(adminResult.Succeeded || userResult.Succeeded || moderatorResult.Succeeded)
            {
                var adminUser = await userMgr.FindByEmailAsync(DefaultUsers.Administrator.Email);
                var commonUser = await userMgr.FindByEmailAsync(DefaultUsers.User.Email);
                var moderatorUser = await userMgr.FindByEmailAsync(DefaultUsers.Moderator.Email);

                await userMgr.AddToRoleAsync(adminUser, RoleNames.Administrator);
                await userMgr.AddToRoleAsync(commonUser, RoleNames.User);
                await userMgr.AddToRoleAsync(moderatorUser, RoleNames.Moderator);
            }
        }
    }

    public static class RoleNames
    {
        public const string Administrator = "Администратор";
        public const string User = "Пользователь";
        public const string Moderator = "Модератор";

        public static IEnumerable<string> AllRoles
        {
            get
            {
                yield return Administrator;
                yield return User;
                yield return Moderator;
            }
        }
    }

    public static class DefaultUsers
    {
        public static readonly IdentityUser Administrator = new IdentityUser
        {
            Email = "admin@test.ru",
            EmailConfirmed = true,
            UserName = "admin@test.ru"
        };

        public static readonly IdentityUser Moderator = new IdentityUser
        {
            Email = "moderator@test.ru",
            EmailConfirmed = true,
            UserName = "moderator@test.ru"
        };

        public static readonly IdentityUser User = new IdentityUser
        {
            Email = "user@test.ru",
            EmailConfirmed = true,
            UserName = "user@test.ru"
        };

        public static IEnumerable<IdentityUser> AllUsers
        {
            get
            {
                yield return Administrator;
                yield return Moderator;
                yield return User;
            }
        }
    }
}
