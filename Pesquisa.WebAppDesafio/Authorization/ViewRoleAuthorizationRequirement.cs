﻿// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using Microsoft.AspNetCore.Authorization;
using Pesquisa.IdentityApi.Core;
using System.Threading.Tasks;

namespace Pesquisa.WebAppDesafio.Authorization;

public class ViewRoleAuthorizationRequirement : IAuthorizationRequirement
{

}



public class ViewRoleAuthorizationHandler : AuthorizationHandler<ViewRoleAuthorizationRequirement, string>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ViewRoleAuthorizationRequirement requirement, string roleName)
    {
        if (context.User == null)
            return Task.CompletedTask;

        if (context.User.HasClaim(ClaimConstants.Permission, ApplicationPermissions.ViewRoles) || context.User.IsInRole(roleName))
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
