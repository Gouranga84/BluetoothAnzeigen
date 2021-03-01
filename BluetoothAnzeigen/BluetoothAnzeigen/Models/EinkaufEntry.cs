using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothAnzeigen.Models
{
    public class EinkaufEntry
    {
        public double Betrag { get; set; }
        public string Marktname { get; set; }
        public DateTime Datum { get; set; }
        public int Artikelanzahl { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
