using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BluetoothAnzeigen.Models;
using BluetoothAnzeigen.ViewModels;

namespace BluetoothAnzeigen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }

        void New_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewEntryEinkauf());
        }

        async void Einkauf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var einkauf = (EinkaufEntry)e.CurrentSelection.FirstOrDefault();

            if (einkauf != null)
            {
                await Navigation.PushAsync(new DetailPage(einkauf));
            }

            //Clear selection
            einkäufe.SelectedItem = null;
        }
    }
}