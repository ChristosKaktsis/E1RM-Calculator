using E1RM.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace E1RM.Views
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