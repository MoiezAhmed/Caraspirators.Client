using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirators.Client.IServices;

public interface  IAuthService
{
    Task<SiginResponse> SigninAsync(SiginRequest request);
}
