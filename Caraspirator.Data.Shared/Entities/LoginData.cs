using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Data.Shared.Entities;

public class LoginData
{
    public string accessToken { get; set; }
    public RefreshToken refreshToken { get; set; }
}
