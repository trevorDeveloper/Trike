using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Trike.Views;
using System.Security.Cryptography;
using Trike.Helpers;
using Trike.Authentication;
using Acr.UserDialogs;
using Trike.RequestModels;
using Trike.Manager;

namespace Trike.Template
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Password : ContentPage
    {
        public string FName, LName, Email, Mobile;
        public Password(string fName,string lName,string email,string mobile)
        {
            InitializeComponent();

            FName = fName;
            LName = lName;
            Email = email;
            Mobile = mobile;
        }

        private async void completeSignUp_Clicked(object sender, EventArgs e)
        {
            string Password = password.Text;
            string ConfirmPass = ConfirmPassord.Text;



            // Create Hash value for password
            string hash = "";
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GenerateHash.GetMd5Hash(md5Hash, Password);
            }


            if (string.IsNullOrEmpty(Password))
            {
                errorMsg.Text = "Password cannot be empty";
            }
            else if (string.IsNullOrEmpty(ConfirmPass))
            {
                errorMsg.Text = "Confirm Password cannot be empty";
            }
            else if (Password.Length <= 3)
            {
                errorMsg.Text = "Password Length must be greater than 3 characters";
            }
            else if (ConfirmPass.Length <= 3)
            {
                errorMsg.Text = "Confirm Password Length must be greater than 3 characters";
            }
            else if(Password != ConfirmPass)
            {
                errorMsg.Text = "Passwords must be the same";
            }
            else
            {
                Password.ToString().Trim();
              
                bool isInternetConnectionEnabled = await CheckInternetConnection.CheckConnection();
                if (isInternetConnectionEnabled)
                {
                    UserDialogs.Instance.ShowLoading("Loading");
                    RegisterUserRequestModel registerUserRequestModel = new RegisterUserRequestModel();
                    registerUserRequestModel.firstName = FName;
                    registerUserRequestModel.lastName = LName;
                    registerUserRequestModel.email = Email;
                    registerUserRequestModel.mobile = Mobile;
                    registerUserRequestModel.password = hash;

                    var result = await TrikeAPIManager.Register(registerUserRequestModel);
                    UserDialogs.Instance.HideLoading();

                    if (result != null && result.isSuccess == true)
                    {
                        await DisplayAlert("Registration Successful", result.message, "Continue");
                        await Navigation.PushAsync(new Dashboard());
                        }
                    else if (result != null && result.isSuccess == false)
                    {
                        //await Navigation.PushAsync(new MaintenanceAlert());
                        await DisplayAlert("Error", result.message, "Cancel");
                    }
                    else
                    {
                        await Navigation.PushAsync(new MaintenanceAlert());
                    }
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Alert", "No internet connection", "Ok");
                }
           }
            
        }
    }
}