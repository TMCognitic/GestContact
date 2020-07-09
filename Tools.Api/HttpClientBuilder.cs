using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using Tools.Api;

namespace Tools.Api
{
    public static class HttpClientBuilder 
    {
        public static HttpClient Build(IApiInfo apIInfo)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                SslProtocols = SslProtocols.Tls12
            };

            handler.ServerCertificateCustomValidationCallback += (request, cert, chain, errors) =>
            {
                return true;
            };


            HttpClient httpClient = new HttpClient(handler);
            httpClient.BaseAddress = apIInfo.BaseAddress;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}
