using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trike.Template
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Name : ContentPage
    {
        public Name()
        {
            InitializeComponent();
        }

        private async void Btn_Next_Clicked(object sender, EventArgs e)
        {

            string fName = firstName.Text;
            string lName = lastName.Text;
            try
            {

                if(string.IsNullOrEmpty(fName))
                {
                    errorMsg.Text = "First Name cannot be empty";
                }
                else if (string.IsNullOrEmpty(lName))
                {
                    errorMsg.Text = "Last Name cannot be empty";
                }
                else
                {
                    fName.ToString().Trim();
                    lName.ToString().Trim();
                    await Navigation.PushAsync(new ContactDetails(fName,lName));
                }
               

              
            }
            catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "okay");
            }
            
          

        }
    }
}