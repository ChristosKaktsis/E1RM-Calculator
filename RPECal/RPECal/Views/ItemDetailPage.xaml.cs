using RPECal.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RPECal.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}