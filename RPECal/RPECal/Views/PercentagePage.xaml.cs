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
    public partial class PercentagePage : ContentPage
    {
        private PercentageViewModel _viewModel;

        public PercentagePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PercentageViewModel();
        }
    }
}