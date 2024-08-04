using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Data.Shared.Entities;

public class RefreshToken
{
    public string userName { get; set; }
    public string tokenString { get; set; }
    public DateTime expireAt { get; set; }
}
