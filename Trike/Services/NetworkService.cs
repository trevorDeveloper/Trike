using System;
using System.Collections.Generic;
using System.Text;
using Refit;

namespace Trike.Services
{
    class NetworkService
    {

        public static ITrikeAPI apiService;
        static string baseUrl = "http://154.0.166.250/TrikeAPI/";
        public static ITrikeAPI GetApiService()
        {
            apiService = RestService.For<ITrikeAPI>(baseUrl);
            return apiService;
        }
    }
}
