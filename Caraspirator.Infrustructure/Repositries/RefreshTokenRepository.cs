using Caraspirator.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Infrustructure.Repositries;

public class RefreshTokenRepository: GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
{
    #region Fields
    private DbSet<UserRefreshToken> userRefreshToken;
    #endregion

    #region Constructors
    public RefreshTokenRepository(AppDbContext dbContext) : base(dbContext)
    {
        userRefreshToken = dbContext.Set<UserRefreshToken>();
    }
    #endregion

    #region Handle Functions

    #endregion
}
