using System;
using System.Collections.Generic;
using System.Text;
using Refit;
using Trike.Views;
using System.Threading.Tasks;
using Trike.ResponseModels;
using Refit;

namespace Trike.Services
{
    public interface ITrikeAPI
    {

        [Post("/api/User/UserRegistration")]
        [Headers("Content-Type: application/json; charset=UTF-8")]
        Task<RegisterResponseModel> Register([Body] string userdata);

        [Post("/api​/User/UserLogin")]
        [Headers("Content-Type: application/json; charset=UTF-8")]
        Task<LoginResponseModel> Login([Body] string userdata);


        [Get("/User/GetUserDetailById?recordId={RecordId}")]
        [Headers("Content-Type: application/json; charset=UTF-8")]
        Task<Root> GetUserDetail([Header("Authorization")] string auth_token, int RecordId);


        [Get("/BraintreeGateway/GetClientToken?aCustomerId={customerID}")]
        [Headers("Content-Type: application/json; charset=UTF-8")]
        Task<ClientTokenResponseModel> GetClientToken([Header("Authorization")] string auth_token, string customerID);
    }
}
