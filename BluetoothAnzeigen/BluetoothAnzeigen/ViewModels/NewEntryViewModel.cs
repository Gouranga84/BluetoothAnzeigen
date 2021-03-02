using System;
using Xamarin.Forms;

using BluetoothAnzeigen.Models;

namespace BluetoothAnzeigen.ViewModels
{
    public class NewEntryViewModel : BaseViewModel
    {
        #region setzen/lesen der EinkaufEntry Felder
        double _betrag;
        public double Betrag
        {
            get => _betrag;
            set
            {
                _betrag = value;
                OnPropertyChanged();
            }
        }
        string _marktname;
        public string Marktname
        {
            get => _marktname;
            set
            {
                _marktname = value;
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }
        DateTime _datum;
        public DateTime Datum
        {
            get => _datum;
            set
            {
                _datum = value;
                OnPropertyChanged();
            }
        }
        int _artikelanzahl;
        public int Artikelanzahl
        {
            get => _artikelanzahl;
            set
            {
                _artikelanzahl = value;
                OnPropertyChanged();
            }
        }
        double _latitude;
        public double Latitude
        {
            get => _latitude;
            set
            {
                _latitude = value;
                OnPropertyChanged();
            }
        }
        double _longitude;
        public double Longitude
        {
            get => _longitude;
            set
            {
                _longitude = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Konstruktor
        public NewEntryViewModel()
        {
            Datum = DateTime.Today;
        }
        #endregion
        #region Command Save
        Command _saveCommand;
        public Command SaveCommand => _saveCommand ?? (_saveCommand = new Command(Save, CanSave));

        void Save()
        {
            var newItem = new EinkaufEntry
            {
                Betrag = Betrag,
                Marktname = Marktname,
                Datum = Datum,
                Artikelanzahl = Artikelanzahl,
                Latitude = Latitude,
                Longitude = Longitude
            };

            // TODO: Persist entry in a later chapter
        }

        bool CanSave() => !string.IsNullOrWhiteSpace(Marktname);
        #endregion
    }
}
