using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BluetoothAnzeigen.ViewModels;

namespace BluetoothAnzeigen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEntryEinkauf : ContentPage
    {
        public NewEntryEinkauf()
        {
            InitializeComponent();

            BindingContext = new NewEntryViewModel();
        }
    }
}