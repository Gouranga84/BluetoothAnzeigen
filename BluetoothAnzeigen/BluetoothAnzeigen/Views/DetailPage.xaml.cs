using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

using BluetoothAnzeigen.Models;
using BluetoothAnzeigen.ViewModels;

namespace BluetoothAnzeigen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        DetailViewModel ViewModel => BindingContext as DetailViewModel;
        public DetailPage(EinkaufEntry entry)
        {
            InitializeComponent();

            BindingContext = new DetailViewModel(entry);

            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(ViewModel.Entry.Latitude, ViewModel.Entry.Longitude), Distance.FromMiles(.5)));
            
            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = entry.Marktname,
                Position = new Position(ViewModel.Entry.Latitude, ViewModel.Entry.Longitude)
            });
                        
        }
    }
}