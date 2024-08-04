using Caraspirators.Client.Infrustructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caraspirators.Client.Infrustructure.Base;
namespace Caraspirators.Client.Infrustructure.Repositries
{
    public class CategoryRepository : GenericRepository<Category>
    {
        private readonly HttpClient _httpClient;

        private readonly string _EndPointUrl;
        public CategoryRepository(HttpClient httpClient, string endpoint)
         : base(httpClient, endpoint)
        {
        }

    }
}
