using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trike.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trike.Template
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Account : ContentPage
    {
        public Account()
        {
            InitializeComponent();
        }


        private async void GetData()
        {


            var apiService = NetworkService.GetApiService();

            var auth_token = Preferences.Get("auth_token", "");

            var RecordId = Preferences.Get("recordid", null);



            var data = await apiService.GetUserDetail(auth_token, Int32.Parse(RecordId));

            firstName.Text = data.userDetails.firstName.ToString();
            lastName.Text = data.userDetails.lastName.ToString();
            Email.Text = data.userDetails.email.ToString();
            mobileNumber.Text = data.userDetails.mobile.ToString();
            //FName.Detail = data.userData.fname.ToString();
            //LName.Detail = data.userData.lname.ToString();
            //Email.Detail = data.userData.email.ToString();
            //Mobile.Detail = data.userData.mobile.ToString();


        }
    }




}