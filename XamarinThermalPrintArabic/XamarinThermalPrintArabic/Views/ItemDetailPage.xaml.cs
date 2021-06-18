using System.ComponentModel;
using Xamarin.Forms;
using XamarinThermalPrintArabic.ViewModels;

namespace XamarinThermalPrintArabic.Views
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