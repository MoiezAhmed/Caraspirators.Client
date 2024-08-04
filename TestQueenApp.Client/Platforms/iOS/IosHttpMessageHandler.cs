using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQueenApp.Client.Interfaces;
using Security;
namespace TestQueenApp.Client.Platforms.iOS
{
    internal class IosHttpMessageHandler : IPlatformHttpMessageHandler
    {
        public HttpMessageHandler GetHttpMessageHandler() =>
            new NSUrlSessionHandler
            {
                TrustOverrideForUrl = (NSUrlSessionHandler sender, string url, SecTrust trust) => url.StartsWith("https://localhost")
            };
    }
}

