using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirators.Client.Framework.Services;

public class Test : RestServiceBase
{
    protected Test(IConnectivity connectivity, IBarrel cacheBarrel) : base(connectivity, cacheBarrel)
    {
    }

    //public async Task testmethod(Person person )
    //{
    //  var m=  await PostAsync<Category>("", person);
    //}


}
public class Person { }