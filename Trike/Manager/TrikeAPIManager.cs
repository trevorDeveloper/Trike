using System;
using System.Collections.Generic;
using System.Text;
using Trike.Services;
using System.Diagnostics;
using System.Threading.Tasks;
using Trike.RequestModels;
using Trike.ResponseModels;
using Newtonsoft.Json;

namespace Trike.Manager
{
    public class TrikeAPIManager
    {
        public static async Task<LoginResponseModel> Login(LoginRequestModel model)
        {

            try
            {
                var apiService = NetworkService.GetApiService();
                string serializedmodel = JsonConvert.SerializeObject(model);
                var data = await apiService.Login(serializedmodel);
                if (data != null)
                {
                    return data;
                }
                return null;
            }
            catch (Refit.ApiException ex)
            {
                var content = ex.GetContentAs<LoginResponseModel>();
                Debug.WriteLine(ex.Message);
                var s = ex.Content;
                if (s != null)
                {
                    var data = JsonConvert.DeserializeObject<LoginResponseModel>(s);
                    return JsonConvert.DeserializeObject<LoginResponseModel>(s);
                }
                else
                {
                    Console.WriteLine("Error-----------");
                    Console.WriteLine(@" Error {0}", ex.Message);
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static async Task<RegisterResponseModel> Register(RegisterUserRequestModel model)
        {
            try
            {
                var apiService = NetworkService.GetApiService();
                string serializedmodel = JsonConvert.SerializeObject(model);
                var data = await apiService.Register(serializedmodel);
                if (data != null)
                {

                    return data;
                }
                return null;
            }
            catch (Refit.ApiException ex)
            {
                var content = ex.GetContentAs<RegisterResponseModel>();
                Debug.WriteLine(ex.Message);
                var s = ex.Content;
                if (s != null)
                {
                    var data = JsonConvert.DeserializeObject<RegisterResponseModel>(s);
                    return JsonConvert.DeserializeObject<RegisterResponseModel>(s);
                }
                else
                {
                    Console.WriteLine("Error-----------");
                    Console.WriteLine(@" Error {0}", ex.Message);
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static async Task<ClientTokenResponseModel> GetClientToken(string authToken, string customerId)
        {
            try
            {
                var apiService = NetworkService.GetApiService();
                //string serializedmodel = JsonConvert.SerializeObject(model);
                var data = await apiService.GetClientToken(authToken, customerId);
                if (data != null)
                {

                    return data;
                }
                return null;
            }
            catch (Refit.ApiException ex)
            {
                var content = ex.GetContentAs<ClientTokenResponseModel>();
                Debug.WriteLine(ex.Message);
                var s = ex.Content;
                if (s != null)
                {
                    var data = JsonConvert.DeserializeObject<ClientTokenResponseModel>(s);
                    return JsonConvert.DeserializeObject<ClientTokenResponseModel>(s);
                }
                else
                {
                    Console.WriteLine("Error-----------");
                    Console.WriteLine(@" Error {0}", ex.Message);
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    
    }   
}
