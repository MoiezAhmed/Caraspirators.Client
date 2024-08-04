using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;


namespace Caraspirator.Data.Entities.Identity;

public class EspkUser : IdentityUser<int>
{
    public EspkUser()
    {
     UserRefreshTokens = new HashSet<UserRefreshToken>();
    }

    public string? FullName { get; set; }
    public string? Address { get; set; }
    public string? Country { get; set; }

    [EncryptColumn]
    public string? Code { get; set; }

    [InverseProperty(nameof(UserRefreshToken.user))]
    public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
}
