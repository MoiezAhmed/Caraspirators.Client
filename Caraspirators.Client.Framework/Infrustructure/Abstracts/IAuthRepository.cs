
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Caraspirators.Client.Framework.Infrustructure.Abstracts;

public interface IAuthRepository:IGenericRepository<LoginData>
{
    Task<(LoginData data, bool succeeded, string message)> LoginAsync(string endpoint,SiginRequest loginRequest);
}
