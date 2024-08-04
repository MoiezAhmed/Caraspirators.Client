using Caraspirator.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Services.Abstracts;

public interface IApplicationUserService
{
    public Task<string> AddUserAsync(EspkUser user, string password);
}
