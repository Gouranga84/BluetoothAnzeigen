using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;

using BluetoothAnzeigen.Models;

namespace BluetoothAnzeigen.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        ObservableCollection<EinkaufEntry> _einkaufEntries;
        public ObservableCollection<EinkaufEntry> EinkaufEntries
        {
            get => _einkaufEntries;
            set
            {
                _einkaufEntries = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            EinkaufEntries = new ObservableCollection<EinkaufEntry>
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
        }
    }
}
