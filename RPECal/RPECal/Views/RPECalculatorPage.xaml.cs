using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RPECal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RPECalculatorPage : ContentPage
    {
        public RPECalculatorPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}