using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BluetoothAnzeigen.ViewModels;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace BluetoothAnzeigen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEntryEinkauf : ContentPage
    {
        NewEntryViewModel ViewModel => BindingContext as NewEntryViewModel;

        public NewEntryEinkauf()
        {
            InitializeComponent();

            BindingContextChanged += Page_BindingContextChanged;

            BindingContext = new NewEntryViewModel();
        }

        void Page_BindingContextChanged(object sender, EventArgs e)
        {
            ViewModel.ErrorsChanged += ViewModel_ErrorsChanged;
        }

        private void ViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            var propHasErrors = (ViewModel.GetErrors(e.PropertyName) as List<string>)?.Any() == true;

            switch (e.PropertyName)
            {
                case nameof(ViewModel.Betrag):
                    betrag.LabelColor = propHasErrors ? Color.Red : Color.Black;
                    break;
                case nameof(ViewModel.Marktname):
                    marktname.LabelColor = propHasErrors ? Color.Red : Color.Black;
                    break;
                default:
                    break;
            }
        }
    }
}