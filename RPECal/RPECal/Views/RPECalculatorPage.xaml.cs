using RPECal.ViewModels;
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
        private RPECalculatorViewModel _viewModel;

        public RPECalculatorPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RPECalculatorViewModel();
        }
    }
}