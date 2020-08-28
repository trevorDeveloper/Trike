using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trike.Template
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetails : ContentPage
    {

        public string FName, LName;
        public ContactDetails(string fName,string lName)
        {
            InitializeComponent();
            FName = fName;
            LName = lName;
        }

        //public ContactDetails() { }

        private  async void Btn_Next_Clicked(object sender, EventArgs e)
        {
            string email = Email.Text.ToString().ToLower().Trim();
            string mobileNumber = Mobile.Text;

            var emailPattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            var numberPattern = "^[0-9]{9,12}$";


            if (!Regex.IsMatch(mobileNumber, numberPattern))
            {
                errorMsg.Text = "Invalid Mobile Number";
            }

            else
            {
                
                if (Regex.IsMatch(email, emailPattern))
                {
                    
                    mobileNumber.ToString().Trim();
                    await Navigation.PushAsync(new Password(FName, LName, email, mobileNumber));
                }
                else
                {
                    errorMsg.Text = "Invalid Email";
                }
            }
        }
    }
}