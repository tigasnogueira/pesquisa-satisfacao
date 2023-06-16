﻿using Microsoft.EntityFrameworkCore;
using Pesquisa.IdentityApi.Core;
using Pesquisa.IdentityApi.Interfaces;
using Pesquisa.IdentityApi.Models;

namespace Pesquisa.IdentityApi.Context;

public interface IDatabaseInitializer
{
    Task SeedAsync();
}

public class DatabaseInitializer : IDatabaseInitializer
{
    readonly ApplicationDbContext _context;
    readonly IAccountManager _accountManager;
    readonly ILogger _logger;

    public DatabaseInitializer(ApplicationDbContext context, IAccountManager accountManager, ILogger<DatabaseInitializer> logger)
    {
        _accountManager = accountManager;
        _context = context;
        _logger = logger;
    }

    public async Task SeedAsync()
    {
        await _context.Database.MigrateAsync().ConfigureAwait(false);
        await SeedDefaultUsersAsync();
    }

    private async Task SeedDefaultUsersAsync()
    {
        if (!await _context.Users.AnyAsync())
        {
            _logger.LogInformation("Generating inbuilt accounts");

            const string adminRoleName = "administrator";
            const string userRoleName = "user";

            await EnsureRoleAsync(adminRoleName, "Default administrator", ApplicationPermissions.GetAllPermissionValues());
            await EnsureRoleAsync(userRoleName, "Default user", new string[] { });

            await CreateUserAsync("admin", "tempP@ss123", "Inbuilt Administrator", "admin@ebenmonney.com", "+1 (123) 000-0000", new string[] { adminRoleName });
            await CreateUserAsync("user", "tempP@ss123", "Inbuilt Standard User", "user@ebenmonney.com", "+1 (123) 000-0001", new string[] { userRoleName });

            _logger.LogInformation("Inbuilt account generation completed");
        }
    }

    private async Task EnsureRoleAsync(string roleName, string description, string[] claims)
    {
        if ((await _accountManager.GetRoleByNameAsync(roleName)) == null)
        {
            _logger.LogInformation($"Generating default role: {roleName}");

            ApplicationRole applicationRole = new ApplicationRole(roleName, description);

            var result = await this._accountManager.CreateRoleAsync(applicationRole, claims);

            if (!result.Succeeded)
                throw new Exception($"Seeding \"{description}\" role failed. Errors: {string.Join(Environment.NewLine, result.Errors)}");
        }
    }

    private async Task<ApplicationUser> CreateUserAsync(string userName, string password, string fullName, string email, string phoneNumber, string[] roles)
    {
        _logger.LogInformation($"Generating default user: {userName}");

        ApplicationUser applicationUser = new ApplicationUser
        {
            UserName = userName,
            FullName = fullName,
            Email = email,
            PhoneNumber = phoneNumber,
            EmailConfirmed = true,
            IsEnabled = true
        };

        var result = await _accountManager.CreateUserAsync(applicationUser, roles, password);

        if (!result.Succeeded)
            throw new Exception($"Seeding \"{userName}\" user failed. Errors: {string.Join(Environment.NewLine, result.Errors)}");

        return applicationUser;
    }
}
