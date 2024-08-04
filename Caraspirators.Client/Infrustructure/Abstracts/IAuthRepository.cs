using Caraspirators.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirators.Client.Infrustructure.Abstracts
{
    public interface IAuthRepository
    {
        Task<Models.SiginRequest> LoginAsync(Models.SiginRequest request);
    }
}
