using System;

namespace Tools.Api
{
    public class ApiInfo : IApiInfo
    {
        public Uri BaseAddress { get; private set; }

        public ApiInfo(Uri baseAddress)
        {
            BaseAddress = baseAddress;
        }
    }
}
