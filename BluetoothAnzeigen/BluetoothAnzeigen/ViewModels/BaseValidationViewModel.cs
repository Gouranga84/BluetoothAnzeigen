using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace BluetoothAnzeigen.ViewModels
{
    public class BaseValidationViewModel : BaseViewModel, INotifyDataErrorInfo
    {
        readonly IDictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public BaseValidationViewModel() { }

        #region Ereigniss ErrorsChanged
        /// <summary>
        /// Tritt ein, wenn sich die Validierungsfehler für eine Eigenschaft geändert haben
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        #endregion

        #region Eigenschaft HasErrors
        /// <summary>
        /// Überprüft ob in der <see cref="_errors"/> Error vorhanden sind
        /// Wird für den Save button verwendet und OnPropertyChanged
        /// </summary>
        public bool HasErrors => _errors?.Any(x => x.Value.Any() == true) == true;
        #endregion

        #region Methode GetErrors
        /// <summary>
        /// Wird bei der Auswertung der Eigenschaft im Codebehind verwendet, anschließend im Switch zugeordnet
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                return _errors.SelectMany(x => x.Value);
            }

            if (_errors.ContainsKey(propertyName) && _errors[propertyName].Any())
            {
                return _errors[propertyName];
            }

            return new List<string>();
        }
        #endregion

        #region Funktion Validate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rule"></param> wird beim Aufruf deklariert
        /// <param name="error"></param> die dazugehörige Fehlerbeschreibung
        /// <param name="propertyName"></param> die aufrufende Eigenschaft
        protected void Validate(Func<bool> rule, string error, [CallerMemberName] string propertyName = "")
        {
            if (string.IsNullOrWhiteSpace(propertyName)) return;

            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
            }

            if (rule() == false)
            {
                _errors.Add(propertyName, new List<string> { error });
            }

            OnPropertyChanged(nameof(HasErrors));

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        #endregion
    }
}
