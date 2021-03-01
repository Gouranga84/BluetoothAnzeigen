using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

using BluetoothAnzeigen.Models;

namespace BluetoothAnzeigen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(EinkaufEntry entry)
        {
            InitializeComponent();

            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(entry.Latitude, entry.Longitude), Distance.FromMiles(.5)));

            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = entry.Marktname,
                Position = new Position(entry.Latitude, entry.Longitude)
            });

            betrag.Text = $"{entry.Betrag}€ bezahlt.";
            marktname.Text = entry.Marktname;
            date.Text = entry.Datum.ToString("M");
            artikelanzahl.Text = $"{entry.Artikelanzahl} Artikel gekauft.";
            
        }
    }
}