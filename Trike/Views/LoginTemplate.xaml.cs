using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Trike.Authentication;
using System.Diagnostics;
using Trike.RequestModels;
using Acr.UserDialogs;
using Trike.Helpers;
using Trike.Manager;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Trike.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginTemplate : ContentPage
    {
        public LoginTemplate()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            var login = new LoginTemplate();
            bool result = true;
            if (App.Current.MainPage == login)
            {
                result = false;
            }

            return result;
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {

            string email = Email.Text.Trim().ToLower();
            string emailPattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            var password = Password.Text;


            if (string.IsNullOrEmpty(email))
            {
                errorMsg.Text = "Email Field cannot be empty";
            }
            else if (string.IsNullOrEmpty(password))
            {
                errorMsg.Text = "Password Field cannot be empty";
            }
            else
            {
               // email.Trim().ToLower();
                if (Regex.IsMatch(email, emailPattern))
                {
                        bool isInternetConnectionEnabled = await CheckInternetConnection.CheckConnection();
                         if (isInternetConnectionEnabled)
                        {
                            UserDialogs.Instance.ShowLoading("Loading");

                            string hash = "";
                            using (MD5 md5Hash = MD5.Create())
                            {
                                hash = GenerateHash.GetMd5Hash(md5Hash, password);
                            }

                            LoginRequestModel loginRequestModel = new LoginRequestModel();
                            loginRequestModel.email = email;
                            loginRequestModel.password = hash;

                            var result = await TrikeAPIManager.Login(loginRequestModel);
                            UserDialogs.Instance.HideLoading();
                            if (result != null && result.issuccess == true)
                            {
                                Preferences.Set("auth_token", "Bearer " + result.token);
                                Preferences.Set("Email", result.userDetails.email);
                                Preferences.Set("recordid", result.userDetails.userId.ToString());

                            await DisplayAlert("Success", result.messgae, "Continue");
                                await Navigation.PushAsync(new Dashboard());
                            }

                            else if (result != null && result.issuccess == false)
                            {
                                await DisplayAlert("Error", result.messgae, "Cancel");
                            }
                            else
                            {

                            //await Navigation.PushAsync(new Dashboard());
                            await Navigation.PushAsync(new MaintenanceAlert());
                            }

                        }
                        else
                        {
                            App.Current.MainPage.DisplayAlert("Alert", "No internet connection", "Ok");
                        }
       
                }
                else
                {
                    errorMsg.Text = "Invalid Email";
                }
            }
        }
    }
}