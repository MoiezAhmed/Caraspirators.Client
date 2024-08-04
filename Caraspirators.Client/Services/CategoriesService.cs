using Caraspirators.Client.Framework.Exceptions;
using Caraspirators.Client.IServices;
using MonkeyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;


namespace Caraspirators.Client.Services;

public class CategoriesService :RestServiceBase
{
	public CategoriesService(IConnectivity connectivity, IBarrel cacheBarrel) : base(connectivity, cacheBarrel)
{
   // SetBaseURL(Constants.ApiServiceURL);
}

public async Task<IEnumerable<Category>> GetCategoriesAsync()
{
        try
        {
            var resourceUri = "Categories/getcategories";

            var result = await GetAsync<IEnumerable<Category>>(resourceUri, 0);

            return result;
        }
        catch (InternetConnectionException iex)
        {
            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
        finally
        {
          
        }

    }


}

