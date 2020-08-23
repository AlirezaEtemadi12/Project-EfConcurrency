using System;

namespace EfConcurrency.Common
{
    public static class ConstantSettings
    {
        public const string ApiVersion = "api/v1";
        public const string NotFoundHttp = "HTTP/1.1 404 Not Found";
        public const string NotFound = "Not found";
        public const string Error = "An error has occured";
        public const string Unauthorized = "Unauthorized";
     
        public static readonly string WinBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
    }
}
