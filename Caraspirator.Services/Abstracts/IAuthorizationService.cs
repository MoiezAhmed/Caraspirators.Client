using Caraspirator.Data.Entities.Identity;
using Caraspirator.Data.Entities.Requests;
using Caraspirator.Data.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Services.Abstracts;

public interface IAuthorizationService
{
    public Task<string> AddRoleAsync(string roleName);
    
    public Task<bool> IsRoleExistByName(string roleName);

    public Task<string> EditRoleAsync(EditRoleRequest request);

    public Task<string> DeleteRoleAsync(int roleId);

    public Task<List<Role>> GetRolesList();

    public Task<Role> GetRoleById(int id);

    public Task<ManageUserRolesResult> ManageUserRolesData(EspkUser user);

    public Task<string> UpdateUserRoles(UpdateUserRolesRequest request);

    public Task<ManageUserClaimsResult> ManageUserClaimData(EspkUser user);

    public Task<string> UpdateUserClaims(UpdateUserClaimsRequest request);
}

