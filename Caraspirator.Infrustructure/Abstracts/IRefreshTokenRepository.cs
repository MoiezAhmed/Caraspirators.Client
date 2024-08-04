using Caraspirator.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Infrustructure.Abstracts;

public interface IRefreshTokenRepository:IGenericRepositoryAsync<UserRefreshToken>
{

}
