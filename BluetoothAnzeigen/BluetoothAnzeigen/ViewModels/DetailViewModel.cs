using System;
using System.Collections.Generic;
using System.Text;

using BluetoothAnzeigen.Models;

namespace BluetoothAnzeigen.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        EinkaufEntry _entry;
        public EinkaufEntry Entry
        {
            get => _entry;
            set
            {
                _entry = value;
                OnPropertyChanged();
            }
        }

        public DetailViewModel(EinkaufEntry entry)
        {
            Entry = entry;
        }
    }
}
