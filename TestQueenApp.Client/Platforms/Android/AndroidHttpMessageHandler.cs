using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQueenApp.Client.Interfaces;
using Xamarin.Android.Net;
using System.Net.Security;
namespace TestQueenApp.Client.Platforms.Android
{
     class AndroidHttpMessageHandler : IPlatformHttpMessageHandler
    {
        public HttpMessageHandler GetHttpMessageHandler() =>
                new AndroidMessageHandler
                {
                    ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
                        certificate?.Issuer == "CN=localhost" || sslPolicyErrors == SslPolicyErrors.None
                };
    }
}

