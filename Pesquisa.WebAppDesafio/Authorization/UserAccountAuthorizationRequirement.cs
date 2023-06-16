﻿// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using AppDesafio.Helpers;
using Microsoft.AspNetCore.Authorization;
using Pesquisa.IdentityApi.Core;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppDesafio.Authorization;

public class UserAccountAuthorizationRequirement : IAuthorizationRequirement
{
    public UserAccountAuthorizationRequirement(string operationName)
    {
        this.OperationName = operationName;
    }


    public string OperationName { get; private set; }
}



public class ViewUserAuthorizationHandler : AuthorizationHandler<UserAccountAuthorizationRequirement, string>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserAccountAuthorizationRequirement requirement, string targetUserId)
    {
        if (context.User == null || requirement.OperationName != AccountManagementOperations.ReadOperationName)
            return Task.CompletedTask;

        if (context.User.HasClaim(ClaimConstants.Permission, ApplicationPermissions.ViewUsers) || GetIsSameUser(context.User, targetUserId))
            context.Succeed(requirement);

        return Task.CompletedTask;
    }


    private bool GetIsSameUser(ClaimsPrincipal user, string targetUserId)
    {
        if (string.IsNullOrWhiteSpace(targetUserId))
            return false;

        return Utilities.GetUserId(user) == targetUserId;
    }
}



public class ManageUserAuthorizationHandler : AuthorizationHandler<UserAccountAuthorizationRequirement, string>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserAccountAuthorizationRequirement requirement, string targetUserId)
    {
        if (context.User == null ||
            (requirement.OperationName != AccountManagementOperations.CreateOperationName &&
             requirement.OperationName != AccountManagementOperations.UpdateOperationName &&
             requirement.OperationName != AccountManagementOperations.DeleteOperationName))
            return Task.CompletedTask;

        if (context.User.HasClaim(ClaimConstants.Permission, ApplicationPermissions.ManageUsers) || GetIsSameUser(context.User, targetUserId))
            context.Succeed(requirement);

        return Task.CompletedTask;
    }


    private bool GetIsSameUser(ClaimsPrincipal user, string targetUserId)
    {
        if (string.IsNullOrWhiteSpace(targetUserId))
            return false;

        return Utilities.GetUserId(user) == targetUserId;
    }
}