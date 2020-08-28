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
    public partial class MyTrike : ContentPage
    {
        public MyTrike()
        {
            InitializeComponent();
        }
        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (mySwitch.IsToggled)
            {
                state.Text = "Go Offline";
            }
            else
            {
                state.Text = "Go Online";
            }
        }
    }
}