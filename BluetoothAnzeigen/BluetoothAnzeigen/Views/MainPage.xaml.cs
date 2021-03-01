using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BluetoothAnzeigen.Models;

namespace BluetoothAnzeigen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var items = new List<EinkaufEntry>
            {
                new EinkaufEntry
                {
                    Betrag = 34.65,
                    Marktname = "Norma",
                    Datum = new DateTime(2021, 1, 14),
                    Artikelanzahl = 9,
                    Latitude = 49.494956,
                    Longitude = 10.975695
                },
                new EinkaufEntry
                {
                    Betrag = 73.49,
                    Marktname = "Edeka",
                    Datum = new DateTime(2021, 2, 27),
                    Artikelanzahl = 17,
                    Latitude = 49.459263,
                    Longitude = 11.007843
                },
                new EinkaufEntry
                {
                    Betrag = 14.75,
                    Marktname = "Real",
                    Datum = new DateTime(2021, 2, 14),
                    Artikelanzahl = 3,
                    Latitude = 49.442749,
                    Longitude = 11.016981
                }
            };

            einkäufe.ItemsSource = items;
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