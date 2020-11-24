using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Service.DTOs.AppSettings;

namespace Data.Authentication
{
	public static class AuthenticationContextInitializer
	{
		public static void SeedRolesAndUsers(
			UserManager<IdentityUser> userManager,
			RoleManager<IdentityRole> roleManager,
			IOptions<SystemDefaults> systemDefaultOptions)
		{
			var systemDefaults = systemDefaultOptions.Value;

			CreateRoleIfDoesntExist(roleManager, systemDefaults.AdministatorRole);
			CreateRoleIfDoesntExist(roleManager, systemDefaults.BasicUserRole);

			var systemAdmin = systemDefaults.AdminCredentials;
			if (userManager.FindByNameAsync(systemAdmin.Login).Result is null)
			{
				var user = new IdentityUser(systemAdmin.Login);
				var result = userManager.CreateAsync(user, systemAdmin.Password).Result;

				if (result.Succeeded)
					userManager.AddToRoleAsync(user, systemDefaults.AdministatorRole).Wait();
			}
		}

		private static void CreateRoleIfDoesntExist(RoleManager<IdentityRole> roleManager, string roleName)
		{
			if (roleManager.FindByNameAsync(roleName).Result is null)
			{
				var identityRole = new IdentityRole(roleName);
				roleManager.CreateAsync(identityRole).Wait();
			}
		}
	}
}
