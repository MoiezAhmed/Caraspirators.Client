using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirators.Client.Models;

public class LoginData
{
    public string AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
}
