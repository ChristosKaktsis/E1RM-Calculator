using E1RM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E1RM.Views
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