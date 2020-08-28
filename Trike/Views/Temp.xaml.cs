using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trike.Template;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trike.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Temp : ContentPage
    {
        public Temp()
        {
            InitializeComponent();
        }

        private async void loginBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginTemplate());
        }

        private async void CreateAccountBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Name());
            //await Navigation.PushAsync(new SignupTemplate());
        }
    }
}